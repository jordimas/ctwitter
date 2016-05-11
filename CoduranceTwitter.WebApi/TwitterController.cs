using System.Web.Http;
using CoduranceTwitter.DAL;
using CoduranceTwitter.Model;

namespace CoduranceTwitter.WebApi
{
    public class TwitterController : ApiController
    {
        private static readonly IRepository _repository = new MemoryRepository();

        [HttpGet]
        public Message[] ReadMessage(string username)
        {
            MessageService message = new MessageService(_repository);
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
        public Message[] WallRead(string username)
        {
            Wall wall = new Wall(_repository);
            var messages = wall.Read(username);
            return messages.ToArray();
        }

        [HttpGet]
        public string SendMessage(string username, string data)
        {
            MessageService message = new MessageService(_repository);
            message.PostMessage(username, data);
            return $"SendMessage {username} {data}";
        }
    } 
}
