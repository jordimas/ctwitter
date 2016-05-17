using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoduranceTwitter.DAL;
using CoduranceTwitter.Model;

namespace CoduranceTwitter.Tests
{
    [TestClass]
    public class CommandReadTests
    {
       
        readonly string TEST_USER1 = "test-user1";
        //readonly string TEST_USER2 = "test-user2";
        readonly string TEST_TEXT1 = "test-text1";
        //readonly string TEST_TEXT2 = "test-text2";

        [TestInitialize]
        public void Ssetup()
        {
            MemoryRepository.Init();
        }

        [TestMethod]
        public void PostMessage_OneMessage()
        {
            var memoryMessageRepository = new MemoryMessageRepository();
            var memoryUserRepository = new MemoryUserRepository();

            var user = new User(TEST_USER1);
            var message = new Message()
            {
                Text = TEST_TEXT1,
                Username = user,
            };
            memoryUserRepository.Add(user);
            memoryMessageRepository.Add(message);

            var commandread = new CommandRead(memoryMessageRepository, memoryUserRepository);
            commandread.Process(TEST_USER1);
        }

        /*
        [TestMethod]
        public void PostMessage_CreatesUser()
        {
            IRepository<Message> repository = new MemoryMessageRepository();
            IRepository<User> userRepository = new MemoryUserRepository();
            MessageService message = new MessageService(repository, userRepository);
            message.PostMessage(TEST_USER1, TEST_TEXT1);

            var user = userRepository.Get(TEST_USER1);
            Assert.AreEqual(user.Username, TEST_USER1);
        }

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
