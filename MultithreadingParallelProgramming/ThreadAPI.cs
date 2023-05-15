using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreadingParallelProgramming
{
    class MyThread
    {
        public void Main()
        {
            MyThread myThread = new MyThread();
            Thread thread = new Thread(myThread.ThreadMethod);
            thread.Start();
            Console.WriteLine("Main thread has finished.");
        }
        public void ThreadMethod()
        {
            Console.WriteLine("Starting my thread...");
            Thread.Sleep(1000);
            Console.WriteLine("My thread has finished.");
        }
    }
}

//Thread API provides a set of methods and properties ot manage threads
//Start(): starts the execution of a new thread.
//Join(): waits for a thread to finish its execution.
//Sleep(): suspends the current thread for a specified amount of time.
//Priority: gets or sets the priority of a thread.