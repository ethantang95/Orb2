using Discord;
using Discord.WebSocket;
using OrbCore.ContentStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbCore.ContentTools
{
    internal static class GuildTextMessageTools
    {
        public static GuildTextMessageContent CreateGuildTextMessageContentFromSocketMessage(SocketMessage message)
        {
            ThrowIfNotRightType(message);
            return ExtractMessageForGuildTextMessageContent(message);
        }

        public static bool IsSocketMessageGuildTextMessage(SocketMessage message)
        {
            return IsTypeSocketUserMessage(message) && IsChannelTypeSocketTextChannel(message) && IsAuthorSocketGuildUser(message);
        }

        private static void ThrowIfNotRightType(SocketMessage message)
        {
            if (!IsSocketMessageGuildTextMessage(message))
            {
                throw new InvalidCastException($"The type of SocketMessage that was given is not one that is from a guild text channel. It is of type {message.GetType().Name}. Suggest to correct and validate the type before sending in");
            }
        }

        private static GuildTextMessageContent ExtractMessageForGuildTextMessageContent(SocketMessage message)
        {
            var content = message.Content;
            var user = message.Author;
            var channel = message.Channel;
            var guild = (message.Author as SocketGuildUser).Guild;
            return new GuildTextMessageContent(message, content, user, channel, guild);
        }

        private static bool IsTypeSocketUserMessage(SocketMessage message)
        {
            return message.GetType() == typeof(SocketUserMessage);
        }

        private static bool IsChannelTypeSocketTextChannel(SocketMessage message)
        {
            return message.Channel.GetType() == typeof(SocketTextChannel);
        }

        private static bool IsAuthorSocketGuildUser(SocketMessage message)
        {
            return message.Author.GetType() == typeof(SocketGuildUser);
        }
    }
}
