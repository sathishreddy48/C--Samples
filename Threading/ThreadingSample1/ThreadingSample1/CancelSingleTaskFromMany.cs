using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingSample1
{
    class CancelSingleTaskFromMany
    {
        public static void Main(string[] args)
        {
            CancellationTokenSource tokenSource1 = new CancellationTokenSource();
            // create the cancellation token
            CancellationToken token1 = tokenSource1.Token;
            // create the first task, which we will let run fully
            Task task1 = new Task(() => {for (int i = 0; i < 100000; i++){ token1.ThrowIfCancellationRequested();
                    Console.WriteLine("Task 1 - Int value {0}", i);
                }
            }, token1);
            CancellationTokenSource tokenSource2 = new CancellationTokenSource();
            CancellationToken token2 = tokenSource2.Token;
            Task task2 = new Task(() => {
                for (int i = 0; i < 100000; i++)
                {
                    token2.ThrowIfCancellationRequested();
                    Console.WriteLine("Task 2 - Int value {0}", i);
                }
            }, token2);
            task1.Start();
            task2.Start();
            Console.Write("press 1 or 2 to cancel that task");
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            if (consoleKeyInfo.KeyChar.Equals('1'))
            {
                tokenSource1.Cancel();
            }
            else if (consoleKeyInfo.KeyChar.Equals('2'))
            {
                tokenSource2.Cancel();
            }

            Console.ReadKey();
        }
    }
}
