using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Channels;
using Channels.Networking.Sockets;

namespace DemoOrderServer
{
    public class Program
    {
        static Server _server;
        static Client _client;
        public static void Main(string[] args)
        {
            if (args[0] == "s")
            {
                _server = new Server();
                _server.Start();
            }
            else
            {
                _client = new Client();
                _client.Start();
            }
            Console.ReadLine();
        }
    }
}


