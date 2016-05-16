using CoduranceTwitter.DAL;
using CoduranceTwitter.Model;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CoduranceTwitter
{
    public class CommandWall : ICommandWithOutput
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Wall> _wallRepository;
        private readonly IRepository<Message> _messageRepository;
        private readonly string PATTERN = "(.*) (wall)";
        private const int USERNAME_GROUP = 1;

        public string[] Output { get; private set; }


        public CommandWall(IRepository<Wall> wallRepository, IRepository<User> userRepository,
            IRepository<Message> messageRepository)
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

            var messages = Read(username);
            MessagePrinter messagePrinter = new MessagePrinter(messages);
            Output = messagePrinter.GetOutput();
            return true;
        }

        private List<Message> Read(string username)
        {
            var messages = _messageRepository.GetAll(username);
            var subscriptions = _wallRepository.GetAll(username);

            foreach (var user in subscriptions)
            {
                var subcriptionMessages = _messageRepository.GetAll(user.FollowUser.Username);
                messages.AddRange(subcriptionMessages);
            }

            messages.Sort((x, y) => y.Timespan.CompareTo(x.Timespan));
            return messages;
        }
    }
}
