using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomEvents
{
    public class TaskDelayCancellation
    {
        public static void Main(String[] a)
        {
            CancellationTokenSource source = new CancellationTokenSource();
            var t = Task.Run(async delegate
            {
                await Task.Delay(TimeSpan.FromSeconds(30), source.Token).ContinueWith((x) => SomeMethod());
                return 42;
            });
            Task.Delay(TimeSpan.FromSeconds(10), source.Token).ContinueWith((x) => SomeMethod());
            //Task.Delay(TimeSpan.FromSeconds(14), source.Token).ContinueWith((x) => SomeMethod1());
            //Task.Delay(TimeSpan.FromSeconds(18), source.Token).ContinueWith((x) => SomeMethod2());
            Console.WriteLine("Please type c to cancel the execution");
             ConsoleKeyInfo consoleKeyInfo=  Console.ReadKey();
            if (consoleKeyInfo.KeyChar.Equals('c'))
            {
                source.Cancel();
            }
            try
            {
                t.Wait();
            }
            catch (AggregateException ae)
            {
                foreach (var e in ae.InnerExceptions)
                    Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
            }
            Console.Write("Task t Status: {0}", t.Status);
            if (t.Status == TaskStatus.RanToCompletion)
                Console.Write(", Result: {0}", t.Result);

            source.Dispose();


            Console.ReadKey();
        }
        static void SomeMethod()
        {
            Console.WriteLine("Method  is called.");
        }
        static void SomeMethod2()
        {
            Console.WriteLine("SomeMethod2  is called.");
        }
        static void SomeMethod1()
        {
            Console.WriteLine("SomeMethod1  is called.");
        }
    }
}
