using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoduranceTwitter.DAL;

namespace CoduranceTwitter.Tests
{
    [TestClass]
    public class CommandFollowTests
    {
        [TestMethod]
        public void CommandFollow_OneUser()
        {
            var memoryWallRepository = new MemoryWallRepository();
            var memoryUserRepository = new MemoryUserRepository();

            string text = "Charlie follows Alice";
            var commandPost = new CommandFollow(memoryWallRepository, memoryUserRepository);
            commandPost.Process(text);

            var wall = memoryWallRepository.Get("Charlie");
            Assert.AreEqual("Charlie", wall.Username.Username);
        }
    }
}
