using Discord.WebSocket;
using OrbCore.Core;
using OrbCore.Core.Config;
using OrbCore.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbCore {
    public static class OrbCoreFactory {
        public static IOrbCore MasterCore {
            get {
                if (CoreExists()) {
                    return _masterCore;
                } else {
                    throw new InvalidOperationException("The master core hasn't been created yet, please create a core by calling CreateMasterCore()");
                }
            }
        }

        private static IOrbCore _masterCore;

        public static IOrbCore CreateMasterCore(CoreConfig config) {
            if (!CoreExists()) {
                _masterCore = CreateAndConfigureCore(config);
                return MasterCore;
            } else {
                throw new InvalidOperationException("A master core has already been created, please use the existing master core");
            }
        }

        public static bool CoreExists() {
            return _masterCore != null;
        }

        public static IOrbCore CreateSeparateCore(CoreConfig config) {
            return CreateAndConfigureCore(config);
        }

        private static IOrbCore CreateAndConfigureCore(CoreConfig config) {
            var discordClient = new DiscordSocketClient();
            var core = new Core.OrbCore(config, discordClient, new CoreAPI(discordClient), new CoreQuery());
            return core;
        }
    }
}
