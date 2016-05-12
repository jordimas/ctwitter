using CoduranceTwitter.DAL;
using System.Collections.Generic;

namespace CoduranceTwitter.Model
{
    public class WallService
    {
        private readonly IRepository<Wall> _wallRepository;
        private readonly IRepository<Message> _messageRepository;

        public WallService(IRepository<Wall> wallRepository, IRepository<Message> messageRepository)
        {
            _wallRepository = wallRepository;
            _messageRepository = messageRepository;
        }

        public void Subscribe(string user, string followUser)
        {
            var wall = new Wall()
            {
                Username = user,
                FollowUser = followUser
            };
            _wallRepository.Add(wall);
        }

        public List<Message> Read(string username)
        {
            var messages =_messageRepository.GetAll(username);
            var subscriptions = _wallRepository.GetAll(username);

            foreach (var user in subscriptions)
            {
                var subcriptionMessages = _messageRepository.GetAll(user.FollowUser);
                messages.AddRange(subcriptionMessages);
            }
            
            return messages;
        }
    }
}
