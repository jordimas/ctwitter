using CoduranceTwitter.DAL;

namespace CoduranceTwitter.Model
{
    public class UserService
    {   
        private IRepository _repository;

        public UserService(IRepository repository)
        {
            _repository = repository;
        }

        public User GetOrCreateUser(string username)
        {
            int? id = 0;
            id = _repository.GetUser(username);

            if (id.HasValue == false)
            {
                id = _repository.CreateUser(username);
            }

            return new User()
            {
                Id = id,
                Username = username
            };
        }
    }
}
