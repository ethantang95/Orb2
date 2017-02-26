using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCommons.DiscordImpls {
    public class MockUserMessage : IUserMessage {

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

        public IReadOnlyDictionary<Emoji, int> Reactions {
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

        public Task AddReactionAsync(string emoji, RequestOptions options = null) {
            throw new NotImplementedException();
        }

        public Task AddReactionAsync(Emoji emoji, RequestOptions options = null) {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(RequestOptions options = null) {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<IUser>> GetReactionUsersAsync(string emoji, int limit = 100, ulong? afterUserId = default(ulong?), RequestOptions options = null) {
            throw new NotImplementedException();
        }

        public Task ModifyAsync(Action<MessageProperties> func, RequestOptions options = null) {
            throw new NotImplementedException();
        }

        public Task PinAsync(RequestOptions options = null) {
            throw new NotImplementedException();
        }

        public Task RemoveAllReactionsAsync(RequestOptions options = null) {
            throw new NotImplementedException();
        }

        public Task RemoveReactionAsync(string emoji, IUser user, RequestOptions options = null) {
            throw new NotImplementedException();
        }

        public Task RemoveReactionAsync(Emoji emoji, IUser user, RequestOptions options = null) {
            throw new NotImplementedException();
        }

        public string Resolve(TagHandling userHandling = TagHandling.Name, TagHandling channelHandling = TagHandling.Name, TagHandling roleHandling = TagHandling.Name, TagHandling everyoneHandling = TagHandling.Ignore, TagHandling emojiHandling = TagHandling.Name) {
            throw new NotImplementedException();
        }

        public Task UnpinAsync(RequestOptions options = null) {
            throw new NotImplementedException();
        }
    }
}
