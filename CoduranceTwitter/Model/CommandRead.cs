using CoduranceTwitter.DAL;
using CoduranceTwitter.Model;
using System.Text.RegularExpressions;

namespace CoduranceTwitter
{
    public class CommandRead : ICommandWithOutput
    {
        private readonly IRepository<Message> _messageRepository;
        private readonly string PATTERN = "(.*)";
        private const int USERNAME_GROUP = 1;
        public string[] Output { get; private set; }
        
        public CommandRead(IRepository<Message> messageRepository)
        {
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
            var messages = _messageRepository.GetAll(username);
            messages.Sort((x, y) => y.Timespan.CompareTo(x.Timespan));

            MessagePrinter messagePrinter = new MessagePrinter(messages);
            Output = messagePrinter.GetOutput();
            return true;
        }
    }
}
