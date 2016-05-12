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
            IRepository<User> repository = new MemoryUserRepository();
            UserService user = new UserService(repository);
            var userDto = user.GetOrCreateUser(TEST_USER);

            Assert.AreEqual(userDto.Username, TEST_USER);
        }

        [TestMethod]
        public void GetOrCreateUser_ExistingUser()
        {
            string TEST_USER = "test-user";
            IRepository<User> repository = new MemoryUserRepository();
            User user = new User(TEST_USER);
            repository.Add(user); 

            UserService userService = new UserService(repository);
            var userDto = userService.GetOrCreateUser(TEST_USER);

            Assert.AreEqual(userDto.Username, TEST_USER);
        }
    }
}
