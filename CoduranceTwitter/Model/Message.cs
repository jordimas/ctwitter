using CoduranceTwitter.DAL;
using System;
using System.Collections.Generic;

namespace CoduranceTwitter.Model
{
    public class Message
    {
        private IRepository _repository;

        public Message(IRepository repository)
        {
            _repository = repository;
        }

        public void PostMessage(string username, string text)
        {
            _repository.CreateMessage(username, text);
        }
        
        public List<MessageDto> Read(string username)
        {
            var messages = _repository.GetMessages(username);
            messages.Sort((x, y) => y.Timespan.CompareTo(x.Timespan));
            return messages;
        }
    }
}
