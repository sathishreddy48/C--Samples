using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingSample1
{
    class AsyncTasks
    {
    public static void Main(string[] ar)
    {
            Task t = AsynchronousProcessing();
            t.Wait();
            Console.ReadKey();
        }
        async static Task AsynchronousProcessing()
        {
            Task<string> t1 = GetInfoAsync("Task 1", 3);
            Task<string> t2 = GetInfoAsync("Task 2", 5);
            var tasks = new Task<string>[] { t1, t2 };
            string[] results = await Task.WhenAll(t1, t2);
           // string[] results = await Task.WhenAny(t1);

            foreach (string result in results)
            {
                Console.WriteLine(result);
            }
        }
        async static Task<string> GetInfoAsync(string name, int seconds)
        {
            await Task.Delay(TimeSpan.FromSeconds(seconds));
            /*await Task.Run(() =>
            Thread.Sleep(TimeSpan.FromSeconds(seconds)));*/
            return string.Format($"Task {name} is running on a thread id{ Thread.CurrentThread.ManagedThreadId}. Is thread pool thread: {Thread.CurrentThread.IsThreadPoolThread} ");
        }
    }
}
