using Discord;
using Discord.WebSocket;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkTests.Discord.NETTests
{
    [TestFixture]
    public class BasicControlTests
    {
        private static DiscordSocketClient _client;
        [OneTimeSetUp]
        public async Task SetUp()
        {
            _client = await Connect();

            Console.WriteLine("connected");
        }

        [Test]
        public void EnsureLoggedOn()
        {
            Assert.True(_client.ConnectionState == ConnectionState.Connected);
        }

        [Test]
        public async Task SendMessage()
        {
            var mainServerId = ulong.Parse(ConfigurationManager.AppSettings["MainServer"]);
            var mainChannelId = ulong.Parse(ConfigurationManager.AppSettings["MainTextChannel"]);

            var channel = await _client.GetGuild(mainServerId).GetTextChannelAsync(mainChannelId);
            await channel.SendMessageAsync("Hello World");
        }

        [Test]
        public async Task SendPrivateMessage()
        {
            var mainDevId = ulong.Parse(ConfigurationManager.AppSettings["MainDev"]);

            var channel = await _client.GetUser(mainDevId).CreateDMChannelAsync();

            await channel.SendMessageAsync("Hello Developer");
        }

        [Test]
        public async Task ChangeStatus()
        {
            await _client.SetGame("Testing");
        }

        [Test]
        public void GetGuild()
        {
            var mainServerId = ulong.Parse(ConfigurationManager.AppSettings["MainServer"]);
            var guild = _client.GetGuild(mainServerId);

            Assert.AreEqual(mainServerId, guild.Id);
        }

        [Test]
        public async Task GetChannel()
        {
            var mainServerId = ulong.Parse(ConfigurationManager.AppSettings["MainServer"]);
            var mainChannelId = ulong.Parse(ConfigurationManager.AppSettings["MainTextChannel"]);

            var channel = _client.GetChannel(mainChannelId);

            var textChannel = await _client.GetGuild(mainServerId).GetTextChannelAsync(mainChannelId);

            Assert.AreEqual(mainChannelId, channel.Id);
            Assert.AreEqual(mainChannelId, textChannel.Id);
        }

        [Test]
        public void GetUser()
        {
            var userId = ulong.Parse(ConfigurationManager.AppSettings["MainDev"]);

            var user = _client.GetUser(userId);

            Assert.AreEqual(userId, user.Id);
        }

        [Test]
        public void GetNonExistentChannel()
        {
            var channel = _client.GetChannel(1);

            Assert.IsNull(channel);
        }

        [Test]
        public void GetNonExistentUser()
        {
            var user = _client.GetUser(1);

            Assert.IsNull(user);
        }

        [Test]
        public void RegisterReceivingMessage()
        {
            _client.MessageReceived += async (msg) => 
            {
                Console.WriteLine(msg.Content);
            };
        }

        private async Task<DiscordSocketClient> Connect()
        {
            var token = ConfigurationManager.AppSettings["TestBotKey"];
            var client = new DiscordSocketClient();

            await client.LoginAsync(TokenType.Bot, token);
            await client.ConnectAsync();

            return client;
        }
    }
}
