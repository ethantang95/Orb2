using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCommons.DiscordImpls
{
    public class MockGuildUser : IGuildUser
    {
        public string AvatarId
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public DateTimeOffset CreatedAt
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Discriminator
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ushort DiscriminatorValue
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Game? Game
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IGuild Guild { get; set; }

        public ulong GuildId
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public GuildPermissions GuildPermissions
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ulong Id
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsBot
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsDeafened
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsMuted
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsSelfDeafened
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsSelfMuted
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsSuppressed
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public DateTimeOffset? JoinedAt
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Mention
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Nickname
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IReadOnlyCollection<ulong> RoleIds
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public UserStatus Status
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Username { get; set; }

        public IVoiceChannel VoiceChannel
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string VoiceSessionId
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Task<IDMChannel> CreateDMChannelAsync(RequestOptions options = null)
        {
            throw new NotImplementedException();
        }

        public string GetAvatarUrl(AvatarFormat format = AvatarFormat.Png, ushort size = 128)
        {
            throw new NotImplementedException();
        }

        public Task<IDMChannel> GetDMChannelAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions options = null)
        {
            throw new NotImplementedException();
        }

        public ChannelPermissions GetPermissions(IGuildChannel channel)
        {
            throw new NotImplementedException();
        }

        public Task KickAsync(RequestOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task ModifyAsync(Action<GuildUserProperties> func, RequestOptions options = null)
        {
            throw new NotImplementedException();
        }
    }
}
