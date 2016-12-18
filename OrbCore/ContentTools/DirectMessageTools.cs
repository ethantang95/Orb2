using Discord.WebSocket;
using OrbCore.ContentStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbCore.ContentTools
{
    internal static class DirectMessageTools
    {
        public static DirectMessageContent CreateDirectMessageContentFromSocketMessage(SocketMessage message)
        {
            ThrowIfNotRightType(message);
            return ExtractMessageToCreateDirectMessageContent(message);
        }

        public static bool IsSocketMessageDirectMessage(SocketMessage message)
        {
            return IsTypeSocketUserMessage(message) && IsChannelTypeSocketDMChannel(message);
        }

        private static void ThrowIfNotRightType(SocketMessage message)
        {
            if (!IsSocketMessageDirectMessage(message))
            {
                throw new InvalidCastException($"The type of SocketMessage that was given is not one that is from a direct message channel. It is of type {message.GetType().Name}. Suggest to correct and validate the type before sending in");
            }
        }

        private static DirectMessageContent ExtractMessageToCreateDirectMessageContent(SocketMessage message)
        {
            var content = message.Content;
            var user = message.Author;
            var channel = message.Channel;
            return new DirectMessageContent(message, content, user, channel);
        }

        private static bool IsTypeSocketUserMessage(SocketMessage message)
        {
            return message.GetType() == typeof(SocketUserMessage);
        }

        private static bool IsChannelTypeSocketDMChannel(SocketMessage message)
        {
            return message.GetType() == typeof(SocketDMChannel);
        }
    }
}
