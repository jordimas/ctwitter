using System;
using CoduranceTwitter.Model;
using System.Collections.Generic;

namespace CoduranceTwitter.DAL
{
    public class MemoryUserRepository : IRepository<User>
    {
        private Dictionary<string, User> _users = new Dictionary<string, User>();
        private int _last_user_id = 0;

        public void Add(User user)
        {
            int id = _last_user_id;
            user.Id = id;
            _users[user.Username] = user;
            _last_user_id++;
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
