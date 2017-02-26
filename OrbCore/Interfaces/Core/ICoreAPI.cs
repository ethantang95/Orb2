using HelperCore.Optional;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbCore.Interfaces.Core {
    public interface ICoreAPI {
        Task SetGame(string game);
        Task SendMessage(string message, ISocketMessageChannel channel);
        Task SendFileFromStream(Stream file, ISocketMessageChannel channel);
        Task SendFileFromStream(Stream file, ISocketMessageChannel channel, Optional<string> fileName, Optional<string> message);
        Task SendFileFromPath(string filePath, ISocketMessageChannel channel);
        Task SendFileFromPath(string filePath, ISocketMessageChannel channel, Optional<string> message);
    }
}
