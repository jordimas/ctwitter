﻿using CoduranceTwitter.DAL;
using CoduranceTwitter.Model;
using System.Text.RegularExpressions;

namespace CoduranceTwitter
{
    public class CommandRead : ICommandWithOutput
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUserRepository _userRepository;
        private readonly string PATTERN = "(.*)";
        private const int USERNAME_GROUP = 1;
        public string[] Output { get; private set; }
        
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
            messages.Sort((x, y) => y.Timespan.CompareTo(x.Timespan));

            MessagePrinter messagePrinter = new MessagePrinter(messages);
            Output = messagePrinter.GetOutput();
            return true;
        }
    }
}
