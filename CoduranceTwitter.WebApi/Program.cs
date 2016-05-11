using System;
using Microsoft.Owin.Hosting;

namespace CoduranceTwitter.WebApi
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:8080";

            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine($"CoduranceTwitter.WebApi server is running at {url}");
                Console.WriteLine("Press any key to quit.");
                Console.ReadLine();
            }
        }
    }
}
