using CoduranceTwitter.DAL;

namespace CoduranceTwitter.Model
{
    public class User
    {   
        private IRepository _repository;

        public User(IRepository repository)
        {
            _repository = repository;
        }

        public UserDto GetOrCreateUser(string username)
        {
            int? id = 0;
            id = _repository.GetUser(username);

            if (id.HasValue == false)
            {
                id = _repository.CreateUser(username);
            }

            return new UserDto()
            {
                Id = id,
                Username = username
            };
        }
    }
}
