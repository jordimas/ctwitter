using CoduranceTwitter.DAL;
using CoduranceTwitter.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoduranceTwitter.Tests.Model
{
    [TestClass]
    public class UserTest
    {
        readonly string TEST_USER = "test-user";

        [TestMethod]
        public void GetOrCreateUser_NewUser()
        {
            IRepository<User> repository = new MemoryUserRepository();
            UserService user = new UserService(repository);
            var userDto = user.GetOrCreateUser(TEST_USER);

            Assert.AreEqual(userDto.Username, TEST_USER);
        }

        [TestMethod]
        public void GetOrCreateUser_ExistingUser()
        {
            IRepository<User> repository = new MemoryUserRepository();
            User user = new User(TEST_USER);
            repository.Add(user); 

            UserService userService = new UserService(repository);
            var userDto = userService.GetOrCreateUser(TEST_USER);

            Assert.AreEqual(userDto.Username, TEST_USER);
        }
    }
}
