using System.Web.Http;
using CoduranceTwitter.DAL;
using CoduranceTwitter.Model;

namespace CoduranceTwitter.WebApi
{
    public class BaseController : ApiController
    {
        protected static readonly IRepository<Message> messageRepository = new MemoryMessageRepository();
        protected static readonly IRepository<Wall> wallRepository = new MemoryWallRepository();
        protected static readonly IRepository<User> userRepository = new MemoryUserRepository();
    }
}
