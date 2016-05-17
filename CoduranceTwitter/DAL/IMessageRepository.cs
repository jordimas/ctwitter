using CoduranceTwitter.Model;
using System.Collections.Generic;

namespace CoduranceTwitter.DAL
{
    public interface IMessageRepository
    {
        List<Message> GetAllByUser(User user);
        Message GetByUser(User user);
        void Add(Message entity);
    }
}
