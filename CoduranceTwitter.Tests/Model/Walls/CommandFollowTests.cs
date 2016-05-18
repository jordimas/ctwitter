using CoduranceTwitter.DAL;
using CoduranceTwitter.Model.Users;
using CoduranceTwitter.Model.Walls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoduranceTwitter.Tests.Model.Walls
{
    [TestClass]
    public class CommandFollowTests : BaseTest
    {
        readonly string TEST_USER1 = "test-user1";
        readonly string TEST_USER2 = "test-user2";

        [TestMethod]
        public void CommandFollow_OneUser()
        {
            var memoryWallRepository = new MemoryWallRepository();
            var memoryUserRepository = new MemoryUserRepository();

            var userCharlie = new User(TEST_USER1);
            var userAlicie = new User(TEST_USER2);
            memoryUserRepository.Add(userCharlie);
            memoryUserRepository.Add(userAlicie);

            string text = $"{TEST_USER1} follows {TEST_USER2}";
            var commandPost = new CommandFollow(memoryWallRepository, memoryUserRepository);
            commandPost.Process(text);

            var user = memoryUserRepository.Get(TEST_USER1);
            var wall = memoryWallRepository.GetByUser(user);
            Assert.AreEqual(TEST_USER1, wall.Username.Username);
        }
    }
}
