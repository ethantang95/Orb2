using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCommons.DiscordImpls {
    public class MockSystemMessage : ISystemMessage {
        public IUser Author { get; set; }

        public IMessageChannel Channel { get; set; }

        public string Content { get; set; }

        public IReadOnlyCollection<IAttachment> Attachments {
            get {
                throw new NotImplementedException();
            }
        }

        public DateTimeOffset CreatedAt {
            get {
                throw new NotImplementedException();
            }
        }

        public DateTimeOffset? EditedTimestamp {
            get {
                throw new NotImplementedException();
            }
        }

        public IReadOnlyCollection<IEmbed> Embeds {
            get {
                throw new NotImplementedException();
            }
        }

        public ulong Id {
            get {
                throw new NotImplementedException();
            }
        }

        public bool IsPinned {
            get {
                throw new NotImplementedException();
            }
        }

        public bool IsTTS {
            get {
                throw new NotImplementedException();
            }
        }

        public bool IsWebhook {
            get {
                throw new NotImplementedException();
            }
        }

        public IReadOnlyCollection<ulong> MentionedChannelIds {
            get {
                throw new NotImplementedException();
            }
        }

        public IReadOnlyCollection<ulong> MentionedRoleIds {
            get {
                throw new NotImplementedException();
            }
        }

        public IReadOnlyCollection<ulong> MentionedUserIds {
            get {
                throw new NotImplementedException();
            }
        }

        public IReadOnlyCollection<ITag> Tags {
            get {
                throw new NotImplementedException();
            }
        }

        public DateTimeOffset Timestamp {
            get {
                throw new NotImplementedException();
            }
        }

        public MessageType Type {
            get {
                throw new NotImplementedException();
            }
        }

        public ulong? WebhookId {
            get {
                throw new NotImplementedException();
            }
        }

        public Task DeleteAsync(RequestOptions options = null) {
            throw new NotImplementedException();
        }
    }
}
