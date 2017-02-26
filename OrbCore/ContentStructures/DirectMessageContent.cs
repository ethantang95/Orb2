using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbCore.ContentStructures {
    public class DirectMessageContent {
        public IMessage MessageInfo { get; private set; }
        public string MessageText { get; private set; }
        public IUser User { get; private set; }
        public IChannel Channel { get; private set; }

        internal DirectMessageContent(IMessage messageInfo, string messageText, IUser user, IChannel channel) {
            MessageInfo = messageInfo;
            MessageText = messageText;
            User = user;
            Channel = channel;
        }
    }
}
