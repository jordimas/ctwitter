using CoduranceTwitter.Model;
using System.Collections.Generic;

namespace CoduranceTwitter.DAL
{
    // TODO: Unit of work
    public interface IRepository
    {
        Message CreateMessage (Message messageDto);
        List <Message> GetMessages(string user);

        int? GetUser(string username);
        int CreateUser(string username);

        void CreateSubscription(string user, string followUser);
        List<string> GetSubscriptions(string user);
    }
}
