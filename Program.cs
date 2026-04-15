using SocketServerApp.Server;
using SocketServerApp.Services;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Starting Server...");

        var server = new SocketServer();
        var processor = new MessageProcessor();

        // Start consumer (background)
        _ = Task.Run(() => processor.StartAsync());

        // Start server
        await server.StartAsync();
    }
}