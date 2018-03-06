using System.Threading;
using static System.Console;

namespace HandleSetter
{
    class ProgramHandleSetter
    {
        private static EventWaitHandle handle;

        static void Main(string[] args)
        {
            handle = new EventWaitHandle(false,
                                         EventResetMode.ManualReset,
                                         "SharedHandle");

            while (true)
            {
                WriteLine("Do you want to signal consumer. Y/N");
                var res = ReadLine();
                if (res.Equals("y", System.StringComparison.InvariantCultureIgnoreCase))
                {
                    handle.Set();
                }
                else
                {
                    handle.Reset();
                }
            }
        }
    }
}
