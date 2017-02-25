using Discord;
using NUnit.Framework;
using OrbCore.ContentTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommons.DiscordImpls;

namespace OrbCoreTests.ContentToolsTest
{
    [TestFixture]
    class GuildTextMessageToolsTest
    {
        [Test]
        public void TestValidatingDMContent()
        {
            var msg = CreateMockMsg();

            var result = GuildTextMessageTools.IsSocketMessageGuildTextMessage(msg);

            Assert.True(result);
        }

        [Test]
        public void TestCreatingDMContent()
        {
            var msg = CreateMockMsg();

            var result = GuildTextMessageTools.CreateGuildTextMessageContentFromSocketMessage(msg);

            Assert.AreEqual(msg, result.MessageInfo);
            Assert.AreEqual(msg.Author, result.User);
            Assert.AreEqual((msg.Author as IGuildUser).Guild, result.Guild);
            Assert.AreEqual(msg.Content, result.MessageText);
            Assert.AreEqual(msg.Channel, result.Channel);
        }

        [Test]
        public void TestMessageNotGuildChannelMsg()
        {
            var msg = new MockUserMessage();
            msg.Channel = new MockDMChannel();
            msg.Author = new MockUser();
            msg.Content = "";

            Assert.Throws<InvalidCastException>(() => GuildTextMessageTools.CreateGuildTextMessageContentFromSocketMessage(msg));
        }

        [Test]
        public void TestMessageNotUserMessage()
        {
            var msg = new MockSystemMessage();
            msg.Channel = new MockTextChannel();
            msg.Author = new MockUser();
            msg.Content = "";

            Assert.Throws<InvalidCastException>(() => GuildTextMessageTools.CreateGuildTextMessageContentFromSocketMessage(msg));
        }

        [Test]
        public void TestUserNotGuildUser()
        {
            var msg = new MockUserMessage();
            msg.Channel = new MockTextChannel();
            msg.Author = new MockUser();
            msg.Content = "";

            Assert.Throws<InvalidCastException>(() => GuildTextMessageTools.CreateGuildTextMessageContentFromSocketMessage(msg));


        }

        [Test]
        public void TestNullMessage()
        {
            Assert.Throws<ArgumentNullException>(() => GuildTextMessageTools.CreateGuildTextMessageContentFromSocketMessage(null));
        }

        [Test]
        public void TestNullMessageContent()
        {
            var msg = new MockUserMessage();
            msg.Channel = new MockTextChannel();
            msg.Author = new MockGuildUser() { Guild = new MockGuild() };
            msg.Content = null;

            Assert.Throws<ArgumentNullException>(() => GuildTextMessageTools.CreateGuildTextMessageContentFromSocketMessage(msg));
        }

        [Test]
        public void TestNullChannel()
        {
            var msg = new MockUserMessage();
            msg.Channel = null;
            msg.Author = new MockGuildUser() { Guild = new MockGuild() };
            msg.Content = "";

            Assert.Throws<ArgumentNullException>(() => GuildTextMessageTools.CreateGuildTextMessageContentFromSocketMessage(msg));
        }

        [Test]
        public void TestNullUser()
        {
            var msg = new MockUserMessage();
            msg.Channel = new MockTextChannel();
            msg.Author = null;
            msg.Content = "";

            Assert.Throws<ArgumentNullException>(() => GuildTextMessageTools.CreateGuildTextMessageContentFromSocketMessage(msg));
        }

        [Test]
        public void TestNullGuild()
        {
            var msg = new MockUserMessage();
            msg.Channel = new MockTextChannel();
            msg.Author = new MockGuildUser();
            msg.Content = "";

            Assert.Throws<ArgumentNullException>(() => GuildTextMessageTools.CreateGuildTextMessageContentFromSocketMessage(msg));
        }

        private IMessage CreateMockMsg()
        {
            var dm = new MockUserMessage();
            var channel = new MockTextChannel();
            var author = new MockGuildUser();
            var guild = new MockGuild();

            dm.Content = "Hello";
            dm.Channel = channel;
            dm.Author = author;
            author.Guild = guild;

            return dm;
        }
    }
}
