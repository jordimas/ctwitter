using System.Collections.Generic;
using RestSharp;

namespace CoduranceTwitter.Client
{
    public class RestApiClient
    {
        private readonly string _urlPrefix = "api";
        private readonly RestClient _client;

        public RestApiClient(string server)
        {
            _client = new RestClient(server);
        }

        public void PostMessage(string username, string message)
        {
            var request = new RestRequest($"{_urlPrefix}/message/send/{username}/{message}", Method.GET);
            _client.Execute<List<Message>>(request);
        }

        public Message[] ReadMessage(string username)
        {
            var request = new RestRequest($"{_urlPrefix}/message/read/{username}", Method.GET);
            var rslt = _client.Execute<List<Message>>(request).Data;
            return rslt.ToArray();
        }

        public Message[] WallRead(string username)
        {
            var request = new RestRequest($"{_urlPrefix}/wall/read/{username}", Method.GET);
            return _client.Execute<List<Message>>(request).Data.ToArray();
        }

        public void Following(string username, string followUser)
        {
            var request = new RestRequest($"{_urlPrefix}/wall/following/{username}/{followUser}", Method.GET);
             _client.Execute<List<Message>>(request);
        }
    }
}
