using CoduranceTwitter.Model.Users;

namespace CoduranceTwitter.DAL
{
    public class MemoryUserRepository : MemoryRepository, IUserRepository
    {
        private int _lastUserId = 0;

        public void Add(User user)
        {
            int id = _lastUserId;
            user.Id = id;
            _users.Add(user);
            _lastUserId++;
        }

        public User Get(string username)
        {
            return _users.Find(x => x.Username == username);
        }
    }
}
