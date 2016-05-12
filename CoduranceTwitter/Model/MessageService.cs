using CoduranceTwitter.DAL;
using System;
using System.Collections.Generic;

namespace CoduranceTwitter.Model
{
    public class MessageService
    {
        private readonly IRepository <Message> _repository;
        private readonly IRepository<User> _userRepository;

        public MessageService(IRepository<Message> repository, IRepository<User> userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public void PostMessage(string username, string text)
        {
            UserService userService = new UserService(_userRepository);
            User user = userService.GetOrCreateUser(username);
            PostMessage(user, text, DateTime.Now);
        }

        public void PostMessage(User user, string text, DateTime datetime)
        {
            Message messageDto = new Message()
            {
                Username = user,
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
