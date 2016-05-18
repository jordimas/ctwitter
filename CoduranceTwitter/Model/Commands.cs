using CoduranceTwitter.Model.Messages;
using CoduranceTwitter.Model.Users;
using CoduranceTwitter.Model.Walls;

namespace CoduranceTwitter.Model
{
    public class Commands
    {
        private readonly ICommand[] _commands;

        public Commands(IMessageRepository messageRepository, IWallRepository wallRepository, IUserRepository userRepository)
        {
            _commands = new ICommand[]
            {
                new CommandPost(messageRepository, userRepository),
                new CommandFollow(wallRepository, userRepository),
                new CommandWall(wallRepository, userRepository, messageRepository),
                new CommandRead(messageRepository, userRepository),
            };
        }

        public ICommand[] Get()
        {
            return _commands;
        }
    }
}
