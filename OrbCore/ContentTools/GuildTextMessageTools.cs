using Discord;
using OrbCore.ContentStructures;
using OrbCore.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbCore.ContentTools {
    internal static class GuildTextMessageTools {
        public static GuildTextMessageContent CreateGuildTextMessageContentFromSocketMessage(IMessage message) {
            ThrowIfContainsNull(message);
            ThrowIfNotRightType(message);
            return ExtractMessageForGuildTextMessageContent(message);
        }

        public static bool IsSocketMessageGuildTextMessage(IMessage message) {
            return IsTypeSocketUserMessage(message)
                && IsChannelTypeSocketTextChannel(message)
                && IsAuthorSocketGuildUser(message)
                && !IsGuildNull(message);
        }

        private static void ThrowIfNotRightType(IMessage message) {
            if (!IsSocketMessageGuildTextMessage(message)) {
                var ex = new InvalidCastException($"The type of SocketMessage that was given is not one that is from a guild text channel. It is of type {message.GetType().Name}. Suggest to correct and validate the type before sending in");
                CoreLogger.LogException(ex);
                throw ex;
            }
        }

        private static void ThrowIfContainsNull(IMessage message) {
            if (IsMessageNull(message)) {
                ThrowNullField("message");
            } else if (IsMessageContentNull(message)) {
                ThrowNullField("message content");
            } else if (IsChannelNull(message)) {
                ThrowNullField("channel");
            } else if (IsAuthorNull(message)) {
                ThrowNullField("user");
            } else if (IsAuthorSocketGuildUser(message) && IsGuildNull(message)) {
                ThrowNullField("guild");
            }
        }

        private static void ThrowNullField(string field) {
            var ex = new ArgumentNullException($"The {field} field in the message appears to be null");
            CoreLogger.LogException(ex);
            throw ex;
        }

        private static GuildTextMessageContent ExtractMessageForGuildTextMessageContent(IMessage message) {
            var content = message.Content;
            var user = message.Author;
            var channel = message.Channel;
            var guild = (message.Author as IGuildUser).Guild;
            return new GuildTextMessageContent(message, content, user, channel, guild);
        }

        private static bool IsTypeSocketUserMessage(IMessage message) {
            return message is IUserMessage;
        }

        private static bool IsMessageNull(IMessage message) {
            return message == null;
        }

        private static bool IsChannelTypeSocketTextChannel(IMessage message) {
            return message.Channel is ITextChannel;
        }

        private static bool IsChannelNull(IMessage message) {
            return message.Channel == null;
        }

        private static bool IsMessageContentNull(IMessage message) {
            return message.Content == null;
        }

        private static bool IsAuthorSocketGuildUser(IMessage message) {
            return message.Author is IGuildUser;
        }

        private static bool IsAuthorNull(IMessage message) {
            return message.Author == null;
        }

        private static bool IsGuildNull(IMessage message) {
            return (message.Author as IGuildUser).Guild == null;
        }
    }
}
