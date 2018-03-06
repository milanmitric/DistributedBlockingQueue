using static System.Console;

namespace ProducerNamespace
{
    class ProgramProducer
    {
        static void Main(string[] args)
        {
            Producer producer = new Producer();
            WriteLine("Producer successfully started!");
            for (int i  = 0; i < 10; i++)
            {
                WriteLine($"Press to send {i}.");
                ReadLine();
                producer.Send(i);
            }
        }
    }
}
