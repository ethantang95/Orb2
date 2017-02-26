using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Audio;

namespace TestCommons.DiscordImpls {
    public class MockGuild : IGuild {
        public ulong? AFKChannelId {
            get {
                throw new NotImplementedException();
            }
        }

        public int AFKTimeout {
            get {
                throw new NotImplementedException();
            }
        }

        public IAudioClient AudioClient {
            get {
                throw new NotImplementedException();
            }
        }

        public bool Available {
            get {
                throw new NotImplementedException();
            }
        }

        public DateTimeOffset CreatedAt {
            get {
                throw new NotImplementedException();
            }
        }

        public ulong DefaultChannelId {
            get {
                throw new NotImplementedException();
            }
        }

        public DefaultMessageNotifications DefaultMessageNotifications {
            get {
                throw new NotImplementedException();
            }
        }

        public ulong? EmbedChannelId {
            get {
                throw new NotImplementedException();
            }
        }

        public IReadOnlyCollection<GuildEmoji> Emojis {
            get {
                throw new NotImplementedException();
            }
        }

        public IRole EveryoneRole {
            get {
                throw new NotImplementedException();
            }
        }

        public IReadOnlyCollection<string> Features {
            get {
                throw new NotImplementedException();
            }
        }

        public string IconId {
            get {
                throw new NotImplementedException();
            }
        }

        public string IconUrl {
            get {
                throw new NotImplementedException();
            }
        }

        public ulong Id {
            get {
                throw new NotImplementedException();
            }
        }

        public bool IsEmbeddable {
            get {
                throw new NotImplementedException();
            }
        }

        public MfaLevel MfaLevel {
            get {
                throw new NotImplementedException();
            }
        }

        public string Name { get; set; }

        public ulong OwnerId {
            get {
                throw new NotImplementedException();
            }
        }

        public IReadOnlyCollection<IRole> Roles {
            get {
                throw new NotImplementedException();
            }
        }

        public string SplashId {
            get {
                throw new NotImplementedException();
            }
        }

        public string SplashUrl {
            get {
                throw new NotImplementedException();
            }
        }

        public VerificationLevel VerificationLevel {
            get {
                throw new NotImplementedException();
            }
        }

        public string VoiceRegionId {
            get {
                throw new NotImplementedException();
            }
        }

        public Task AddBanAsync(ulong userId, int pruneDays = 0, RequestOptions options = null) {
            throw new NotImplementedException();
        }

        public Task AddBanAsync(IUser user, int pruneDays = 0, RequestOptions options = null) {
            throw new NotImplementedException();
        }

        public Task<IGuildIntegration> CreateIntegrationAsync(ulong id, string type, RequestOptions options = null) {
            throw new NotImplementedException();
        }

        public Task<IRole> CreateRoleAsync(string name, GuildPermissions? permissions = default(GuildPermissions?), Color? color = default(Color?), bool isHoisted = false, RequestOptions options = null) {
            throw new NotImplementedException();
        }

        public Task<ITextChannel> CreateTextChannelAsync(string name, RequestOptions options = null) {
            throw new NotImplementedException();
        }

        public Task<IVoiceChannel> CreateVoiceChannelAsync(string name, RequestOptions options = null) {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(RequestOptions options = null) {
            throw new NotImplementedException();
        }

        public Task DownloadUsersAsync() {
            throw new NotImplementedException();
        }

        public Task<IVoiceChannel> GetAFKChannelAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions options = null) {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<IBan>> GetBansAsync(RequestOptions options = null) {
            throw new NotImplementedException();
        }

        public Task<IGuildChannel> GetChannelAsync(ulong id, CacheMode mode = CacheMode.AllowDownload, RequestOptions options = null) {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<IGuildChannel>> GetChannelsAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions options = null) {
            throw new NotImplementedException();
        }

        public Task<IGuildUser> GetCurrentUserAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions options = null) {
            throw new NotImplementedException();
        }

        public Task<ITextChannel> GetDefaultChannelAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions options = null) {
            throw new NotImplementedException();
        }

        public Task<IVoiceChannel> GetEmbedChannelAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions options = null) {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<IGuildIntegration>> GetIntegrationsAsync(RequestOptions options = null) {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<IInviteMetadata>> GetInvitesAsync(RequestOptions options = null) {
            throw new NotImplementedException();
        }

        public Task<IGuildUser> GetOwnerAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions options = null) {
            throw new NotImplementedException();
        }

        public IRole GetRole(ulong id) {
            throw new NotImplementedException();
        }

        public Task<ITextChannel> GetTextChannelAsync(ulong id, CacheMode mode = CacheMode.AllowDownload, RequestOptions options = null) {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<ITextChannel>> GetTextChannelsAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions options = null) {
            throw new NotImplementedException();
        }

        public Task<IGuildUser> GetUserAsync(ulong id, CacheMode mode = CacheMode.AllowDownload, RequestOptions options = null) {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<IGuildUser>> GetUsersAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions options = null) {
            throw new NotImplementedException();
        }

        public Task<IVoiceChannel> GetVoiceChannelAsync(ulong id, CacheMode mode = CacheMode.AllowDownload, RequestOptions options = null) {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<IVoiceChannel>> GetVoiceChannelsAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions options = null) {
            throw new NotImplementedException();
        }

        public Task LeaveAsync(RequestOptions options = null) {
            throw new NotImplementedException();
        }

        public Task ModifyAsync(Action<GuildProperties> func, RequestOptions options = null) {
            throw new NotImplementedException();
        }

        public Task ModifyChannelsAsync(IEnumerable<BulkGuildChannelProperties> args, RequestOptions options = null) {
            throw new NotImplementedException();
        }

        public Task ModifyEmbedAsync(Action<GuildEmbedProperties> func, RequestOptions options = null) {
            throw new NotImplementedException();
        }

        public Task ModifyRolesAsync(IEnumerable<BulkRoleProperties> args, RequestOptions options = null) {
            throw new NotImplementedException();
        }

        public Task<int> PruneUsersAsync(int days = 30, bool simulate = false, RequestOptions options = null) {
            throw new NotImplementedException();
        }

        public Task RemoveBanAsync(ulong userId, RequestOptions options = null) {
            throw new NotImplementedException();
        }

        public Task RemoveBanAsync(IUser user, RequestOptions options = null) {
            throw new NotImplementedException();
        }
    }
}
