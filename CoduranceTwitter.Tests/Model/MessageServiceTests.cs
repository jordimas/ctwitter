using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoduranceTwitter.DAL;
using CoduranceTwitter.Model;
using System;

namespace CoduranceTwitter.Tests.Model
{
    [TestClass]
    public class MessageTest
    {
        string TEST_USER1 = "test-user1";
        string TEST_USER2 = "test-user2";
        string TEST_TEXT1 = "test-text1";
        string TEST_TEXT2 = "test-text2";

        [TestMethod]
        public void PostMessage_OneMessage()
        {
            IRepository<Message> repository = new MemoryMessageRepository();
            MessageService message = new MessageService(repository);
            message.PostMessage(TEST_USER1, TEST_TEXT1);

            var messages = message.Read(TEST_USER1);
            Assert.AreEqual(messages.Count, 1);
            Assert.AreEqual(messages[0].Text, TEST_TEXT1);
            Assert.AreEqual(messages[0].Username, TEST_USER1);
        }

        [TestMethod]
        public void Read_OnlyForMe()
        {
            IRepository<Message> repository = new MemoryMessageRepository();
            MessageService message = new MessageService(repository);
            message.PostMessage(TEST_USER1, TEST_TEXT1);
            message.PostMessage(TEST_USER2, TEST_TEXT2);

            var messages = message.Read(TEST_USER1);
            Assert.AreEqual(messages.Count, 1);
            Assert.AreEqual(messages[0].Text, TEST_TEXT1);
        }

        [TestMethod]
        public void Read_Sorted()
        {
            IRepository<Message> repository = new MemoryMessageRepository();
            MessageService message = new MessageService(repository);
            DateTime now = DateTime.Now;
            message.PostMessage(TEST_USER1, TEST_TEXT1, now);
            message.PostMessage(TEST_USER1, TEST_TEXT2, now.AddMinutes(1));

            var messages = message.Read(TEST_USER1);
            Assert.AreEqual(messages.Count, 2);
            Assert.AreEqual(messages[0].Text, TEST_TEXT2);
            Assert.AreEqual(messages[1].Text, TEST_TEXT1);
        }

        [TestMethod]
        public void Read_NoMessage()
        {
            IRepository<Message> repository = new MemoryMessageRepository();
            MessageService message = new MessageService(repository);
           
            var messages = message.Read(TEST_USER1);
            Assert.AreEqual(messages.Count, 0);
        }
    }
}
