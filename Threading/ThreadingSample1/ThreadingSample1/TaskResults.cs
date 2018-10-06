using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingSample1
{
    class TaskResults
    {

      public static void Main(string[] args)
        {
            TaskMethod("Main Thread Task");
            Task<int> task = CreateTask("Task 1");
            task.Start();
            int result = task.Result;
            Console.WriteLine("Result is: {0}", result);
            task = CreateTask("Task 2");
            task.RunSynchronously();
            result = task.Result;
            Console.WriteLine("Result is: {0}", result);
            task = CreateTask("Task 3");
            task.Start();
            while (!task.IsCompleted)
            {
                Console.WriteLine(task.Status);
                Thread.Sleep(TimeSpan.FromSeconds(0.5));
            }
            Console.WriteLine(task.Status);
            result = task.Result;
            Console.WriteLine("Result is: {0}", result);
            Console.ReadKey();
        }
        static Task<int> CreateTask(string name)
        {
            return new Task<int>(() => TaskMethod(name));
        }
        static int TaskMethod(string name)
        {
            Console.WriteLine($"Task {name} is running on a thread id { Thread.CurrentThread.ManagedThreadId}. Is thread pool thread: { Thread.CurrentThread.IsThreadPoolThread} ");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            return 42;
        }
    }
   
}
