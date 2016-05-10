using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoduranceTwitter.DAL;
using CoduranceTwitter.Model;
using System.Threading;

namespace CoduranceTwitter.Tests.Model
{
    [TestClass]
    public class MessageTest
    {
        [TestMethod]
        public void PostMessage_OneMessage()
        {
            string TEST_USER = "test-user";
            string TEST_TEXT = "test-text";

            IRepository repository = new MemoryRepository();
            Message message = new Message(repository);
            message.PostMessage(TEST_USER, TEST_TEXT);

            var messages = message.Read(TEST_USER);
            Assert.AreEqual(messages.Count, 1);
            Assert.AreEqual(messages[0].Text, TEST_TEXT);
            Assert.AreEqual(messages[0].Username, TEST_USER);
        }

        [TestMethod]
        public void Read_PostMessage_Sorted()
        {
            string TEST_USER = "test-user";
            string TEST_TEXT1 = "test-text1";
            string TEST_TEXT2 = "test-text2";

            IRepository repository = new MemoryRepository();
            Message message = new Message(repository);
            message.PostMessage(TEST_USER, TEST_TEXT1);
            Thread.Sleep(2000);
            message.PostMessage(TEST_USER, TEST_TEXT2);

            var messages = message.Read(TEST_USER);
            Assert.AreEqual(messages[0].Text, TEST_TEXT2);
            Assert.AreEqual(messages[1].Text, TEST_TEXT1);
        }

        [TestMethod]
        public void Read_PostMessage_NoMessage()
        {
            string TEST_USER = "test-user";
           
            IRepository repository = new MemoryRepository();
            Message message = new Message(repository);
           
            var messages = message.Read(TEST_USER);
            Assert.AreEqual(messages.Count, 0);
        }
    }
}
