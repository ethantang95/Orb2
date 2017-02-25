using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCommons.DiscordImpls
{
    public class MockUser : IUser
    {
        public ulong Id { get; set; }

        public string Username { get; set; }

        public string AvatarId
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string AvatarUrl
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

        public bool IsBot
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

        public UserStatus Status
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

        public Task<IDMChannel> GetDMChannelAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions options = null)
        {
            throw new NotImplementedException();
        }
    }
}
