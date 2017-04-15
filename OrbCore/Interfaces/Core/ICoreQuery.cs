using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbCore.Interfaces.Core {
    public interface ICoreQuery {
        IUser GetUser(ulong userId);
        IChannel GetChannel(ulong channelId);
        IGuild GetGuild(ulong guildId);
        IRole GetRole(ulong roleId);
        IMessage GetMessage(ulong messageId);

    }
}
