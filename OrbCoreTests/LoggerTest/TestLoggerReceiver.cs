using OrbCore.Interfaces.EventLogger;
using OrbCore.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbCoreTests.LoggerTest
{
    class TestLoggerReceiver : IEventLoggerReceiver
    {
        public LogLevel PrevLevel { get; private set; }
        public CoreLogMessage PrevMessage { get; private set; }

        public void ReceiveCriticalEvent(CoreLogMessage message)
        {
            SetPrevContents(message, LogLevel.Critical);
        }

        public void ReceiveErrorEvent(CoreLogMessage message)
        {
            SetPrevContents(message, LogLevel.Error);
        }

        public void ReceiveVerboseEvent(CoreLogMessage message)
        {
            SetPrevContents(message, LogLevel.Verbose);
        }

        public void ReceiveWarningEvent(CoreLogMessage message)
        {
            SetPrevContents(message, LogLevel.Warning);
        }

        private void SetPrevContents(CoreLogMessage message, LogLevel level)
        {
            PrevLevel = level;
            PrevMessage = message;
        }
    }
}
