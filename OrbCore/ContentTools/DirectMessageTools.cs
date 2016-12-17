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
            if (!IsSocketMessageDirectMessage(message))
            {
                throw new InvalidCastException($"The type of SocketMessage that was given is not one that is from a direct message channel. It is of type {message.GetType().Name}. Suggest to correct and validate the type before sending in");
            }

            var content = message.Content;
            var user = message.Author;
            var channel = message.Channel;

            return new DirectMessageContent(message, content, user, channel);
        }

        public static bool IsSocketMessageDirectMessage(SocketMessage message)
        {
            if (message.GetType() != typeof(SocketUserMessage))
            {
                return false;
            }

            var userMessage = message as SocketUserMessage;

            if (userMessage.Channel.GetType() != typeof(SocketDMChannel))
            {
                return false;
            }

            return true;
        }
    }
}
