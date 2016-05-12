using System.Web.Http;
using CoduranceTwitter.Model;

namespace CoduranceTwitter.WebApi
{
    public class WallController : BaseController
    {
        [HttpGet]
        public string Following(string username, string data)
        {
            WallService wall = new WallService(wallRepository, messageRepository);
            wall.Follow(username, data);
            return $"Following {username} {data}";
        }

        [HttpGet]
        public Message[] Read(string username)
        {
            WallService wall = new WallService(wallRepository, messageRepository);
            var messages = wall.Read(username);
            return messages.ToArray();
        }
    } 
}
