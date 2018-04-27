using System;
using RethinkDbNetCore;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // var client = new RethinkClient();
            var server = new RethinkServer();
            Console.WriteLine("SERVER CREATED");
        }
    }
}
