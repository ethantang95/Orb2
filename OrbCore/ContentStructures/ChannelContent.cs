using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbCore.ContentStructures {
    public class ChannelContent {
        public string ChannelName { get; private set; }
        public IChannel Channel { get; private set; }
        public IGuild Guild { get; private set; }
        public ChannelType ChannelType { get; private set; }

        internal ChannelContent(string channelName, IChannel channel, IGuild guild, ChannelType channelType) {
            ChannelName = channelName;
            Channel = channel;
            Guild = guild;
            ChannelType = ChannelType;
        }
    }
}
