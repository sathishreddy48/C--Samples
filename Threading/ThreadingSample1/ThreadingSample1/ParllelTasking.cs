﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingSample1
{
    class ParllelTasking
    {
        public static void Main(string[] args)
        {
            var firstTask = new Task<int>(() => TaskMethod("First Task", 3));
            var secondTask = new Task<int>(() => TaskMethod("Second  Task", 2));
            var whenAllTask = Task.WhenAll(firstTask, secondTask);
            whenAllTask.ContinueWith(t =>
            Console.WriteLine($"The first answer is {t.Result[0]}, the second is{  t.Result[1]}"),TaskContinuationOptions.OnlyOnRanToCompletion);
            firstTask.Start();
            secondTask.Start();
            Thread.Sleep(TimeSpan.FromSeconds(4));
            var tasks = new List<Task<int>>();
            for (int i = 1; i <= 10; i++)
            {
                int counter = i;
                var task = new Task<int>(() => TaskMethod(string.Format($"Task {counter}"), counter));
                tasks.Add(task);
                task.Start();
            }
            while (tasks.Count > 0)
            {
                var completedTask = Task.WhenAny(tasks).Result;
                tasks.Remove(completedTask);
                Console.WriteLine($"A task has been completed with result { completedTask.Result}.");
            }
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Console.ReadKey();
        }

        static int TaskMethod(string name, int seconds)
        {
            Console.WriteLine($"Task {name} is running on a thread id{ Thread.CurrentThread.ManagedThreadId}. Is thread pool thread: { Thread.CurrentThread.IsThreadPoolThread}");
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
            return  seconds;
        }
    }
}
