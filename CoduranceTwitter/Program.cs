
using CoduranceTwitter.DAL;
using CoduranceTwitter.Model;
using System;

namespace CoduranceTwitter
{
   class Program
    {
        static ICommand[] GetCommands()
        {
            IMessageRepository messageRepository = new MemoryMessageRepository();
            IWallRepository wallRepository = new MemoryWallRepository();
            IUserRepository userRepository = new MemoryUserRepository();

            ICommand[] commands =
            {
                new CommandPost(messageRepository, userRepository),
                new CommandFollow(wallRepository, userRepository),
                new CommandWall(wallRepository, userRepository, messageRepository),
                new CommandRead(messageRepository, userRepository),
            };

            return commands;
        }

        static void Main(string[] args)
        {
            var commands = GetCommands(); 
            while (true)
            {
                string line = Console.ReadLine();
                foreach (var command in commands)
                {
                    if (command.Process(line))
                    {
                        ICommandWithOutput output = command as ICommandWithOutput;
                        if (output != null)
                        {
                            var messagePrinter = new MessagePrinter(output.Messages);
                            foreach (var outline in messagePrinter.GetOutput())
                            {
                                Console.WriteLine(outline);
                            }
                        }
                        break;
                    }                    

                }
            }
        }
    }
}
