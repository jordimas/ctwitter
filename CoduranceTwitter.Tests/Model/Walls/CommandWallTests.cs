using System;
using CoduranceTwitter.DAL;
using CoduranceTwitter.Model.Messages;
using CoduranceTwitter.Model.Users;
using CoduranceTwitter.Model.Walls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoduranceTwitter.Tests.Model.Walls
{
    [TestClass]
    public class CommandWallTests : BaseTest
    {
        readonly string TEST_USER1 = "test-user1";
        readonly string TEST_USER2 = "test-user2";
        readonly string TEST_TEXT1 = "test-text1";
        readonly string TEST_TEXT2 = "test-text2";

        [TestMethod]
        public void CommandWall_OneUser()
        {
            var memoryWallRepository = new MemoryWallRepository();
            var memoryUserRepository = new MemoryUserRepository();
            var memoryMessageRepository = new MemoryMessageRepository();

            var user1 = new User(TEST_USER1);
            var user2 = new User(TEST_USER2);
            memoryUserRepository.Add(user1);
            memoryUserRepository.Add(user2);

            DateTime now = DateTime.Now;
            var message1 = new Message() { Text = TEST_TEXT1, User = user1, Timespan = now.AddMinutes(1)};
            memoryMessageRepository.Add(message1);

            var message2 = new Message() { Text = TEST_TEXT2, User = user2, Timespan = now};
            memoryMessageRepository.Add(message2);

            var wall = new Wall { User =  user1, FollowUser = user2};
            memoryWallRepository.Add(wall);

            string text = $"{TEST_USER1} wall";
            var commandPost = new CommandWall(memoryWallRepository, memoryUserRepository, memoryMessageRepository);
            commandPost.Process(text);
            var messages = commandPost.Messages;

            Assert.AreEqual(2, messages.Count);
            Assert.AreEqual(TEST_USER1, messages[0].User.Username);
            Assert.AreEqual(TEST_USER2, messages[1].User.Username);
        }
    }
}
