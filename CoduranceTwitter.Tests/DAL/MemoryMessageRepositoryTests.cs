using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoduranceTwitter.DAL;
using CoduranceTwitter.Model;
using System;

namespace CoduranceTwitter.Tests.Model
{
    [TestClass]
    public class MemoryMessageRepositoryTests
    {
        readonly string TEST_USER1 = "test-user1";
        readonly string TEST_USER2 = "test-user2";
        readonly string TEST_TEXT1 = "test-text1";
        readonly string TEST_TEXT2 = "test-text2";

        [TestMethod]
        public void PostMessage_OneMessage()
        {
            IRepository<Message> repository = new MemoryMessageRepository();

            Message message = new Message()
            {
                Text = TEST_TEXT1,
                Username = new User(TEST_USER1)
            };

            repository.Add(message);
            var messages = repository.GetAll(TEST_USER1);
            Assert.AreEqual(messages.Count, 1);
            Assert.AreEqual(messages[0].Text, TEST_TEXT1);
            Assert.AreEqual(messages[0].Username.Username, TEST_USER1);
        }

      /*

        [TestMethod]
        public void Read_OnlyForMe()
        {
            IRepository<Message> repository = new MemoryMessageRepository();
            IRepository<User> userRepository = new MemoryUserRepository();
            MessageService message = new MessageService(repository, userRepository);
            message.PostMessage(TEST_USER1, TEST_TEXT1);
            message.PostMessage(TEST_USER2, TEST_TEXT2);

            var messages = message.Read(TEST_USER1);
            Assert.AreEqual(messages.Count, 1);
            Assert.AreEqual(messages[0].Text, TEST_TEXT1);
        }

        [TestMethod]
        public void Read_Sorted()
        {
            IRepository<Message> repository = new MemoryMessageRepository();
            IRepository<User> userRepository = new MemoryUserRepository();
            MessageService message = new MessageService(repository, userRepository);
            DateTime now = DateTime.Now;
            message.PostMessage(new User(TEST_USER1), TEST_TEXT1, now);
            message.PostMessage(new User(TEST_USER1), TEST_TEXT2, now.AddMinutes(1));

            var messages = message.Read(TEST_USER1);
            Assert.AreEqual(messages.Count, 2);
            Assert.AreEqual(messages[0].Text, TEST_TEXT2);
            Assert.AreEqual(messages[1].Text, TEST_TEXT1);
        }

        [TestMethod]
        public void Read_NoMessage()
        {
            IRepository<Message> repository = new MemoryMessageRepository();
            IRepository<User> userRepository = new MemoryUserRepository();
            MessageService message = new MessageService(repository, userRepository);

            var messages = message.Read(TEST_USER1);
            Assert.AreEqual(messages.Count, 0);
        }
        */
    }
}
