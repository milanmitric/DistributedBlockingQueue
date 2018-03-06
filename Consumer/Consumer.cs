using System;
using System.Messaging;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading;
using static System.Console;

namespace ConsumerNamespace
{
    public class Consumer
    {
        MessageQueue messageQueue;
        EventWaitHandle handle;

        public Consumer(string path = @".\Private$\TestQueue")
        {
            if (!MessageQueue.Exists(path))
            {
                WriteLine($"MessageQueue on path {path} doesn't exist.");
                throw new ArgumentException(nameof(path));
            }

            messageQueue = new MessageQueue(path);
            messageQueue.Formatter = new BinaryMessageFormatter();
            handle = EventWaitHandle.OpenExisting("SharedHandle");
        }

        public void Receive()
        {
            try
            {
                WriteLine($"Waiting for handle...");
                handle.WaitOne();
                WriteLine($"Handle received!");
                var message = messageQueue.Receive();
                var gid = (long)message.Body;
                WriteLine($"Received {gid}.");
            }
            catch (Exception e)
            {
                WriteLine($"Exception received {e}.");
            }
        }
    }
}
