using System;
using System.Threading.Tasks;

namespace Async
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine($"Starting Main method at {DateTime.Now.TimeOfDay}");

            Console.WriteLine($"Calling SubMethod 1 at {DateTime.Now.TimeOfDay}");
            await SubMethod(1);

            Console.WriteLine($"Calling SubMethod 2 at {DateTime.Now.TimeOfDay}");
            await SubMethod(2);

            Task.WaitAll(SubMethod(3), SubMethod(4), SubMethod(5));
            
            Console.WriteLine($"Closing Main method at {DateTime.Now.TimeOfDay}");
        }

        static async Task SubMethod(int methodId)
        {
            Console.WriteLine($"Starting SubMethod {methodId} at {DateTime.Now.TimeOfDay}");

            await Task.Delay(5000);

            Console.WriteLine($"Ending SubMethod {methodId} at {DateTime.Now.TimeOfDay}");
        }
    }
}