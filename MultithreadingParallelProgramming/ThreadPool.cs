using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadingParallelProgramming
{
    class ThreadPoolExample
    {
        public static void Main()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(MyTask), "Task 1"); //QueueUserWorkItem() to enqueue a new task to the thread pool
            Console.WriteLine("Main thread continues to execute...");
            Thread.Sleep(1000);
            Console.WriteLine("Main thread has finished.");

            //The main thread continues to execute while the task is being executed in the background
        }

        private static void MyTask(object state)
        {
            string taskName = (string)state;
            Console.WriteLine("Starting task: " + taskName);
            Thread.Sleep(2000);
            Console.WriteLine("Task " + taskName + " has finished.");
        }
    }
}

//A thread pool is a collection of pre-created threads that are available to execute tasks on demand
//Instead of creating and starting a new thread for each task, the thread pool assigns an available thread to execute the task
//This approach reduces the overhead of creating and destroying threads, and improves the overall performance of the application.

