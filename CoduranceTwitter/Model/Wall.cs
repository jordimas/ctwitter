using CoduranceTwitter.DAL;
using System.Collections.Generic;

namespace CoduranceTwitter.Model
{
    public class Wall
    {

        private IRepository _repository;

        public Wall(IRepository repository)
        {
            _repository = repository;
        }

        public void Subscribe(string user, string followUser)
        {
            _repository.CreateSubscription(user, followUser);
        }

        public List<MessageDto> Read(string username)
        {
            var messages =_repository.GetMessages(username);
            var subscriptions = _repository.GetSubscriptions(username);

            foreach (var user in subscriptions)
            {
                var subcriptionMessages = _repository.GetMessages(user);
                messages.AddRange(subcriptionMessages);
            }
            
            return messages;
        }
    }
}
