using SocketServerApp.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketServerApp.ClientHandlers
{
    internal class ClientHandler
    {
        public async Task Handle(TcpClient client)
        {
            var stream = client.GetStream();
            byte[] buffer = new byte[1024];

            while (true)
            {
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);

                if (bytesRead == 0)
                    break;

                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                Console.WriteLine($"Received: {message}");

                MessageQueue.Enqueue(message);
            }
        }
    }
}
