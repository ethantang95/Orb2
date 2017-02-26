using Discord;
using NUnit.Framework;
using OrbCore.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbCoreTests.LoggerTest
{
    //These tests we are not testing meta data because we have no idea what's going on internally
    //inside the discord core
    [TestFixture]
    class DiscordCoreLogTests
    {
        TestLoggerReceiver _receiver;

        [OneTimeSetUp]
        public void SetUp()
        {
            _receiver = new TestLoggerReceiver();
            CoreLogger.AddReceiver(_receiver);
        }

        [Test]
        public void TestVerboseLog()
        {
            LogVerboseDiscordCoreLog();
            var message = AssertSeverityAndGetMessage(LogLevel.Verbose);
            AssertDiscordLogContents(message);
        }

        [Test]
        public void TestInfoLog()
        {
            LogInfoDiscordCoreLog();
            var message = AssertSeverityAndGetMessage(LogLevel.Verbose);
            AssertDiscordLogContents(message);
        }

        [Test]
        public void TestDebugLog()
        {
            LogDebugDiscordCoreLog();
            var message = AssertSeverityAndGetMessage(LogLevel.Verbose);
            AssertDiscordLogContents(message);
        }

        [Test]
        public void TestWarningLog()
        {
            LogWarningDiscordCoreLog();
            var message = AssertSeverityAndGetMessage(LogLevel.Warning);
            AssertDiscordLogContents(message);
        }

        [Test]
        public void TestErrorLog()
        {
            LogErrorDiscordCoreLog();
            var message = AssertSeverityAndGetMessage(LogLevel.Error);
            AssertDiscordLogContents(message);
        }

        [Test]
        public void TestCriticalLog()
        {
            LogCriticalDiscordCoreLog();
            var message = AssertSeverityAndGetMessage(LogLevel.Critical);
            AssertDiscordLogContents(message);
        }

        [Test]
        public void TestExceptionLog()
        {
            LogExceptionDiscordCoreLog();
            var message = AssertSeverityAndGetMessage(LogLevel.Critical);
            AssertDiscordLogContents(message);
            Assert.True(message.Message.Contains("EXCEPTION"));
        }

        private CoreLogMessage AssertSeverityAndGetMessage(LogLevel level)
        {
            Wait();
            Assert.AreEqual(level, _receiver.PrevLevel);
            return _receiver.PrevMessage;
        }

        private void Wait()
        {
            Task.Delay(1).Wait();
        }

        private void AssertDiscordLogContents(CoreLogMessage message)
        {
            Assert.True(message.Message.Contains("Discord Core Message"));
        }

        private void LogVerboseDiscordCoreLog()
        {
            LogDiscordCoreLog("This is Verbose", LogSeverity.Verbose);
        }

        private void LogDebugDiscordCoreLog()
        {
            LogDiscordCoreLog("This is Debug", LogSeverity.Debug);
        }

        private void LogInfoDiscordCoreLog()
        {
            LogDiscordCoreLog("This is Info", LogSeverity.Info);
        }

        private void LogWarningDiscordCoreLog()
        {
            LogDiscordCoreLog("This is Warning", LogSeverity.Warning);
        }

        private void LogErrorDiscordCoreLog()
        {
            LogDiscordCoreLog("This is Error", LogSeverity.Error);
        }

        private void LogCriticalDiscordCoreLog()
        {
            LogDiscordCoreLog("This is Critical", LogSeverity.Critical);
        }

        private void LogExceptionDiscordCoreLog()
        {
            LogDiscordCoreLog("This is a Critical with an Exception", LogSeverity.Critical, new Exception("Here is the exception"));
        }

        private void LogDiscordCoreLog(string message, LogSeverity severity, Exception exception = null)
        {
            var msg =  new LogMessage(severity, "CoreLoggerTest", message, exception);
            CoreLogger.LogDiscordCore(msg);
        }
    }
}
