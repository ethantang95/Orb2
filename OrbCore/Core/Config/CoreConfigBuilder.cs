using HelperCore.Optional;
using OrbCore.Interfaces.Receivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbCore.Core.Config
{
    public class CoreConfigBuilder
    {
        CoreConfig _config;

        public CoreConfigBuilder(string token)
        {
            _config = new CoreConfig(token);
        }

        public CoreConfigBuilder SetStartingGame(string game)
        {
            _config.StartingGame = Optional.From(game);
            return this;
        }

        public CoreConfigBuilder SetDirectMessageReceiver(IDirectMessageReceiver receiver)
        {
            _config.DirectMessageReceiver = Optional.From(receiver);
            return this;
        }

        public CoreConfigBuilder SetDiscordDisconnectReceiver(IDiscordDisconnectedReceiver receiver)
        {
            _config.DiscordDisconnectedReceiver = Optional.From(receiver);
            return this;
        }

        public CoreConfigBuilder SetDiscordReadyReceiver(IDiscordReadyReceiver receiver)
        {
            _config.DiscordReadyReceiver = Optional.From(receiver);
            return this;
        }

        public CoreConfigBuilder SetGuildJoinedReceiver(IGuildJoinedReceiver receiver)
        {
            _config.GuildJoinedReceiver = Optional.From(receiver);
            return this;
        }

        public CoreConfigBuilder SetGuildLeftReceiver(IGuildLeftReceiver receiver)
        {
            _config.GuildLeftReceiver = Optional.From(receiver);
            return this;
        }

        public CoreConfigBuilder SetGuildTextMessageReceiver(IGuildTextMessageReceiver receiver)
        {
            _config.GuildTextMessageReceiver = Optional.From(receiver);
            return this;
        }

        public CoreConfigBuilder SetUserJoinedReceiver(IUserJoinedReceiver receiver)
        {
            _config.UserJoinedReceiver = Optional.From(receiver);
            return this;
        }

        public CoreConfigBuilder SetUserBannedReceiver(IUserBannedReceiver receiver)
        {
            _config.UserBannedReceiver = Optional.From(receiver);
            return this;
        }

        public CoreConfigBuilder SetUserLeftReceiver(IUserLeftReceiver receiver)
        {
            _config.UserLeftReceiver = Optional.From(receiver);
            return this;
        }

        public CoreConfig Build()
        {
            return _config;
        }
    }
}
