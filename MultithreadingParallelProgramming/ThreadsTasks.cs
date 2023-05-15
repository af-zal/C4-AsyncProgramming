using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadingParallelProgramming
{
    class ThreadsTasks
    {
        public void main()
        {
            Task task = new Task(() =>   //blueprint of creating a task
            {
                Console.WriteLine("Running task in separate thread");
                int result = AddNumbers(5, 10);
            });
            task.Start();  //start the task, starts thread parallel to main thread

            Console.WriteLine("Main thread is done");  //main thread is not waiting for the task
        }


        static int AddNumbers(int a, int b)
        {
            return a + b;
        }
    }
}

//Thread - separate flow of execution inside a program, Program -> mutiple thread -> multiple flows running concurrently
//Task - object representing a single operation which may be executed on a thread , run code asynchroniously