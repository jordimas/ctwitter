using System;

namespace CoduranceTwitter.Client
{
    public class User
    {
        public string Username { get; set; }
    }

    public class Message
    {
        public string Text { get; set; }
        public DateTime Timespan { get; set; }
        public User Username { get; set; }
    }
}
