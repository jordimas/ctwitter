﻿using CoduranceTwitter.DAL;
using CoduranceTwitter.Model;
using System;
using CoduranceTwitter.Model.Messages;
using CoduranceTwitter.Model.Users;
using CoduranceTwitter.Model.Walls;

namespace CoduranceTwitter
{
   class Program
    {
        static ICommand[] GetCommands()
        {
            IMessageRepository messageRepository = new MemoryMessageRepository();
            IWallRepository wallRepository = new MemoryWallRepository();
            IUserRepository userRepository = new MemoryUserRepository();

            var commands = new Commands(messageRepository, wallRepository, userRepository);
            return commands.Get();
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
