using System.Collections.Generic;
using System.Linq;
using CoduranceTwitter.Model.Messages;
using CoduranceTwitter.Model.Users;

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
                UserId = message.User.Id.Value,
            };
            _messages.Add(messageMemoryDb);
        }

        public Message GetByUser(User user)
        {
            if (user == null) return null;
            var message = _messages.Find(x => x.UserId == user.Id);
            return FromMessageMemoryDb(message, user);
        }

        public List<Message> GetAllByUser(User user)
        {
            if (user == null) return new List<Message>();

            var messagesDb = _messages.FindAll(x => x.UserId == user.Id);
            return messagesDb.Select(message => FromMessageMemoryDb(message, user)).ToList();
        }

        private Message FromMessageMemoryDb(MessageMemoryRow memory, User user)
        {
            return new Message()
            {
                Timespan = memory.Timespan,
                Text = memory.Text,
                User = user
            };
        }
    }
}
