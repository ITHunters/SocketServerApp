using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServerApp.Queue
{
    internal static class MessageQueue
    {
        public static ConcurrentQueue<string> queue = new ConcurrentQueue<string>();
        public static SemaphoreSlim signal = new SemaphoreSlim(0);

        public static void Enqueue(string message)
        {
            queue.Enqueue(message);
            signal.Release();
        }
    }
}
