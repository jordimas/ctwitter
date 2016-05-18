using System;
using CoduranceTwitter.DAL;
using CoduranceTwitter.Model.Messages;
using CoduranceTwitter.Model.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoduranceTwitter.Tests.Model.Messages
{
    [TestClass]
    public class CommandReadTests : BaseTest
    {
        readonly string TEST_USER1 = "test-user1";
        readonly string TEST_TEXT1 = "test-text1";
        readonly string TEST_TEXT2 = "test-text2";

        [TestMethod]
        public void CommandRead_NoMessage()
        {
            var memoryMessageRepository = new MemoryMessageRepository();
            var memoryUserRepository = new MemoryUserRepository();
            var commandRead = new CommandRead(memoryMessageRepository, memoryUserRepository);

            var user = new User(TEST_USER1);
            memoryUserRepository.Add(user);

            commandRead.Process(TEST_USER1);
            var messages = commandRead.Messages;
            Assert.AreEqual(0, messages.Count);
        }

        [TestMethod]
        public void CommandRead_OneMessage()
        {
            var memoryMessageRepository = new MemoryMessageRepository();
            var memoryUserRepository = new MemoryUserRepository();
            var commandRead = new CommandRead(memoryMessageRepository, memoryUserRepository);

            var user = new User(TEST_USER1);
            var message = new Message() { Text = TEST_TEXT1, User = user };
            memoryUserRepository.Add(user);
            memoryMessageRepository.Add(message);

            commandRead.Process(TEST_USER1);
            var messages = commandRead.Messages;
            Assert.AreEqual(1, messages.Count);
            Assert.AreEqual(TEST_USER1, messages[0].User.Username);
        }
        
        [TestMethod]
        public void CommandRead_Sorted()
        {
            var memoryMessageRepository = new MemoryMessageRepository();
            var memoryUserRepository = new MemoryUserRepository();
            var commandRead = new CommandRead(memoryMessageRepository, memoryUserRepository);

            DateTime now = DateTime.Now;
            var user1 = new User(TEST_USER1);
            var message1 = new Message() { Text = TEST_TEXT1, User = user1, Timespan = now};
            var message2 = new Message() { Text = TEST_TEXT2, User = user1, Timespan = now.AddMinutes(1) };
            memoryUserRepository.Add(user1);
            memoryMessageRepository.Add(message1);
            memoryMessageRepository.Add(message2);

            commandRead.Process(TEST_USER1);
            var messages = commandRead.Messages;

            Assert.AreEqual(messages[0].Text, TEST_TEXT2);
            Assert.AreEqual(messages[1].Text, TEST_TEXT1);
        }
    }
}
