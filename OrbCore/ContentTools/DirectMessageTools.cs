using Discord;
using OrbCore.ContentStructures;
using OrbCore.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbCore.ContentTools {
    internal static class DirectMessageTools {
        public static DirectMessageContent CreateDirectMessageContentFromSocketMessage(IMessage message) {
            ThrowIfContainsNull(message);
            ThrowIfNotRightType(message);
            return ExtractMessageToCreateDirectMessageContent(message);
        }

        public static bool IsSocketMessageDirectMessage(IMessage message) {
            return IsTypeSocketUserMessage(message) && IsChannelTypeSocketDMChannel(message);
        }

        private static void ThrowIfNotRightType(IMessage message) {
            if (!IsSocketMessageDirectMessage(message)) {
                var ex = new InvalidCastException($"The type of SocketMessage that was given is not one that is from a direct message channel. It is of type {message.GetType().Name}. Suggest to correct and validate the type before sending in");
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
            }
        }

        private static void ThrowNullField(string field) {
            var ex = new ArgumentNullException($"The {field} field in the message appears to be null");
            CoreLogger.LogException(ex);
            throw ex;
        }

        private static DirectMessageContent ExtractMessageToCreateDirectMessageContent(IMessage message) {
            var content = message.Content;
            var user = message.Author;
            var channel = message.Channel;
            return new DirectMessageContent(message, content, user, channel);
        }

        private static bool IsTypeSocketUserMessage(IMessage message) {
            return message is IUserMessage;
        }

        private static bool IsMessageNull(IMessage message) {
            return message == null;
        }

        private static bool IsMessageContentNull(IMessage message) {
            return message.Content == null;
        }

        private static bool IsChannelTypeSocketDMChannel(IMessage message) {
            return message.Channel is IDMChannel;
        }

        private static bool IsChannelNull(IMessage message) {
            return message.Channel == null;
        }

        private static bool IsAuthorNull(IMessage message) {
            return message.Author == null;
        }
    }
}
