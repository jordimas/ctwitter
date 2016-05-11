using CoduranceTwitter.DAL;
using System;
using System.Collections.Generic;

namespace CoduranceTwitter.Model
{
    public class MessageService
    {
        private IRepository _repository;

        public MessageService(IRepository repository)
        {
            _repository = repository;
        }

        public void PostMessage(string username, string text)
        {
            PostMessage(username, text, DateTime.Now);
        }

        public void PostMessage(string username, string text, DateTime datetime)
        {
            Message messageDto = new Message()
            {
                Username = username,
                Text = text,
                Timespan = datetime
            };

            _repository.CreateMessage(messageDto);
        }
        
        public List<Message> Read(string username)
        {
            var messages = _repository.GetMessages(username);
            messages.Sort((x, y) => y.Timespan.CompareTo(x.Timespan));
            return messages;
        }
    }
}
