using System;


namespace CoduranceTwitter.Model
{
    public class MessageDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Timespan { get; set; }
        public string Username { get; set; }
    }
}
