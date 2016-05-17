using CoduranceTwitter.Model;
using System.Collections.Generic;

namespace CoduranceTwitter.DAL
{
    public interface IWallRepository
    {
        List<Wall> GetAllByUser(User user);
        Wall GetByUser(User user);
        void Add(Wall entity);
    }
}
