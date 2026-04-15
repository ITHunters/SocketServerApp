using SocketServerApp.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServerApp.Services
{
    internal class MessageProcessor
    {
        public async Task StartAsync()
        {
            while (true)
            {
                await MessageQueue.signal.WaitAsync();

                if (MessageQueue.queue.TryDequeue(out var msg))
                {
                    File.AppendAllText("log.txt", msg + Environment.NewLine);
                }
            }
        }
    }
}
