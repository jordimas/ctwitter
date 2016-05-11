using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using RestSharp;

namespace CoduranceTwitter.Client
{
    public class RestApiClient
    {
        private readonly string _urlPrefix = "api/twitter";
        private readonly RestClient _client;

        public RestApiClient(string server)
        {
            _client = new RestClient(server);
        }

        public void PostMessage(string username, string message)
        {
            var request = new RestRequest($"{_urlPrefix}/sendMessage/{username}/{message}", Method.GET);
            _client.Execute<List<MessageDto>>(request);
        }

        public MessageDto[] ReadMessage(string username)
        {
            var request = new RestRequest($"{_urlPrefix}/readMessage/{username}", Method.GET);
            var rslt = _client.Execute<List<MessageDto>>(request).Data;
            return rslt.ToArray();
        }

        public MessageDto[] WallRead(string username)
        {
            var request = new RestRequest($"{_urlPrefix}/wallRead/{username}", Method.GET);
            return _client.Execute<List<MessageDto>>(request).Data.ToArray();
        }

        public void Following(string username, string followUser)
        {
            var request = new RestRequest($"{_urlPrefix}/following/{username}/{followUser}", Method.GET);
             _client.Execute<List<MessageDto>>(request);
        }
    }
}
