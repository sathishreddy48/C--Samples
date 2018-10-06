using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingSample1
{
    class WaitForAnotherThread
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting...Main Function");
            Thread t = new Thread(PrintNumbersWithDelay);
            t.Start();
            t.Join();// Main method will wait till Thread t to complete
            Console.WriteLine("Thread completed");
        }
        static void PrintNumbersWithDelay()
        {
            Console.WriteLine("Starting...Thread");
            for (int i = 1; i < 10; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                Console.WriteLine(i);
            }
        }
    }
}
