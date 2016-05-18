namespace CoduranceTwitter.Model.Users
{
    public interface IUserRepository
    {
        void Add(User user);
        User Get(string username);
    }
}
