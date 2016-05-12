using CoduranceTwitter.DAL;
using System;
using System.Collections.Generic;

namespace CoduranceTwitter.Model
{
    public class MessageService
    {
        private IRepository <Message> _repository;

        public MessageService(IRepository<Message> repository)
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

            _repository.Add(messageDto);
        }
        
        public List<Message> Read(string username)
        {
            var messages = _repository.GetAll(username);
            messages.Sort((x, y) => y.Timespan.CompareTo(x.Timespan));
            return messages;
        }
    }
}
