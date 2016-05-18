using CoduranceTwitter.DAL;
using CoduranceTwitter.Model.Messages;
using CoduranceTwitter.Model.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoduranceTwitter.Tests.Model.Messages
{
    [TestClass]
    public class CommandPostTests : BaseTest
    {
        [TestMethod]
        public void CommandPost_Message()
        {
            var memoryMessageRepository = new MemoryMessageRepository();
            var memoryUserRepository = new MemoryUserRepository();
            string text = "Alice -> Hello Bob";
            var commandPost = new CommandPost(memoryMessageRepository, memoryUserRepository);
            commandPost.Process(text);

            User user = memoryUserRepository.Get("Alice");
            var message = memoryMessageRepository.GetByUser(user);
            Assert.AreEqual("Alice", user.Username);
            Assert.AreEqual("Hello Bob", message.Text);
        }

        [TestMethod]
        public void CommandPost_NewUser()
        {
            var memoryMessageRepository = new MemoryMessageRepository();
            var memoryUserRepository = new MemoryUserRepository();
            string text = "Alice -> Hello Bob";
            var commandPost = new CommandPost(memoryMessageRepository, memoryUserRepository);
            commandPost.Process(text);

            var user = memoryUserRepository.Get("Alice");
            Assert.IsNotNull(user);
        }
    }
}
