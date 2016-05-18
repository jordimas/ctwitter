using CoduranceTwitter.Model.Users;
using System.Collections.Generic;
using System;

namespace CoduranceTwitter.DAL
{
    public class MemoryRepository
    {
        protected class MessageMemoryRow
        {
            public string Text { get; set; }
            public DateTime Timespan { get; set; }
            public int UserId { get; set; }
        }

        protected class WallMemoryRow
        {
            public int UsernameId { get; set; }
            public int FollowUserId { get; set; }
        }

        public static void Init()
        {
            _walls.Clear();
            _messages.Clear();
            _users.Clear();
        }

        protected static readonly List<WallMemoryRow> _walls = new List<WallMemoryRow>();
        protected static readonly List<MessageMemoryRow> _messages = new List<MessageMemoryRow>();
        protected static readonly List<User> _users = new List<User>();
    }
}
