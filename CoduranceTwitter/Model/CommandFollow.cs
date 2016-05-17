using CoduranceTwitter.DAL;
using CoduranceTwitter.Model;
using System.Text.RegularExpressions;

namespace CoduranceTwitter
{
    public class CommandFollow : ICommand
    {
        private readonly IRepository<User> _userRepository;
        private readonly IWallRepository _wallRepository;
        private readonly string PATTERN = "(.*) (follows) (.*)";
        const int USERNAME_GROUP = 1;
        const int FOLLOWS_GROUP = 3;

        public CommandFollow(IWallRepository wallRepository, IRepository<User> userRepository)
        {
            _userRepository = userRepository;
            _wallRepository = wallRepository;
        }

        public bool Process(string command)
        {
            var match = Regex.Match(command, PATTERN);
            if (match.Success == false)
            {
                return false;
            }

            string username = match.Groups[USERNAME_GROUP].Value.Trim();
            string follows = match.Groups[FOLLOWS_GROUP].Value.Trim();

            var wall = new Wall()
            {
                Username = _userRepository.Get(username),
                FollowUser = _userRepository.Get(follows)
            };
            _wallRepository.Add(wall);
            return true;
        }
    }
}
