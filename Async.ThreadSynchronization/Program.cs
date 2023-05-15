using Async.ThreadSynchronization;
using System.Diagnostics;
using System.Threading;

namespace ThreadSynchronization
{
    public class MainClass
    {
        static void Main(string[] args)
        {
            Locking locking = new Locking();
            locking.Main();

            Signaling signaling = new Signaling();
            signaling.Main();

            Console.Read();
        }
    }
}


//When multiple threads execute concurrently, they can access and modify shared data. If two or more threads access shared data simultaneously, 
//it can result in race conditions, deadlocks, or other synchronization issues. To prevent these issues, 
//we use synchronization techniques like locking and signaling.
