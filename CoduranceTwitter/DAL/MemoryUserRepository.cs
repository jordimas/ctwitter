using System;
using CoduranceTwitter.Model;
using System.Collections.Generic;

namespace CoduranceTwitter.DAL
{
    public class MemoryUserRepository : IRepository<User>
    {
        private readonly Dictionary<string, User> _users = new Dictionary<string, User>();
        private int _lastUserId = 0;

        public void Add(User user)
        {
            int id = _lastUserId;
            user.Id = id;
            _users[user.Username] = user;
            _lastUserId++;
        }

        public User Get(string username)
        {
            User user;
            if (_users.TryGetValue(username, out user))
            {
                return user;
            }
            return null;
        }

        public List<User> GetAll(string username)
        {
            throw new NotImplementedException();
        }
    }
}
