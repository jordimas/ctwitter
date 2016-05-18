using CoduranceTwitter.Model.Users;

namespace CoduranceTwitter.Model.Walls
{
    public class Wall
    {
        public User User { get; set; }
        public User FollowUser { get; set; }
    }
}
