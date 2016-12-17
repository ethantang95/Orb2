using Discord;
using Discord.WebSocket;
using OrbCore.ContentStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbCore.ContentCreators
{
    internal static class GuildTextMessageCreator
    {
        public static GuildTextMessageContent CreateGuildTextMessageContentFromSocketMessage(SocketMessage message)
        {
            if (!IsSocketMessageGuildTextMessage(message))
            {
                throw new InvalidCastException($"The type of SocketMessage that was given is not one that is from a guild text channel. It is of type {message.GetType().Name}. Suggest to correct and validate the type before sending in");
            }

            var content = message.Content;
            var user = message.Author;
            var channel = message.Channel;
            var guild = (message.Author as SocketGuildUser).Guild;

            return new GuildTextMessageContent(message, content, user, channel, guild);
        }

        public static bool IsSocketMessageGuildTextMessage(SocketMessage message)
        {
            if (message.GetType() != typeof(SocketUserMessage))
            {
                return false;
            }

            var userMessage = message as SocketUserMessage;

            if (userMessage.Channel.GetType() != typeof(SocketTextChannel))
            {
                return false;
            }

            return true;
        }
    }
}
