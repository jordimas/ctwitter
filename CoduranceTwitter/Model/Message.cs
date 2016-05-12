using System;

namespace CoduranceTwitter.Model
{
    public class Message
    {
        public string Text { get; set; }
        public DateTime Timespan { get; set; }
        public User Username { get; set; }
    }
}
