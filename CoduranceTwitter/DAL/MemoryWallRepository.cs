using CoduranceTwitter.Model;
using System.Collections.Generic;

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
            List<Wall> walls = new List<Wall>();
            var wallsRows = _walls.FindAll(x => x.UsernameId == user.Id.Value);
            foreach (var wallRow in wallsRows)
            {
                walls.Add(FromWallMemoryRow(wallRow));
            }
            return walls;
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
