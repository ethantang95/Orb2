using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using OrbCore.Interfaces.EventLogger;
using System.Runtime.CompilerServices;
using Discord;

namespace OrbCore.Logger {
    public class CoreLogger {
        private List<IEventLoggerReceiver> _receivers;

        private static CoreLogger _logger;

        private CoreLogger() {
            _receivers = new List<IEventLoggerReceiver>();
        }

        static CoreLogger() {
            _logger = new CoreLogger();
        }

        public static void LogVerbose(string message, [CallerMemberName]string methodName = "", [CallerFilePath]string filePath = "") {
            LogMessage(message, methodName, filePath, LogLevel.Verbose);
        }

        public static void LogWarning(string message, [CallerMemberName]string methodName = "", [CallerFilePath]string filePath = "") {
            LogMessage(message, methodName, filePath, LogLevel.Warning);
        }

        public static void LogError(string message, [CallerMemberName]string methodName = "", [CallerFilePath]string filePath = "") {
            LogMessage(message, methodName, filePath, LogLevel.Error);
        }

        public static void LogCritical(string message, [CallerMemberName]string methodName = "", [CallerFilePath]string filePath = "") {
            LogMessage(message, methodName, filePath, LogLevel.Critical);
        }

        public static void LogException(Exception exception, string message = "EXCEPTION", LogLevel level = LogLevel.Error, [CallerMemberName]string methodName = "", [CallerFilePath]string filePath = "") {
            var fullMsg = $"{message}: {exception.ToString()}";
            LogMessage(fullMsg, methodName, filePath, level);
        }

        internal static void AddReceiver(IEventLoggerReceiver receiver) {
            _logger._receivers.Add(receiver);
        }

        internal static Task LogDiscordCore(LogMessage message) {
            var messageString = BuildDiscordCoreMsg(message);
            SendDiscordCoreMsgToLog(messageString, message.Severity);
            return Task.CompletedTask;
        }

        private static void LogMessage(string message, string methodName, string filePath, LogLevel level, string className = null) {
            var logMessage = CreateMessageFromContents(filePath, methodName, message);
            DispatchMessageForLevel(logMessage, level);
        }

        private static CoreLogMessage CreateMessageFromContents(string filePath, string methodName, string message, string className = null) {
            var fileName = ParsePath(filePath);

            if (className == null) {
                className = GetCallerClass(4);
            }
            return new CoreLogMessage(fileName, className, methodName, message);
        }

        private static string GetCallerClass(int stacks) {
            var stackFrame = new StackFrame(stacks);
            var callerMethod = stackFrame.GetMethod();
            var className = callerMethod.DeclaringType.Name;
            return className;
        }

        private static string ParsePath(string path) {
            var segments = path.Split('\\');
            return segments.Last();
        }

        private static void DispatchMessageForLevel(CoreLogMessage message, LogLevel level) {
            if (level == LogLevel.Verbose) {
                _logger._receivers.ForEach(s => Task.Run(() => s.ReceiveVerboseEvent(message)));
            } else if (level == LogLevel.Warning) {
                _logger._receivers.ForEach(s => Task.Run(() => s.ReceiveWarningEvent(message)));
            } else if (level == LogLevel.Error) {
                _logger._receivers.ForEach(s => Task.Run(() => s.ReceiveErrorEvent(message)));
            } else if (level == LogLevel.Critical) {
                _logger._receivers.ForEach(s => Task.Run(() => s.ReceiveCriticalEvent(message)));
            }
        }

        private static string BuildDiscordCoreMsg(LogMessage message) {
            var builder = new StringBuilder("Discord Core Message: ");

            builder.Append($"{message.Source} - ");
            builder.Append($"{message.Message}. ");
            if (message.Exception != null) {
                builder.Append($"EXCEPTION: {message.Exception}");
            }

            return builder.ToString();
        }

        private static void SendDiscordCoreMsgToLog(string message, LogSeverity severity) {
            if (IsVerboseSeverity(severity)) {
                LogVerbose(message);
            } else if (severity == LogSeverity.Warning) {
                LogWarning(message);
            } else if (severity == LogSeverity.Error) {
                LogError(message);
            } else if (severity == LogSeverity.Critical) {
                LogCritical(message);
            } else {
                LogWarning($"Discord Core message without severity - {message}");
            }
        }

        private static bool IsVerboseSeverity(LogSeverity severity) {
            return severity == LogSeverity.Info || severity == LogSeverity.Debug || severity == LogSeverity.Verbose;
        }
    }

    public enum LogLevel { Critical, Error, Warning, Verbose }
}