using System.Messaging;
using static System.Console;

namespace ProducerNamespace
{
    public class Producer
    {
        private MessageQueue messageQueue;
        

        public Producer(string path = @".\Private$\TestQueue")
        {
            if (!MessageQueue.Exists(path))
            {
                // Create the Queue
                MessageQueue.Create(path);
            }
            messageQueue = new MessageQueue(path);
            messageQueue.Formatter = new BinaryMessageFormatter();
            messageQueue.Label = "Testing Queue";
            
        }

        public void Send(long gid)
        {
            messageQueue.Send(gid);
            WriteLine($"Sent {gid}.");
            
        }

    }
}
