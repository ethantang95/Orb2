using OrbCore.Core;
using OrbCore.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbCore
{
    public static class OrbCoreFactory
    {
        private static IOrbCore _currentCore;

        public static IOrbCore CreateCore(CoreConfig config)
        {
            throw new NotImplementedException();
        }
    }
}
