using CoduranceTwitter.DAL;
using CoduranceTwitter.Model;
using System;
using System.Text.RegularExpressions;

namespace CoduranceTwitter
{
    public class CommandPost : ICommand
    {
        private readonly IRepository<Message> _messageRepository;
        private readonly IRepository<User> _userRepository;
        private readonly string PATTERN = "(.*)(->)(.*)";
        const int USERNAME_GROUP = 1;
        const int TEXT_GROUP = 3;

        public CommandPost(IRepository<Message> messageRepository, IRepository<User> userRepository)
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
                Username = GetOrCreateUser(username),
                Text = text,
                Timespan = DateTime.Now
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
                user = _userRepository.Get(username);
            }

            return user;
        }
    }
}
