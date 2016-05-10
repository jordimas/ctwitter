using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoduranceTwitter.DAL;
using CoduranceTwitter.Model;

namespace CoduranceTwitter.Tests
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void GetOrCreateUser_NewUser()
        {
            string TEST_USER = "test-user";
            IRepository  repository = new MemoryRepository();
            User user = new User(repository);
            var userDto = user.GetOrCreateUser(TEST_USER);

            Assert.AreEqual(userDto.Username, TEST_USER);
        }

        [TestMethod]
        public void GetOrCreateUser_ExistingUser()
        {
            string TEST_USER = "test-user";
            IRepository repository = new MemoryRepository();
            int id = repository.CreateUser(TEST_USER); 

            User user = new User(repository);
            var userDto = user.GetOrCreateUser(TEST_USER);

            Assert.AreEqual(userDto.Username, TEST_USER);
            Assert.AreEqual(userDto.Id, id);
        }
    }
}
