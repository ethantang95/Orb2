using OrbCore.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbEngine.Interfaces.Engine {
    public interface IOrbEngine {
        void Start();
        void Stop();
        void Restart();
    }
}
