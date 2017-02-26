using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OrbCore.Core.Config;

namespace OrbCore.Interfaces.Core {
    public interface IOrbCore : IDisposable {
        ICoreAPI CoreAPI { get; }
        ICoreQuery CoreQuery { get; }

        void Start();
        void Stop();
        void Restart();
        void Reconfig(CoreConfig config);
    }
}
