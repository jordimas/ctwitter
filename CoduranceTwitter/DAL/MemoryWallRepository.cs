using System.Collections.Generic;
using System.Linq;
using CoduranceTwitter.Model.Users;
using CoduranceTwitter.Model.Walls;

namespace CoduranceTwitter.DAL
{
    public class MemoryWallRepository : MemoryRepository, IWallRepository
    {   
        public void Add(Wall wall)
        {
            var WallMemoryRow = new WallMemoryRow()
            {
               UsernameId = wall.Username.Id.Value,
               FollowUserId = wall.FollowUser.Id.Value
            };
            _walls.Add(WallMemoryRow);
        }

        public List<Wall> GetAllByUser(User user)
        {
            var wallsRows = _walls.FindAll(x => x.UsernameId == user.Id.Value);
            return wallsRows.Select(wallRow => FromWallMemoryRow(wallRow)).ToList();
        }

        public Wall GetByUser(User user)
        {
            var wall = _walls.Find(x => x.UsernameId == user.Id.Value);
            return FromWallMemoryRow(wall);
        }

        private Wall FromWallMemoryRow(WallMemoryRow memory)
        {
            return new Wall()
            {
                Username = _users[memory.UsernameId],
                FollowUser = _users[memory.FollowUserId]
            };
        }
    }
}
