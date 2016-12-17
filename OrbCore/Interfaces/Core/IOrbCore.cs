using OrbCore.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbCore.Interfaces.Core
{
    public interface IOrbCore : IDisposable
    {
        ICoreAPI CoreApi { get; }
        ICoreQuery CoreQuery { get; }

        void Start();
        void Stop();
        void Restart();
        void Reconfig(CoreConfig config);
    }
}
