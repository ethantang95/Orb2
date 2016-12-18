using Discord.WebSocket;
using HelperCore.Optional;
using OrbCore.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbCore.Core
{
    public class CoreAPI : ICoreAPI
    {
        DiscordSocketClient _client;

        internal CoreAPI(DiscordSocketClient client)
        {
            _client = client;
        }

        public async Task SendMessage(string message, ISocketMessageChannel channel)
        {
            await channel.SendMessageAsync(message);
        }

        public async Task SendFileFromStream(Stream file, ISocketMessageChannel channel)
        {
            await SendFileFromStream(file, channel, Optional<string>.FromNull(), Optional<string>.FromNull());
        }

        public async Task SendFileFromStream(Stream file, ISocketMessageChannel channel, Optional<string> fileName, Optional<string> message)
        {
            await channel.SendFileAsync(file, fileName.OrElse(Guid.NewGuid().ToString()), message.OrDefault());
        }

        public async Task SendFileFromPath(string filePath, ISocketMessageChannel channel)
        {
            await SendFileFromPath(filePath, channel, Optional<string>.FromNull());
        }

        public async Task SendFileFromPath(string filePath, ISocketMessageChannel channel, Optional<string> message)
        {
            await channel.SendFileAsync(filePath, message.OrDefault());
        }

        public async Task SetGame(string game)
        {
            await _client.SetGame(game);
        }
    }
}
