using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingSample1
{
    class TasksSamples
    {
      public static void Main(string[]a)
          {
            var t1 = new Task(() => TaskMethod("Task 1"));
            var t2 = new Task(() => TaskMethod("Task 2"));
            t2.Start();
            t1.Start();
            Task.Run(() => TaskMethod("Task 3"));
            Task.Factory.StartNew(() => TaskMethod("Task 4"));
            Task.Factory.StartNew(() => TaskMethod("Task 5"),TaskCreationOptions.LongRunning);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Console.ReadKey();
        }
        static void TaskMethod(string name)
        {
            Console.WriteLine($"Task {name} is running on a thread id { Thread.CurrentThread.ManagedThreadId}. Is thread pool thread: { Thread.CurrentThread.IsThreadPoolThread}            ");
        }
    }
}
