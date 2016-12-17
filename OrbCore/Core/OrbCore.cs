using OrbCore.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbCore.Core
{
    public class OrbCore : IOrbCore
    {
        internal OrbCore(CoreConfig config)
        {

        }

        public ICoreAPI CoreApi
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ICoreQuery CoreQuery
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Reconfig(CoreConfig config)
        {
            throw new NotImplementedException();
        }

        public void Restart()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
