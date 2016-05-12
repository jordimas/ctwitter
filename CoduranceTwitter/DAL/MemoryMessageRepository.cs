using CoduranceTwitter.Model;
using System;
using System.Collections.Generic;

namespace CoduranceTwitter.DAL
{
    public class MemoryMessageRepository : IRepository<Message>
    {
        private List<Message> _messages = new List<Message>();
        private int _last_message_id = 0;

        public void Add(Message message)
        {
            message.Id = _last_message_id;
            _messages.Add(message);
            _last_message_id++;
        }

        public Message Get(string username)
        {
            return _messages.Find(x => x.Username == username);
        }

        public List<Message> GetAll(string username)
        {
            return _messages.FindAll(x => x.Username == username);
        }
    }
}
