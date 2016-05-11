using CoduranceTwitter.DAL;
using CoduranceTwitter.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CoduranceTwitter.Tests
{
    [TestClass]
    public class WallTests
    {
        [TestMethod]
        public void Subscribe_OneUser()
        {
            string TEST_USER = "test-user1";
            string TEST_USERFOLLOW = "test-user2";
            IRepository repository = new MemoryRepository();
            Wall wall = new Wall(repository);

            repository.CreateUser(TEST_USER);
            repository.CreateUser(TEST_USERFOLLOW);

            wall.Subscribe(TEST_USER, TEST_USERFOLLOW);
            var subscriptions = repository.GetSubscriptions(TEST_USER);
            Assert.AreEqual(subscriptions.Count, 1);
        }

        [TestMethod]
        public void Read_FollowingNoOne()
        {
            string TEST_USER = "test-user";
            string TEST_MESSAGE = "test-message";
            IRepository repository = new MemoryRepository();
            repository.CreateUser(TEST_USER);
            

            Message messageDto = new Message()
            {
                Username = TEST_USER,
                Text = TEST_MESSAGE,
                Timespan = DateTime.Now
            };

            repository.CreateMessage(messageDto);

            Wall wall = new Wall(repository);
            var messages = wall.Read(TEST_USER);
            Assert.AreEqual(messages.Count, 1);
            Assert.AreEqual(messages[0].Text, TEST_MESSAGE);
        }

        [TestMethod]
        public void Read_FollowingOne()
        {
            string TEST_USER = "test-user1";
            string TEST_USER_FOLLOW = "test-user-follow";
            string TEST_MESSAGE = "test-message";
            string TEST_MESSAGE_FOLLOW = "test-message-follow";
            IRepository repository = new MemoryRepository();
            repository.CreateUser(TEST_USER);
            repository.CreateUser(TEST_USER_FOLLOW);

            Message messageDto1 = new Message()
            {
                Username = TEST_USER,
                Text = TEST_MESSAGE,
                Timespan = DateTime.Now
            };

            Message messageDto2 = new Message()
            {
                Username = TEST_USER_FOLLOW,
                Text = TEST_MESSAGE_FOLLOW,
                Timespan = DateTime.Now
            };

            repository.CreateMessage(messageDto1);
            repository.CreateMessage(messageDto2);
            repository.CreateSubscription(TEST_USER, TEST_USER_FOLLOW);

            Wall wall = new Wall(repository);
            var messages = wall.Read(TEST_USER);
            Assert.AreEqual(messages.Count, 2);
            Assert.AreEqual(messages[0].Text, TEST_MESSAGE);
            Assert.AreEqual(messages[1].Text, TEST_MESSAGE_FOLLOW);
        }
    }

}
