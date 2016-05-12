﻿using System;

namespace CoduranceTwitter.Client
{
    class Program
    {
        static void ShowMessages(Message[] messages)
        {
            foreach (var message in messages)
            {
                Console.WriteLine($"{message.Username.Username} - {message.Text} - {message.Timespan}");
            }
        }

        static void Main(string[] args)
        {
            var commandLine = new CommandLine(args);
            var command = commandLine.GetCommand();
            var username = commandLine.GetUsername();

            if (String.IsNullOrEmpty(command) || String.IsNullOrEmpty(username))
            {
                Console.WriteLine(commandLine.GetUsage());
                return;
            }
            
            var restApiClient = new RestApiClient("http://localhost:8080");

            switch (command)
            {
                case "reading":
                {
                    var messages = restApiClient.ReadMessage(username);
                    ShowMessages(messages);
                    break;
                }

                case "posting":
                {
                    var message = commandLine.GetMessage();
                    restApiClient.PostMessage(username, message);
                    Console.WriteLine("Message sent");
                    break;
                }

                case "following":
                {
                    var followUser = commandLine.GetFollowuser();
                    restApiClient.Following(username, followUser);
                    Console.WriteLine("User followed");
                    break;
                }

                case "wall":
                {
                    var messages = restApiClient.WallRead(username);
                    ShowMessages(messages);
                    break;
                }
            }
        }
    }
}
