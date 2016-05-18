﻿using CoduranceTwitter.DAL;
using CoduranceTwitter.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoduranceTwitter.Tests.DAL
{
    [TestClass]
    public class MemoryMessageRepositoryTests : BaseTest
    {
        readonly string TEST_USER1 = "test-user1";
        readonly string TEST_TEXT1 = "test-text1";
        
        [TestMethod]
        public void PostMessage_OneMessage()
        {
            IMessageRepository repository = new MemoryMessageRepository();
            IUserRepository userRepository = new MemoryUserRepository();
            
            User user = new User(TEST_USER1);
            userRepository.Add(user);

            Message message = new Message()
            {
                Text = TEST_TEXT1,
                Username = user
            };

            repository.Add(message);
            var messages = repository.GetAllByUser(user);
            Assert.AreEqual(messages.Count, 1);
            Assert.AreEqual(messages[0].Text, TEST_TEXT1);
            Assert.AreEqual(messages[0].Username.Username, TEST_USER1);
        }

    }
}