using System;
using CoduranceTwitter.Model.Users;

namespace CoduranceTwitter.Model.Messages
{
    public class Message
    {
        public string Text { get; set; }
        public DateTime SentDate { get; set; }
        public User User { get; set; }
    }
}
