using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoduranceTwitter.DAL;

namespace CoduranceTwitter.Tests
{
    [TestClass]
    public class CommandPostTests
    {
        [TestMethod]
        public void CommandPost_Message()
        {
            var memoryMessageRepository = new MemoryMessageRepository();
            var memoryUserRepository = new MemoryUserRepository();
            string text = "Alice -> Hello Bob";
            var commandPost = new CommandPost(memoryMessageRepository, memoryUserRepository);
            commandPost.Process(text);

            var message = memoryMessageRepository.Get("Alice");
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
