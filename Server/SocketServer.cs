using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using SocketServerApp.ClientHandlers;

namespace SocketServerApp.Server
{
    public class SocketServer
    {
        public async Task StartAsync()
        {
            TcpListener server = new TcpListener(IPAddress.Any, 5000);
            server.Start();

            Console.WriteLine("Server started...");

            while (true)
            {
                var client = await server.AcceptTcpClientAsync();
                Console.WriteLine("Client connected");

                _ = Task.Run(() => new ClientHandler().Handle(client));
            }
        }
    }
}
