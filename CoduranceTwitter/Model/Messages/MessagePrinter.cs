using System;
using System.Collections.Generic;

namespace CoduranceTwitter.Model.Messages
{
    public class MessagePrinter
    {
        readonly List<Message> _messages;

        public MessagePrinter(List<Message> messages)
        {
            _messages = messages;
        }

        private string RenderTime(TimeSpan timespan)
        {
            if (timespan.Seconds < 60)
                return $"{timespan.Seconds} seconds ago";

            if (timespan.Minutes == 1)
                return $"{timespan.Minutes} minute ago";

            return $"{timespan.Minutes} minutes ago";
        }

        public string[] GetOutput()
        {
            List<string> output = new List<string>();

            foreach (Message message in _messages)
            {
                TimeSpan span = DateTime.Now - message.Timespan;
                string time = RenderTime(span);
                string msg = $"{message.Username.Username} - {message.Text} ({time})";
                output.Add(msg);
            }

            return output.ToArray();
        }
    }
}
