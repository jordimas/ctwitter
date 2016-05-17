using System;
using CoduranceTwitter.Model;
using System.Collections.Generic;

namespace CoduranceTwitter.DAL
{
    public class MemoryUserRepository : MemoryRepository, IRepository<User>
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

        public List<User> GetAll(string username)
        {
            throw new NotImplementedException();
        }
    }
}
