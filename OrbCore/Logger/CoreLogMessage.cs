using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbCore.Logger {
    public class CoreLogMessage {
        public string FileName { get; private set; }
        public string ClassName { get; private set; }
        public string MethodName { get; private set; }
        public string Message { get; private set; }
        internal CoreLogMessage(string fileName, string className, string methodName, string message) {
            FileName = fileName;
            ClassName = className;
            MethodName = methodName;
            Message = message;
        }
    }
}
