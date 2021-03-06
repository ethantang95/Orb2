﻿using HelperCore.Optional;
using OrbCore.Interfaces.Receivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbCore.Core.Receiver {
    class CoreReceiver {
        public Optional<IDirectMessageReceiver> DirectMessageReceiver { get; set; }
        public Optional<IDiscordDisconnectedReceiver> DiscordDisconnectedReceiver { get; set; }
        public Optional<IDiscordReadyReceiver> DiscordReadyReceiver { get; set; }
        public Optional<IGuildJoinedReceiver> GuildJoinedReceiver { get; set; }
        public Optional<IGuildLeftReceiver> GuildLeftReceiver { get; set; }
        public Optional<IGuildTextMessageReceiver> GuildTextMessageReceiver { get; set; }
        public Optional<IUserJoinedReceiver> UserJoinedReceiver { get; set; }
        public Optional<IUserBannedReceiver> UserBannedReceiver { get; set; }
        public Optional<IUserLeftReceiver> UserLeftReceiver { get; set; }

        public CoreReceiver() {
            DirectMessageReceiver = Optional<IDirectMessageReceiver>.FromNull();
            DiscordDisconnectedReceiver = Optional<IDiscordDisconnectedReceiver>.FromNull();
            DiscordReadyReceiver = Optional<IDiscordReadyReceiver>.FromNull();
            GuildJoinedReceiver = Optional<IGuildJoinedReceiver>.FromNull();
            GuildLeftReceiver = Optional<IGuildLeftReceiver>.FromNull();
            GuildTextMessageReceiver = Optional<IGuildTextMessageReceiver>.FromNull();
            UserJoinedReceiver = Optional<IUserJoinedReceiver>.FromNull();
            UserBannedReceiver = Optional<IUserBannedReceiver>.FromNull();
            UserLeftReceiver = Optional<IUserLeftReceiver>.FromNull();
        }
    }
}
