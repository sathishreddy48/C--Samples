using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingSample1
{
    class PauseaThread
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(PrintNumbersWithDelay);
            t.Start();// This will create thread and executes 
            PrintNumbers();//15,16 lines will executes immidiately,
                           //and thread t also continue to execute with 2 sc delay
            Console.ReadKey();
        }
        static void PrintNumbersWithDelay()
        {
            Console.WriteLine("Starting...Thread");
            for (int i = 1; i < 10; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1.5));
                Console.WriteLine("From Delayed Method"+i);
            }
        }
        static void PrintNumbers()
        {
            Console.WriteLine("Starting...");
            for (int i = 1; i < 50; i++)
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(100));
                Console.WriteLine("From Print Numbers "+i);
            }
        }
    }
}
