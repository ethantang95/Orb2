using OrbCore.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbCore.Interfaces.EventLogger
{
    public interface IEventLoggerReceiver
    {
        void ReceiveVerboseEvent(CoreLogMessage message);
        void ReceiveWarningEvent(CoreLogMessage message);
        void ReceiveErrorEvent(CoreLogMessage message);
        void ReceiveCriticalEvent(CoreLogMessage message);
    }
}
