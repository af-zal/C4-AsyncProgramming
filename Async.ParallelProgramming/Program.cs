

namespace ParallelProgramming
{
    public class MainClass
    {
        static void Main(string[] args)
        {
            //divides range of vals into smaller partitions and distribute them across multiple threads to execute in parallel
            Parallel.For(0, 10, i => //i -> index of each task, each task concurrently executed by separate thread
            {
                Console.WriteLine("Task {0} started.", i);
                Task.Delay(1000).Wait(); //Wait() - waits synchronously for the task to complete
                Console.WriteLine("Task {0} exiting.", i);
            });
            Console.WriteLine("Main thread 1 exiting");


            List<string> list = new List<string> { "one", "two", "three", "four", "five" };
            Parallel.ForEach(list, item =>
            {
                Console.WriteLine("Task {0} started.", item);
                Task.Delay(1000).Wait();
                Console.WriteLine("Task {0} exiting.", item);
            });
            Console.WriteLine("Main thread 2 exiting...");


            Parallel.Invoke(() =>
            {
                Console.WriteLine("Task 1 started.");
                Task.Delay(1000).Wait();
                Console.WriteLine("Task 1 exiting.");
            },
            () =>
            {
                Console.WriteLine("Task 2 started.");
                Task.Delay(2000).Wait();
                Console.WriteLine("Task 2 exiting.");
            },
            () =>
            {
                Console.WriteLine("Task 3 started.");
                Task.Delay(3000).Wait();
                Console.WriteLine("Task 3 exiting.");
            });

            Console.WriteLine("Main thread 3 exiting...");

            //Async and Await
            Main();

            //PLINQ
            //provides a set of extensions to the LINQ query syntax to execute queries in parallel
            int[] numbers = Enumerable.Range(1, 1000).ToArray();

            var result = numbers.AsParallel()
                                .Where(x => x % 2 == 0)
                                .Sum();

            Console.WriteLine("Sum of even numbers: {0}", result);


            Console.Read();
        }

        static async Task Main()
        {
            var url = "https://www.google.com";
            var client = new HttpClient();

            // Send an HTTP request asynchronously and await the response
            var response = await client.GetAsync(url);

            // Read the response content asynchronously and await the result
            var content = await response.Content.ReadAsStringAsync();

            Console.WriteLine(content);
        }
    }
}


//allows you to execute multiple tasks concurrently using multiple CPU cores or processors
//Parallel programming in C# allows developers to write concurrent and efficient code that 
//can take advantage of multi-core processors.