using System;
using CoduranceTwitter.DAL;
using CoduranceTwitter.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoduranceTwitter.Tests.Model
{
    [TestClass]
    public class WallTests
    {
        [TestMethod]
        public void Subscribe_OneUser()
        {
            string TEST_USER = "test-user1";
            string TEST_USERFOLLOW = "test-user2";
            IRepository<Message> messageRepository = new MemoryMessageRepository();
            IRepository<Wall> wallRepository = new MemoryWallRepository();
            IRepository<User> userRepository = new MemoryUserRepository();

            WallService wall = new WallService(wallRepository, messageRepository);

            userRepository.Add(new User(TEST_USER));
            userRepository.Add(new User(TEST_USERFOLLOW));

            wall.Follow(TEST_USER, TEST_USERFOLLOW);
            var subscriptions = wallRepository.GetAll(TEST_USER);
            Assert.AreEqual(subscriptions.Count, 1);
        }

        [TestMethod]
        public void Read_FollowingNoOne()
        {
            string TEST_USER = "test-user";
            string TEST_MESSAGE = "test-message";
            IRepository<Message> messageRepository = new MemoryMessageRepository();
            IRepository<Wall> wallRepository = new MemoryWallRepository();
            IRepository<User> userRepository = new MemoryUserRepository();
            WallService wall = new WallService(wallRepository, messageRepository);

            userRepository.Add(new User(TEST_USER));
            
            Message message= new Message()
            {
                Username = TEST_USER,
                Text = TEST_MESSAGE,
                Timespan = DateTime.Now
            };

            messageRepository.Add(message);
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
            IRepository<Message> messageRepository = new MemoryMessageRepository();
            IRepository<Wall> wallRepository = new MemoryWallRepository();
            IRepository<User> userRepository = new MemoryUserRepository();
            WallService wall = new WallService(wallRepository, messageRepository);

            userRepository.Add(new User(TEST_USER));
            userRepository.Add(new User(TEST_USER_FOLLOW));

            Message message1 = new Message()
            {
                Username = TEST_USER,
                Text = TEST_MESSAGE,
                Timespan = DateTime.Now
            };

            Message message2 = new Message()
            {
                Username = TEST_USER_FOLLOW,
                Text = TEST_MESSAGE_FOLLOW,
                Timespan = DateTime.Now
            };

            messageRepository.Add(message1);
            messageRepository.Add(message2);
            var subscription = new Wall()
            {
                Username = TEST_USER,
                FollowUser = TEST_USER_FOLLOW
            };
            wallRepository.Add(subscription);

            var messages = wall.Read(TEST_USER);
            Assert.AreEqual(messages.Count, 2);
            Assert.AreEqual(messages[0].Text, TEST_MESSAGE);
            Assert.AreEqual(messages[1].Text, TEST_MESSAGE_FOLLOW);
        }
    }

}
