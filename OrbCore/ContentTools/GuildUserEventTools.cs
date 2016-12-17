using Discord.WebSocket;
using OrbCore.ContentStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbCore.ContentTools
{
    internal static class GuildUserEventTools
    {
        public static GuildUserEventContent CreateGuildUserEventContentFromSocketGuildUser(SocketGuildUser user)
        {
            return new GuildUserEventContent(user, user.Guild);
        }
    }
}
