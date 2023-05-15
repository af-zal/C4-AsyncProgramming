using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async.ProgrammingandMultithreading
{
    class Spinning
    {
        public static async Task Main()
        {
            Console.WriteLine("Starting program...");

            Task<int> task = DoSomethingAsync();

            while (!task.IsCompleted)
            {
                Console.WriteLine("Task is not yet complete...");
                await Task.Delay(1000);
            }

            int result = await task;
            Console.WriteLine("Result: {0}", result);

            Console.WriteLine("Program complete.");
        }

        public static async Task<int> DoSomethingAsync()
        {
            Console.WriteLine("Starting task...");
            await Task.Delay(5000);
            Console.WriteLine("Task complete.");
            return 42;
        }


        private static readonly object locker = new object();
        private static int counter = 0;

        public static void Main1()
        {
            Console.WriteLine("Starting program...");

            // Blocking approach
            var task1 = Task.Run(() =>
            {
                lock (locker)
                {
                    Console.WriteLine("Task 1 starting...");
                    Thread.Sleep(5000);
                    Console.WriteLine("Task 1 complete.");
                    counter++;
                }
            });

            // Spinning approach
            var task2 = Task.Run(() =>
            {
                Console.WriteLine("Task 2 starting...");
                SpinWait spinWait = new SpinWait();
                while (counter < 1)
                {
                    spinWait.SpinOnce();
                }
                Console.WriteLine("Task 2 complete.");
            });

            Task.WaitAll(task1, task2);

            //the first task takes 5 seconds to complete, and blocks the thread while it is running. 
            //The second task uses spinning to wait for the first task to complete, and does not block the thread.
            Console.WriteLine("Counter: {0}", counter);
            Console.WriteLine("Program complete.");
        }
    }
}


//spinning refers to the act of repeatedly checking if a task or operation has completed, without blocking the current thread.