using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadingParallelProgramming
{
    class Multithreading
    {
        public void thread()
        {
            Thread mainThread = Thread.CurrentThread;
            mainThread.Name = "Main Thread";
            Console.WriteLine(mainThread.Name);

            //Thread t1 = new Thread(countUp);
            //Thread t2 = new Thread(countDown);

            //if both methods have parameters to pass
            Thread t1 = new Thread(() => countUp("Timer #1"));
            Thread t2 = new Thread(() => countUp("Timer #2"));
            

            t1.Start();
            t2.Start();



            //countDown();
            //countUp();
        }

        public static void countDown(string name)
        {
            for(int i = 10; i >=0; i--)
            {
                Console.WriteLine(name + " : " + i + " seconds");
            }
            Console.WriteLine(name + " is complete");
        }
        public static void countUp(string name)
        {
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine(name + " : " + i + " seconds");
            }
            Console.WriteLine(name +" is complete");
        }
    }
}

//thread - an execution path of a program we can use multiple threads to perform, different tasks of our program at the same time.
//currenlty main thread running is "main" thread.