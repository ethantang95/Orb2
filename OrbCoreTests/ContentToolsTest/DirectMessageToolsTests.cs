using Discord;
using Discord.WebSocket;
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
    class DirectMessageToolsTests
    {
        [Test]
        public void TestValidatingDMContent()
        {
            var dm = CreateMockDM();

            var result = DirectMessageTools.IsSocketMessageDirectMessage(dm);

            Assert.True(result);
        }

        [Test]
        public void TestCreatingDMContent()
        {
            var dm = CreateMockDM();

            var result = DirectMessageTools.CreateDirectMessageContentFromSocketMessage(dm);

            Assert.AreEqual(dm, result.MessageInfo);
            Assert.AreEqual(dm.Author, result.User);
            Assert.AreEqual(dm.Content, result.MessageText);
            Assert.AreEqual(dm.Channel, result.Channel);
        }

        [Test]
        public void TestMessageNotDM()
        {
            var dm = new MockUserMessage();
            dm.Channel = new MockTextChannel();
            dm.Author = new MockGuildUser();
            dm.Content = "";

            Assert.Throws<InvalidCastException>(() => DirectMessageTools.CreateDirectMessageContentFromSocketMessage(dm));
        }

        [Test]
        public void TestMessageNotUserMessage()
        {
            var dm = new MockSystemMessage();
            dm.Channel = new MockTextChannel();
            dm.Author = new MockUser();
            dm.Content = "";

            Assert.Throws<InvalidCastException>(() => DirectMessageTools.CreateDirectMessageContentFromSocketMessage(dm));
        }

        [Test]
        public void TestMessageNull()
        {
            Assert.Throws<ArgumentNullException>(() => DirectMessageTools.CreateDirectMessageContentFromSocketMessage(null));
        }

        [Test]
        public void TestMessageContentNull()
        {
            var dm = new MockUserMessage();
            dm.Author = new MockUser();
            dm.Channel = new MockDMChannel();

            Assert.Throws<ArgumentNullException>(() => DirectMessageTools.CreateDirectMessageContentFromSocketMessage(dm));
        }

        [Test]
        public void TestChannelNull()
        {
            var dm = new MockUserMessage();
            dm.Author = new MockUser();
            dm.Content = "";

            Assert.Throws<ArgumentNullException>(() => DirectMessageTools.CreateDirectMessageContentFromSocketMessage(dm));
        }

        [Test]
        public void TestUserNull()
        {
            var dm = new MockUserMessage();
            dm.Channel = new MockDMChannel();
            dm.Content = "";

            Assert.Throws<ArgumentNullException>(() => DirectMessageTools.CreateDirectMessageContentFromSocketMessage(dm));
        }

        private IMessage CreateMockDM()
        {
            var dm = new MockUserMessage();
            var channel = new MockDMChannel();
            var author = new MockUser();

            dm.Content = "Hello";
            dm.Channel = channel;
            dm.Author = author;

            return dm;
        }
    }
}
