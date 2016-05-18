using System.Collections.Generic;
using CoduranceTwitter.Model.Users;

namespace CoduranceTwitter.Model.Messages
{
    public interface IMessageRepository
    {
        List<Message> GetAllByUser(User user);
        Message GetByUser(User user);
        void Add(Message entity);
    }
}
