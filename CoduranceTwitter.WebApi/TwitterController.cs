using System.Web.Http;
using CoduranceTwitter.DAL;
using CoduranceTwitter.Model;

namespace CoduranceTwitter.WebApi
{

    public class TwitterController : ApiController
    {
        private static readonly IRepository<Message> messageRepository = new MemoryMessageRepository();
        private static readonly IRepository<Wall> wallRepository = new MemoryWallRepository();
        private static readonly IRepository<User> userRepository = new MemoryUserRepository();

        [HttpGet]
        public Message[] ReadMessage(string username)
        {
            MessageService message = new MessageService(messageRepository);
            var messages = message.Read(username);
            return messages.ToArray();
        }

        [HttpGet]
        public string Following(string username, string data)
        {
            WallService wall = new WallService(wallRepository, messageRepository);
            wall.Subscribe(username, data);
            return $"Following {username} {data}";
        }

        [HttpGet]
        public Message[] WallRead(string username)
        {
            WallService wall = new WallService(wallRepository, messageRepository);
            var messages = wall.Read(username);
            return messages.ToArray();
        }

        [HttpGet]
        public string SendMessage(string username, string data)
        {
            MessageService message = new MessageService(messageRepository);
            message.PostMessage(username, data);
            return $"SendMessage {username} {data}";
        }
    } 
}
