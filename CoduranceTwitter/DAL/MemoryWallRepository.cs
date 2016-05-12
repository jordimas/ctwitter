using CoduranceTwitter.Model;
using System.Collections.Generic;

namespace CoduranceTwitter.DAL
{
    public class MemoryWallRepository : IRepository<Wall>
    {
        private readonly List<Wall> _walls = new List<Wall>();
        
        public void Add(Wall wall)
        {
            _walls.Add(wall);
        }

        public Wall Get(string username)
        {
            return _walls.Find(x => x.Username.Username == username);
        }

        public List<Wall> GetAll(string username)
        {
            return _walls.FindAll(x => x.Username.Username == username);
        }
    }
}
