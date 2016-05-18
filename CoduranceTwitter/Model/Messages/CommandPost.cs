using System;
using System.Text.RegularExpressions;
using CoduranceTwitter.Model.Users;

namespace CoduranceTwitter.Model.Messages
{
    public class CommandPost : ICommand
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUserRepository _userRepository;
        private readonly string PATTERN = "(.*)(->)(.*)";
        const int USERNAME_GROUP = 1;
        const int TEXT_GROUP = 3;

        public CommandPost(IMessageRepository messageRepository, IUserRepository userRepository)
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
            string text = match.Groups[TEXT_GROUP].Value.Trim();

            Message message = new Message()
            {
                User = GetOrCreateUser(username),
                Text = text,
                SentDate = DateTime.Now
            };

            _messageRepository.Add(message);
            return true;
        }

        private User GetOrCreateUser(string username)
        {
            User user = _userRepository.Get(username);

            if (user == null)
            {
                user = new User(username);
                _userRepository.Add(user);
            }

            return user;
        }
    }
}
