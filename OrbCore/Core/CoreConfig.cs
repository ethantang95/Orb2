using OrbCore.Interfaces.Receivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbCore.Core
{
    public class CoreConfig
    {
        public string LoginToken { get; }
        public string StartingGame { get; }

        //receiver interfaces
        public IDirectMessageReceiver DirectMessageReceiver { get; }
        public IDiscordDisconnectedReceiver DiscordDisconnectedReceiver { get; }
        public IDiscordReadyReceiver DiscordReadyReceiver { get; }
        public IGuildJoinedReceiver GuildJoinedReceiver { get; }
        public IGuildLeftReceiver GuildLeftReceiver { get; }
        public IGuildTextMessageReceiver GuildTextMessageReceiver { get; }
        public IUserBannedReceiver UserBannedReceiver { get; }
        public IUserLeftReceiver UserLeftReceiver { get; }

        public CoreConfig() { }
    }
}
