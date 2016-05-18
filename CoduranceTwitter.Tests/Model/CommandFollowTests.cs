using CoduranceTwitter.DAL;
using CoduranceTwitter.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoduranceTwitter.Tests.Model
{
    [TestClass]
    public class CommandFollowTests : BaseTest
    {
        [TestMethod]
        public void CommandFollow_OneUser()
        {
            var memoryWallRepository = new MemoryWallRepository();
            var memoryUserRepository = new MemoryUserRepository();

            var userCharlie = new User("Charlie");
            var userAlicie = new User("Alice");
            memoryUserRepository.Add(userCharlie);
            memoryUserRepository.Add(userAlicie);

            string text = "Charlie follows Alice";
            var commandPost = new CommandFollow(memoryWallRepository, memoryUserRepository);
            commandPost.Process(text);

            var user = memoryUserRepository.Get("Charlie");
            var wall = memoryWallRepository.GetByUser(user);
            Assert.AreEqual("Charlie", wall.Username.Username);
        }
    }
}
