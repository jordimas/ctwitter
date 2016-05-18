using CoduranceTwitter.DAL;
using CoduranceTwitter.Model.Messages;
using CoduranceTwitter.Model.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoduranceTwitter.Tests.Model.Messages
{
    [TestClass]
    public class CommandPostTests : BaseTest
    {
        readonly string TEST_USER1 = "test-user1";
        readonly string TEST_TEXT1 = "test-text1";
        
        [TestMethod]
        public void CommandPost_Message()
        {
            var memoryMessageRepository = new MemoryMessageRepository();
            var memoryUserRepository = new MemoryUserRepository();
            string text = $"{TEST_USER1} -> {TEST_TEXT1}";
            var commandPost = new CommandPost(memoryMessageRepository, memoryUserRepository);
            commandPost.Process(text);

            User user = memoryUserRepository.Get(TEST_USER1);
            var message = memoryMessageRepository.GetByUser(user);
            Assert.AreEqual(TEST_USER1, user.Username);
            Assert.AreEqual(TEST_TEXT1, message.Text);
        }

        [TestMethod]
        public void CommandPost_NewUser()
        {
            var memoryMessageRepository = new MemoryMessageRepository();
            var memoryUserRepository = new MemoryUserRepository();
            string text = $"{TEST_USER1} -> {TEST_TEXT1}";
            var commandPost = new CommandPost(memoryMessageRepository, memoryUserRepository);
            commandPost.Process(text);

            var user = memoryUserRepository.Get(TEST_USER1);
            Assert.IsNotNull(user);
        }
    }
}
