using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadingParallelProgramming
{
    class Processes
    {
        public void Demo()
        {
            //Process.Start("notepad.exe", "C:\\tmp\\HelloWorld.txt");
            //Process.Start("C:\\tmp\\HelloWorld.txt");

            //Creating a process
            var app = new Process
            {
                StartInfo =
                {
                    FileName = @"notepad.exe",
                    Arguments = "C:\\tmp\\HelloWorld.txt"
                }
            };
            app.Start();

            app.PriorityClass = ProcessPriorityClass.RealTime; //After starting the process

            //app.WaitForExit();
            Console.WriteLine("No more waiting");

            //Kiling the processes - notepad
            var processes = Process.GetProcesses();
            foreach (var p in processes)
            {
                if (p.ProcessName == "notepad")
                {
                    p.Kill();
                }
            }

        }
    }
}
