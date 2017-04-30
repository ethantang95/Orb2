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
using OrbCore.Logger;
using System.Threading;

namespace OrbCore.Core {
    public class OrbCore : IOrbCore, IDisposable {
        public ICoreAPI CoreAPI { get; private set; }
        public ICoreQuery CoreQuery { get; private set; }

        DiscordSocketClient _client;
        CoreConfig _config;
        bool _configured;

        internal OrbCore(CoreConfig config, DiscordSocketClient client, ICoreAPI coreApi, ICoreQuery coreQuery) {
            _config = config;
            CoreAPI = coreApi;
            CoreQuery = coreQuery;
            _configured = false;
            _client = client;
        }

        public void Reconfig(CoreConfig config) {
            CoreLogger.LogWarning("Client reconfigure called");
            _config = config;
            Stop();
            UnConfigureClient();
            Start();
            CoreLogger.LogVerbose("Client successfully reconfigured");
        }

        public void Restart() {
            CoreLogger.LogWarning("Client restart called");
            Stop();
            Start();
            CoreLogger.LogVerbose("Client successfully restarted");
        }

        public async void Start() {
            ConfigureClientIfNotConfigured();
            await _client.LoginAsync(TokenType.Bot, _config.LoginToken);
            await _client.StartAsync();
            CoreLogger.LogWarning("Client successfuly logged in and connected");
            await WaitForReady();
            CoreLogger.LogVerbose("Downloaded all guild meta info");
        }

        public async void Stop() {
            await _client.StopAsync();
            await _client.LogoutAsync();
            CoreLogger.LogWarning("Client successfully disconnected");
        }

        public void Dispose() {
            CoreLogger.LogWarning("Client dispose called");
            Stop();
            UnConfigureClient();
        }

        private void ConfigureClientIfNotConfigured() {
            if (!_configured) {
                ConfigureClient();
            } else {
                CoreLogger.LogVerbose("Client already configured");
            }
        }

        private void ConfigureClient() {
            CoreLogger.LogVerbose("Configuring client");
            RegisterEvents();
            RegisterLogger();
            SetGame();
            _configured = true;
            CoreLogger.LogVerbose("Client configured successfully");
        }

        private void SetGame() {
            if (_config.StartingGame.Present) {
                CoreAPI.SetGame(_config.StartingGame.Value);
            }
        }

        private void RegisterEvents() {
            _client.Connected += OnConnected;
            _client.Ready += OnReady;
            _client.Disconnected += OnDisconnected;

            _client.MessageReceived += OnMessageReceived;
            _client.MessageUpdated += OnMessageUpdated;
            _client.MessageDeleted += OnMessageDeleted;
            
            _client.JoinedGuild += OnJoinedGuild;
            _client.LeftGuild += OnLeftGuild;
            _client.GuildAvailable += OnGuildAvailable;
            _client.GuildUpdated += OnGuildUpdated;
            _client.GuildUnavailable += OnGuildUnavailable;

            _client.UserJoined += OnUserJoined;
            _client.UserUpdated += OnUserUpdated;
            _client.UserBanned += OnUserBanned;
            _client.UserUnbanned += OnUserUnbanned;
            _client.UserLeft += OnUserLeft;

            _client.ChannelCreated += OnChannelCreated;
            _client.ChannelUpdated += OnChannelUpdated;
            _client.ChannelDestroyed += OnChannelDestroyed;

            _client.RoleCreated += OnRoleCreated;
            _client.RoleUpdated += OnRoleUpdated;
            _client.RoleDeleted += OnRoleDeleted;

            _client.CurrentUserUpdated += OnCurrentUserUpdated;
            _client.GuildMemberUpdated += OnGuildMemberUpdated;
            _client.LatencyUpdated += OnLatencyUpdated;

        }

        private void RegisterLogger() {
            _client.Log += CoreLogger.LogDiscordCore;
        }

        private void UnConfigureClient() {
            CoreLogger.LogVerbose("Unconfiguring client");
            UnRegisterEvents();
            UnRegisterLogger();
            _configured = false;
            CoreLogger.LogVerbose("Client successfully unconfigured");
        }

        private void UnRegisterEvents() {
            _client.Connected -= OnConnected;
            _client.Ready -= OnReady;
            _client.Disconnected -= OnDisconnected;

            _client.MessageReceived -= OnMessageReceived;
            _client.MessageUpdated -= OnMessageUpdated;
            _client.MessageDeleted -= OnMessageDeleted;

            _client.JoinedGuild -= OnJoinedGuild;
            _client.LeftGuild -= OnLeftGuild;
            _client.GuildAvailable -= OnGuildAvailable;
            _client.GuildUpdated -= OnGuildUpdated;
            _client.GuildUnavailable -= OnGuildUnavailable;

            _client.UserJoined -= OnUserJoined;
            _client.UserUpdated -= OnUserUpdated;
            _client.UserBanned -= OnUserBanned;
            _client.UserUnbanned -= OnUserUnbanned;
            _client.UserLeft -= OnUserLeft;

            _client.ChannelCreated -= OnChannelCreated;
            _client.ChannelUpdated -= OnChannelUpdated;
            _client.ChannelDestroyed -= OnChannelDestroyed;

            _client.RoleCreated -= OnRoleCreated;
            _client.RoleUpdated -= OnRoleUpdated;
            _client.RoleDeleted -= OnRoleDeleted;

            _client.CurrentUserUpdated -= OnCurrentUserUpdated;
            _client.GuildMemberUpdated -= OnGuildMemberUpdated;
            _client.LatencyUpdated -= OnLatencyUpdated;
        }

        private void UnRegisterLogger() {
            _client.Log -= CoreLogger.LogDiscordCore;
        }

        private Task WaitForReady() {
            var readied = false;
            var completeEvent = new AutoResetEvent(false);

            Func<Task> readyCallback = () => {
                readied = true;
                completeEvent.Set();
                return Task.CompletedTask;
            };

            _client.Ready += readyCallback;
            completeEvent.WaitOne(30000);
            ThrowIfTimedOut(!readied);
            _client.Ready -= readyCallback;

            return Task.CompletedTask;
        }

        private void ThrowIfTimedOut(bool timedOut) {
            if (timedOut) {
                CoreLogger.LogCritical("Timed out connecting to discord.net");
                throw new TimeoutException("Cannot connect to discord.net. Please try again later");
            }
        }

        #region events declaration
        private async Task OnMessageReceived(SocketMessage message) {
            try {
                if (GuildTextMessageTools.IsSocketMessageGuildTextMessage(message)) {
                    await HandleGuildTextMessage(message);
                } else if (DirectMessageTools.IsSocketMessageDirectMessage(message)) {
                    await HandleDirectMessage(message);
                }
            } catch (Exception ex) {
                CoreLogger.LogException(ex);
            }
        }

        private async Task HandleGuildTextMessage(SocketMessage message) {
            if (_config.GuildTextMessageReceiver.Present) {
                var messageContent = GuildTextMessageTools.CreateGuildTextMessageContentFromSocketMessage(message);
                await _config.GuildTextMessageReceiver.Value.OnGuildTextMessageReceived(messageContent);
            }
        }

        private async Task HandleDirectMessage(SocketMessage message) {
            if (_config.DirectMessageReceiver.Present) {
                var messageContent = DirectMessageTools.CreateDirectMessageContentFromSocketMessage(message);
                await _config.DirectMessageReceiver.Value.OnDirectMessageReceived(messageContent);
            }
        }

        private async Task OnDisconnected(Exception exception) {
            try {
                if (_config.DiscordDisconnectedReceiver.Present) {
                    await _config.DiscordDisconnectedReceiver.Value.OnDiscordDisconnected(exception);
                }
            } catch (Exception ex) {
                CoreLogger.LogException(ex, "Failure to disconnect", LogLevel.Critical);
            }
        }

        private async Task OnReady() {
            try {
                if (_config.DiscordReadyReceiver.Present) {
                    await _config.DiscordReadyReceiver.Value.OnDiscordReady();
                }
            } catch (Exception ex) {
                CoreLogger.LogException(ex, "Failure to be ready", LogLevel.Critical);
                //maybe more stuff need to be done here
            }
        }

        private async Task OnJoinedGuild(SocketGuild guild) {
            try {
                if (_config.GuildJoinedReceiver.Present) {
                    await _config.GuildJoinedReceiver.Value.OnGuildJoined(guild);
                }
            } catch (Exception ex) {
                CoreLogger.LogException(ex);
            }
        }

        private async Task OnLeftGuild(SocketGuild guild) {
            try {
                if (_config.GuildLeftReceiver.Present) {
                    await _config.GuildLeftReceiver.Value.OnGuildLeft(guild);
                }
            } catch (Exception ex) {
                CoreLogger.LogException(ex);
            }
        }

        private async Task OnUserJoined(SocketGuildUser user) {
            try {
                if (_config.UserJoinedReceiver.Present) {
                    var eventContent = GuildUserEventTools.CreateGuildUserEventContentFromSocketGuildUser(user);
                    await _config.UserJoinedReceiver.Value.OnUserJoined(eventContent);
                }
            } catch (Exception ex) {
                CoreLogger.LogException(ex);
            }
        }

        private async Task OnUserBanned(SocketUser user, SocketGuild guild) {
            try {
                if (_config.UserBannedReceiver.Present) {
                    var eventContent = new GuildUserEventContent(user, guild);
                    await _config.UserBannedReceiver.Value.OnUserBanned(eventContent);
                }
            } catch (Exception ex) {
                CoreLogger.LogException(ex);
            }
        }

        private async Task OnUserLeft(SocketGuildUser user) {
            try {
                if (_config.UserLeftReceiver.Present) {
                    var eventContent = GuildUserEventTools.CreateGuildUserEventContentFromSocketGuildUser(user);
                    await _config.UserLeftReceiver.Value.OnUserLeft(eventContent);
                }
            } catch (Exception ex) {
                CoreLogger.LogException(ex);
            }
        }
        #endregion
    }
}
