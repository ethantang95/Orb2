using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbCore.ContentStructures
{
    public class GuildTextMessageContent
    {
        public IMessage MessageInfo { get; private set; }
        public string MessageText { get; private set; }
        public IUser User { get; private set; }
        public IChannel Channel { get; private set; }
        public IGuild Guild { get; private set; }

        internal GuildTextMessageContent(IMessage messageInfo, string messageText, IUser user, IChannel channel, IGuild guild)
        {
            MessageInfo = messageInfo;
            MessageText = messageText;
            User = user;
            Channel = channel;
            Guild = guild;
        }
    }
}
