using Discord.WebSocket;
using OrbCore.ContentStructures;
using OrbCore.ContentTools;
using OrbCore.Interfaces.Core;
using OrbCore.Core.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;

namespace OrbCore.Core
{
    public class OrbCore : IOrbCore
    {
        public ICoreAPI CoreAPI { get; private set; }
        public ICoreQuery CoreQuery { get; private set; }

        DiscordSocketClient _client;
        CoreConfig _config;
        bool _configured;

        internal OrbCore(CoreConfig config, DiscordSocketClient client, ICoreAPI coreApi, ICoreQuery coreQuery)
        {
            _config = config;
            CoreAPI = coreApi;
            CoreQuery = coreQuery;
            _configured = false;
            _client = client;
        }

        public void Reconfig(CoreConfig config)
        {
            _config = config;
            Stop();
            UnConfigureClient();
            Start();
        }

        public void Restart()
        {
            Stop();
            Start();
        }

        public async void Start()
        {
            ConfigureClientIfNotConfigured();
            await _client.LoginAsync(TokenType.Bot, _config.LoginToken);
            await _client.ConnectAsync();
        }

        public async void Stop()
        {
            await _client.DisconnectAsync();
            await _client.LogoutAsync();
        }

        public void Dispose()
        {
            Stop();
            UnConfigureClient();
        }

        private void ConfigureClientIfNotConfigured()
        {
            if (!_configured)
            {
                ConfigureClient();
            }
        }

        private void ConfigureClient()
        {
            RegisterEvents();
            SetGame();
            _configured = true;
        }

        private void SetGame()
        {
            if (_config.StartingGame.Present)
            {
                CoreAPI.SetGame(_config.StartingGame.Value);
            }
        }

        private void RegisterEvents()
        {
            _client.MessageReceived += OnMessageReceived;
            _client.Disconnected += OnDisconnected;
            _client.Ready += OnReady;
            _client.JoinedGuild += OnJoinedGuild;
            _client.LeftGuild += OnLeftGuild;
            _client.UserJoined += OnUserJoined;
            _client.UserBanned += OnUserBanned;
            _client.UserLeft += OnUserLeft;
        }

        private void UnConfigureClient()
        {
            UnRegisterEvents();
            _configured = false;
        }

        private void UnRegisterEvents()
        {
            _client.MessageReceived -= OnMessageReceived;
            _client.Disconnected -= OnDisconnected;
            _client.Ready -= OnReady;
            _client.JoinedGuild -= OnJoinedGuild;
            _client.LeftGuild -= OnLeftGuild;
            _client.UserJoined -= OnUserJoined;
            _client.UserBanned -= OnUserBanned;
            _client.UserLeft -= OnUserLeft;
        }

        #region events declaration
        private async Task OnMessageReceived(SocketMessage message)
        {
            if (GuildTextMessageTools.IsSocketMessageGuildTextMessage(message))
            {
                await HandleGuildTextMessage(message);
            }
            else if (DirectMessageTools.IsSocketMessageDirectMessage(message))
            {
                await HandleDirectMessage(message);
            }
        }

        private async Task HandleGuildTextMessage(SocketMessage message)
        {
            if (_config.GuildTextMessageReceiver.Present)
            {
                var messageContent = GuildTextMessageTools.CreateGuildTextMessageContentFromSocketMessage(message);
                await _config.GuildTextMessageReceiver.Value.OnGuildTextMessageReceived(messageContent);
            }
        }

        private async Task HandleDirectMessage(SocketMessage message)
        {
            if (_config.DirectMessageReceiver.Present)
            {
                var messageContent = DirectMessageTools.CreateDirectMessageContentFromSocketMessage(message);
                await _config.DirectMessageReceiver.Value.OnDirectMessageReceived(messageContent);
            }
        }

        private async Task OnDisconnected(Exception exception)
        {
            if (_config.DiscordDisconnectedReceiver.Present)
            {
                await _config.DiscordDisconnectedReceiver.Value.OnDiscordDisconnected(exception);
            }
        }

        private async Task OnReady()
        {
            if (_config.DiscordReadyReceiver.Present)
            {
                await _config.DiscordReadyReceiver.Value.OnDiscordReady();
            }
        }

        private async Task OnJoinedGuild(SocketGuild guild)
        {
            if (_config.GuildJoinedReceiver.Present)
            {
                await _config.GuildJoinedReceiver.Value.OnGuildJoined(guild);
            }
        }

        private async Task OnLeftGuild(SocketGuild guild)
        {
            if (_config.GuildLeftReceiver.Present)
            {
                await _config.GuildLeftReceiver.Value.OnGuildLeft(guild);
            }
        }

        private async Task OnUserJoined(SocketGuildUser user)
        {
            if (_config.UserJoinedReceiver.Present)
            {
                var eventContent = GuildUserEventTools.CreateGuildUserEventContentFromSocketGuildUser(user);
                await _config.UserJoinedReceiver.Value.OnUserJoined(eventContent);
            }
        }

        private async Task OnUserBanned(SocketUser user, SocketGuild guild)
        {
            if (_config.UserBannedReceiver.Present)
            {
                var eventContent = new GuildUserEventContent(user, guild);
                await _config.UserBannedReceiver.Value.OnUserBanned(eventContent);
            }
        }

        private async Task OnUserLeft(SocketGuildUser user)
        {
            if (_config.UserLeftReceiver.Present)
            {
                var eventContent = GuildUserEventTools.CreateGuildUserEventContentFromSocketGuildUser(user);
                await _config.UserLeftReceiver.Value.OnUserLeft(eventContent);
            }
        }
        #endregion
    }
}
