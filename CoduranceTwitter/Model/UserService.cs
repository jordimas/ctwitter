using CoduranceTwitter.DAL;

namespace CoduranceTwitter.Model
{
    public class UserService
    {   
        private IRepository <User> _repository;

        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }

        public User GetOrCreateUser(string username)
        {
            User user;
            user = _repository.Get(username);

            if (user == null)
            {
                user = new User(username);
                _repository.Add(user);
                user = _repository.Get(username);
            }

            return user;
        }
    }
}
