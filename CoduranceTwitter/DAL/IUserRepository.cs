using CoduranceTwitter.Model;

namespace CoduranceTwitter.DAL
{
    public interface IUserRepository
    {
        void Add(User user);
        User Get(string username);
    }
}
