using System;
using CoduranceTwitter.DAL;
using CoduranceTwitter.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoduranceTwitter.Tests.Model
{
    [TestClass]
    public class WallTests
    {
        string TEST_USER = "test-user1";
        string TEST_USER_FOLLOW = "test-user-follow";
        string TEST_MESSAGE = "test-message";
        string TEST_MESSAGE_FOLLOW = "test-message-follow";

        [TestMethod]
        public void Subscribe_OneUser()
        {
            IRepository<Message> messageRepository = new MemoryMessageRepository();
            IRepository<Wall> wallRepository = new MemoryWallRepository();
            IRepository<User> userRepository = new MemoryUserRepository();

            WallService wall = new WallService(wallRepository, messageRepository);

            userRepository.Add(new User(TEST_USER));
            userRepository.Add(new User(TEST_USER_FOLLOW));

            wall.Follow(TEST_USER, TEST_USER_FOLLOW);
            var subscriptions = wallRepository.GetAll(TEST_USER);
            Assert.AreEqual(subscriptions.Count, 1);
        }

        [TestMethod]
        public void Read_FollowingNoOne()
        {
            IRepository<Message> messageRepository = new MemoryMessageRepository();
            IRepository<Wall> wallRepository = new MemoryWallRepository();
            IRepository<User> userRepository = new MemoryUserRepository();
            WallService wall = new WallService(wallRepository, messageRepository);

            userRepository.Add(new User(TEST_USER));
            
            Message message= new Message() { Username = TEST_USER, Text = TEST_MESSAGE, Timespan = DateTime.Now};
            messageRepository.Add(message);
            var messages = wall.Read(TEST_USER);
            Assert.AreEqual(messages.Count, 1);
            Assert.AreEqual(messages[0].Text, TEST_MESSAGE);
        }

        [TestMethod]
        public void Read_FollowingOneUser()
        {
            IRepository<Message> messageRepository = new MemoryMessageRepository();
            IRepository<Wall> wallRepository = new MemoryWallRepository();
            IRepository<User> userRepository = new MemoryUserRepository();
            WallService wall = new WallService(wallRepository, messageRepository);

            userRepository.Add(new User(TEST_USER));
            userRepository.Add(new User(TEST_USER_FOLLOW));

            DateTime dt = DateTime.Now;
            Message message1 = new Message() { Username = TEST_USER, Text = TEST_MESSAGE, Timespan = dt };
            Message message2 = new Message() { Username = TEST_USER_FOLLOW, Text = TEST_MESSAGE_FOLLOW, Timespan = dt.AddHours(1)};

            messageRepository.Add(message1);
            messageRepository.Add(message2);
            var subscription = new Wall() { Username = TEST_USER, FollowUser = TEST_USER_FOLLOW };
            wallRepository.Add(subscription);

            var messages = wall.Read(TEST_USER);
            Assert.AreEqual(messages.Count, 2);
            Assert.AreEqual(messages[0].Text, TEST_MESSAGE_FOLLOW);
            Assert.AreEqual(messages[1].Text, TEST_MESSAGE);
        }
    }

}
