using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async.ThreadSynchronization
{
    class Signaling
    {
        private static object _lock = new object();
        private static bool _ready = false;

        public void Main()
        {
            //two worker threads
            Thread thread1 = new Thread(new ThreadStart(Worker1));
            Thread thread2 = new Thread(new ThreadStart(Worker2));

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine("Main thread exiting...");
        }

        //second thread waits for one second before sending a signal to the first thread
        //The first thread waits for the signal to be sent and then continues executing.
        //The Monitor.Wait() and Monitor.Pulse() methods are used to wait for and send signals between threads.

        //The lock keyword is used to ensure that the _ready variable is accessed and modified atomically.
        public static void Worker1()
        {
            Console.WriteLine("Worker 1 started.");

            lock (_lock)
            {
                Console.WriteLine("Worker 1 waiting for signal.");

                while (!_ready)
                {
                    Monitor.Wait(_lock);
                }

                Console.WriteLine("Worker 1 got the signal.");
            }

            Console.WriteLine("Worker 1 exiting.");
        }

        public static void Worker2()
        {
            Console.WriteLine("Worker 2 started.");

            Thread.Sleep(1000);

            lock (_lock)
            {
                Console.WriteLine("Worker 2 sending signal.");
                _ready = true;

                Monitor.Pulse(_lock);
            }

            Console.WriteLine("Worker 2 exiting.");
        }
    }
}


//Signaling is a technique that allows threads to communicate with each other and coordinate their activities.