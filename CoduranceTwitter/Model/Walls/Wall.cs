using CoduranceTwitter.Model.Users;

namespace CoduranceTwitter.Model.Walls
{
    public class Wall
    {
        public User Username { get; set; }
        public User FollowUser { get; set; }
    }
}
