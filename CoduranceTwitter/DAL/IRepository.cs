using CoduranceTwitter.Model;
using System.Collections.Generic;

namespace CoduranceTwitter.DAL
{
    public interface IRepository<TEntity> where TEntity : class
    {
        List<TEntity> GetAll(string username);
        TEntity Get(string username);
        void Add(TEntity entity);
        /*
        Message CreateMessage (Message messageDto);
        List <Message> GetMessages(string user);

        int? GetUser(string username);
        int CreateUser(string username);

        void CreateSubscription(string user, string followUser);
        List<string> GetSubscriptions(string user);
        */
    }
}
