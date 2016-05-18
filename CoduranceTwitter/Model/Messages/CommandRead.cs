using System.Collections.Generic;
using System.Text.RegularExpressions;
using CoduranceTwitter.Model.Users;

namespace CoduranceTwitter.Model.Messages
{
    public class CommandRead : ICommandWithOutput
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUserRepository _userRepository;
        private readonly string PATTERN = "(.*)";
        private const int USERNAME_GROUP = 1;
        public List <Message> Messages { get; private set; }

        public CommandRead(IMessageRepository messageRepository, IUserRepository userRepository)
        {
            _messageRepository = messageRepository;
            _userRepository = userRepository;
        }

        public bool Process(string command)
        {
            var match = Regex.Match(command, PATTERN);
            if (match.Success == false)
            {
                return false;
            }

            string username = match.Groups[USERNAME_GROUP].Value.Trim();
            User user = _userRepository.Get(username);

            var messages = _messageRepository.GetAllByUser(user);
            messages.Sort((x, y) => y.SentDate.CompareTo(x.SentDate));
            
            Messages = messages;
            return true;
        }
    }
}
