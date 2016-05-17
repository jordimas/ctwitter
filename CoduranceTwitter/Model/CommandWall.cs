using CoduranceTwitter.DAL;
using CoduranceTwitter.Model;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CoduranceTwitter
{
    public class CommandWall : ICommandWithOutput
    {
        private readonly IRepository<User> _userRepository;
        private readonly IWallRepository _wallRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly string PATTERN = "(.*) (wall)";
        private const int USERNAME_GROUP = 1;

        public string[] Output { get; private set; }


        public CommandWall(IWallRepository wallRepository, IRepository<User> userRepository,
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
            MessagePrinter messagePrinter = new MessagePrinter(messages);
            Output = messagePrinter.GetOutput();
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

            messages.Sort((x, y) => y.Timespan.CompareTo(x.Timespan));
            return messages;
        }
    }
}
