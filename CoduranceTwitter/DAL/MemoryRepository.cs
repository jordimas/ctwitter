using CoduranceTwitter.Model;
using System;
using System.Collections.Generic;

namespace CoduranceTwitter.DAL
{
    public class MemoryRepository : IRepository
    {
        internal class SubscriptionData
        {
            public string User { get; set; }
            public string FollowUser { get; set; }
        }


        private Dictionary<string, int> _users = new Dictionary<string, int>();
        private int _last_user_id = 0;
        private int _last_message_id = 0;
        private List<MessageDto> _messages = new List<MessageDto>();
        private List<SubscriptionData> _subscriptions = new List<SubscriptionData>();

        public MessageDto CreateMessage(MessageDto messageDto)
        { 
            messageDto.Id = _last_message_id;
            _messages.Add(messageDto);
            _last_message_id++;
            return messageDto;
        }

        public List<MessageDto> GetMessages(string username)
        {
            return _messages.FindAll(x => x.Username == username);
        }

        public int? GetUser(string username)
        {
            int id;
            if (_users.TryGetValue(username, out id))
            {
                return id;
            }
            return null;
        }
        
        public int CreateUser(string username)
        {
            int id = _last_user_id;
            _users[username] = id;
            _last_user_id++;
            return id;
        }

        public void CreateSubscription(string user, string followUser)
        {
            int? userId = GetUser(user);
            int? followUserId = GetUser(followUser);

            SubscriptionData subscriptionData = new SubscriptionData()
            {
                User = user,
                FollowUser = followUser
            };

            _subscriptions.Add(subscriptionData);
        }

        public List<string> GetSubscriptions(string user)
        {
            List<string> subscriptions = new List <string>();
            var subscriptionsData = _subscriptions.FindAll(x => x.User == user);

            foreach (var subscription in subscriptionsData)
            {
                subscriptions.Add(subscription.FollowUser);
            }

            return subscriptions;
        }
            
    }
}
