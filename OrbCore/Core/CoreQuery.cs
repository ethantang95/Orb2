using OrbCore.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;

namespace OrbCore.Core {
    public class CoreQuery : ICoreQuery {
        public IChannel GetChannel(ulong channelId) {
            throw new NotImplementedException();
        }

        public IGuild GetGuild(ulong guildId) {
            throw new NotImplementedException();
        }

        public IMessage GetMessage(ulong messageId) {
            throw new NotImplementedException();
        }

        public IRole GetRole(ulong roleId) {
            throw new NotImplementedException();
        }

        public IUser GetUser(ulong userId) {
            throw new NotImplementedException();
        }
    }
}
