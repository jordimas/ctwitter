using System.Collections.Generic;
using CoduranceTwitter.Model.Users;

namespace CoduranceTwitter.Model.Walls
{
    public interface IWallRepository
    {
        List<Wall> GetAllByUser(User user);
        Wall GetByUser(User user);
        void Add(Wall entity);
    }
}
