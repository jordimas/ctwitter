using System.Collections.Generic;
using System.Text.RegularExpressions;
using CoduranceTwitter.Model.Messages;
using CoduranceTwitter.Model.Users;

namespace CoduranceTwitter.Model.Walls
{
    public class CommandWall : ICommandWithOutput
    {
        private readonly IUserRepository _userRepository;
        private readonly IWallRepository _wallRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly string PATTERN = "(.*) (wall)";
        private const int USERNAME_GROUP = 1;

        public List<Message> Messages { get; private set; }


        public CommandWall(IWallRepository wallRepository, IUserRepository userRepository,
            IMessageRepository messageRepository)
        {
            _userRepository = userRepository;
            _wallRepository = wallRepository;
            _messageRepository = messageRepository;
        }

        public bool Process(string command)
        {
            var match = Regex.Match(command, PATTERN);
            if (match.Success == false)
            {
                return false;
            }

            string username = match.Groups[USERNAME_GROUP].Value.Trim();

            var user = _userRepository.Get(username);

            var messages = Read(user);
            Messages = messages;
            return true;
        }

        private List<Message> Read(User user)
        {
            var messages = _messageRepository.GetAllByUser(user);
            var subscriptions = _wallRepository.GetAllByUser(user);

            foreach (var subscription in subscriptions)
            {
                var subcriptionMessages = _messageRepository.GetAllByUser(subscription.FollowUser);
                messages.AddRange(subcriptionMessages);
            }

            messages.Sort((x, y) => y.SentDate.CompareTo(x.SentDate));
            return messages;
        }
    }
}
