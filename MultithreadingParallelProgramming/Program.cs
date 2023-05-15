


using Async.Multithreading;
using System.Diagnostics;
namespace MultithreadingParallelProgramming
{
    public class MainClass
    {
        static void Main(string[] args)
        {
            //Processes processes = new Processes();
            //processes.Demo();

            ThreadsTasks threadsTasks = new ThreadsTasks();
            threadsTasks.main();

            Multithreading mt = new Multithreading();
            mt.thread();

            MyThread thread = new MyThread();
            thread.Main();


            Console.Read();
        }
    }
}
