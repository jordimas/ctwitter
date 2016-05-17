using CoduranceTwitter.Model;
using System.Collections.Generic;
using System;

namespace CoduranceTwitter.DAL
{
    public class MemoryMessageRepository : MemoryRepository, IMessageRepository 
    {
        public void Add(Message message)
        {
            var messageMemoryDb = new MessageMemoryRow()
            {
                Text = message.Text,
                Timespan = message.Timespan,
                UserId = message.Username.Id.Value,
            };
            _messages.Add(messageMemoryDb);
        }

        public Message GetByUser(User user)
        {
            var message = _messages.Find(x => x.UserId == user.Id);
            return FromMessageMemoryDb(message, user);
        }

        public List<Message> GetAllByUser(User user)
        {
            List<Message> messages = new List<Message>();
            var messagesDb = _messages.FindAll(x => x.UserId == user.Id);
            foreach (var message in messagesDb)
            {
                messages.Add(FromMessageMemoryDb(message, user));
            }
            return messages;
        }

        private Message FromMessageMemoryDb(MessageMemoryRow memory, User user)
        {
            return new Message()
            {
                Timespan = memory.Timespan,
                Text = memory.Text,
                Username = user
            };
        }
    }
}
