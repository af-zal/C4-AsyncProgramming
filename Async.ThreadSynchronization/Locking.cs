using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async.ThreadSynchronization
{
    class Locking
    {
        private static int _counter = 0;
        private static object _lock = new object(); //create a synchronization object that is shared by all threads accessing the critical section of code

        public void Main()
        {
            Thread thread1 = new Thread(new ThreadStart(Increment));
            Thread thread2 = new Thread(new ThreadStart(Increment));

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine("Counter value: {0}", _counter);
        }

        public static void Increment()
        {
            //lock keyword is used to create a critical section of code that can only be executed by one thread at a time.
            for (int i = 0; i < 1000000; i++)
            {
                lock (_lock)
                {
                    _counter++;
                }
            }
        }
    }
}


//Locking is a technique that ensures that a block of code can only be executed by one thread at a time