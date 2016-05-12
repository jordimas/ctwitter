using CommandLine;
using CommandLine.Text;

namespace CoduranceTwitter.Client
{
    class CommandLine
    {
        private class Options
        {
            [Option('c', "command", HelpText = "Command to use", Required = true)]
            public string Command { get; set; }

            [Option('u', "username", HelpText = "Username to use", Required = true)]
            public string Username { get; set; }

            [Option('m', "message", HelpText = "Message to send")]
            public string Message { get; set; }

            [Option('f', "followuser", HelpText = "Username to follow")]
            public string FollowUser { get; set; }

            [HelpOption]
            public string GetUsage()
            {
                return HelpText.AutoBuild(this, current => HelpText.DefaultParsingErrorsHandler(this, current));
            }
        }

        readonly Options _options = new Options();

        public CommandLine(string[] args)
        {
            Parser.Default.ParseArguments(args, _options);
        }

        public string GetUsage()
        {
            return _options.GetUsage();
        }

        public string GetCommand()
        {
            return _options.Command;
        }

        public string GetUsername()
        {
            return _options.Username;
        }

        public string GetMessage()
        {
            return _options.Message;
        }

        public string GetFollowuser()
        {
            return _options.FollowUser;
        }
    }    

}
