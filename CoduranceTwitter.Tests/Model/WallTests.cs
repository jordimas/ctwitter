using CoduranceTwitter.DAL;
using CoduranceTwitter.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoduranceTwitter.Tests
{
    [TestClass]
    public class WallTests
    {
        [TestMethod]
        public void Subscribe_OneUser()
        {
            string TEST_USER = "test-user1";
            string TEST_USERFOLLOW = "test-user2";
            IRepository repository = new MemoryRepository();
            Wall wall = new Wall(repository);

            repository.CreateUser(TEST_USER);
            repository.CreateUser(TEST_USERFOLLOW);

            wall.Subscribe(TEST_USER, TEST_USERFOLLOW);
            var subscriptions = repository.GetSubscriptions(TEST_USER);
            Assert.AreEqual(subscriptions.Count, 1);
        }

        [TestMethod]
        public void Read_NoFollowers()
        {
            string TEST_USER = "test-user1";
            string TEST_MESSAGE = "test-message";
            IRepository repository = new MemoryRepository();
            repository.CreateUser(TEST_USER);
            repository.CreateMessage(TEST_USER, TEST_MESSAGE);

            Wall wall = new Wall(repository);
            var messages = wall.Read(TEST_USER);
            Assert.AreEqual(messages.Count, 1);
            Assert.AreEqual(messages[0].Text, TEST_MESSAGE);
        }
    }

}
