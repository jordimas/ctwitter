using System;
using CoduranceTwitter.Model.Users;

namespace CoduranceTwitter.Model.Messages
{
    public class Message
    {
        public string Text { get; set; }
        public DateTime Timespan { get; set; }
        public User Username { get; set; }
    }
}
