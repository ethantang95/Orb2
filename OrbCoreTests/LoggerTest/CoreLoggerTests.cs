using Discord;
using NUnit.Framework;
using OrbCore.Logger;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Diagnostics.DebuggableAttribute;

namespace OrbCoreTests.LoggerTest
{
    [TestFixture]
    class CoreLoggerTests
    {
        TestLoggerReceiver _receiver;

        [OneTimeSetUp]
        public void SetUp()
        {
            _receiver = new TestLoggerReceiver();
            CoreLogger.AddReceiver(_receiver);
        }

        [Test]
        public void TestLogVerboseMessage()
        {
            CoreLogger.LogVerbose("This is a verblose message");
            var message = AssertSeverityAndGetMessage(LogLevel.Verbose);
            AssertMessageMetaData(message);
        }

        [Test]
        public void TestLogWarningMessage()
        {
            CoreLogger.LogWarning("This is a warning message");
            var message = AssertSeverityAndGetMessage(LogLevel.Warning);
            AssertMessageMetaData(message);
        }

        [Test]
        public void TestLogErrorMessage()
        {
            CoreLogger.LogError("This is a error message");
            var message = AssertSeverityAndGetMessage(LogLevel.Error);
            AssertMessageMetaData(message);
        }

        [Test]
        public void TestLogCriticalMessage()
        {
            CoreLogger.LogCritical("This is a critical message");
            var message = AssertSeverityAndGetMessage(LogLevel.Critical);
            AssertMessageMetaData(message);
        }

        [Test]
        public void TestLogExceptionDefault()
        {
            CoreLogger.LogException(new Exception("this is an exception"));
            var message = AssertSeverityAndGetMessage(LogLevel.Error);
            AssertMessageMetaData(message);
            Assert.True(message.Message.Contains("EXCEPTION"));
        }

        [Test]
        public void TestLogExceptionDiffLevel()
        {
            CoreLogger.LogException(new Exception("this is an exception"), "EXCEPTION", LogLevel.Critical);
            var message = AssertSeverityAndGetMessage(LogLevel.Critical);
            AssertMessageMetaData(message);
        }

        private CoreLogMessage AssertSeverityAndGetMessage(LogLevel level)
        {
            Wait();
            Assert.AreEqual(level, _receiver.PrevLevel);
            return _receiver.PrevMessage;
        }

        private void AssertMessageMetaData(CoreLogMessage message)
        {
            Assert.AreEqual(GetCurrentMethod(2), message.MethodName);
            Assert.AreEqual(GetType().Name, message.ClassName);
            Assert.AreEqual(GetCurrentFile(), message.FileName);
        }

        private void Wait()
        {
            Task.Delay(1).Wait();
        }

        private string GetCurrentMethod(int index)
        {
            return new StackFrame(index).GetMethod().Name;
        }

        private string GetCurrentFile()
        {
            return new StackTrace(true).GetFrame(0).GetFileName().Split('\\').Last();
        }
    }
}
