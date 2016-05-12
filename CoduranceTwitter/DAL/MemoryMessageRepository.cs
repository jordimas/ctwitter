using CoduranceTwitter.Model;
using System.Collections.Generic;

namespace CoduranceTwitter.DAL
{
    public class MemoryMessageRepository : IRepository<Message>
    {
        private readonly List<Message> _messages = new List<Message>();

        public void Add(Message message)
        {
            _messages.Add(message);
        }

        public Message Get(string username)
        {
            return _messages.Find(x => x.Username.Username == username);
        }

        public List<Message> GetAll(string username)
        {
            return _messages.FindAll(x => x.Username.Username == username);
        }
    }
}
