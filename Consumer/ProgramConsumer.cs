using static System.Console;

namespace ConsumerNamespace
{
    class ProgramConsumer
    {
        static void Main(string[] args)
        {
            Consumer consumer = new Consumer();

            WriteLine("Consumer started. Receiving...");
            while (true)
            {
                consumer.Receive();
            }
        }
    }
}
