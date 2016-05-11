using System.Web.Http;
using CoduranceTwitter.DAL;
using CoduranceTwitter.Model;

namespace CoduranceTwitter.WebApi
{
    public class TwitterController : ApiController
    {
        private static readonly IRepository _repository = new MemoryRepository();

        [HttpGet]
        public MessageDto[] ReadMessage(string username)
        {
            Message message = new Message(_repository);
            var messages = message.Read(username);
            return messages.ToArray();
        }

        [HttpGet]
        public string Following(string username, string data)
        {
            Wall wall = new Wall(_repository);
            wall.Subscribe(username, data);
            return $"Following {username} {data}";
        }

        [HttpGet]
        public MessageDto[] WallRead(string username)
        {
            Wall wall = new Wall(_repository);
            var messages = wall.Read(username);
            return messages.ToArray();
        }

        [HttpGet]
        public string SendMessage(string username, string data)
        {
            Message message = new Message(_repository);
            message.PostMessage(username, data);
            return $"SendMessage {username} {data}";
        }
    } 
}
