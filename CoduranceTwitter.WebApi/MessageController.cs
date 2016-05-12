using System.Web.Http;
using CoduranceTwitter.DAL;
using CoduranceTwitter.Model;

namespace CoduranceTwitter.WebApi
{
    public class MessageController : BaseController
    {
        [HttpGet]
        public Message[] Read(string username)
        {
            MessageService message = new MessageService(messageRepository);
            var messages = message.Read(username);
            return messages.ToArray();
        }

        [HttpGet]
        public string Send(string username, string data)
        {
            MessageService message = new MessageService(messageRepository);
            message.PostMessage(username, data);
            return $"SendMessage {username} {data}";
        }
    } 
}
