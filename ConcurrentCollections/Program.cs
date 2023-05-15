using System.Collections.Concurrent;
using System.Collections.Immutable;

namespace ConcurrentCollections
{
    public class MainClass
    {
        static void Main(string[] args)
        {
            //Immutable
            //Once an instance is created, its contents cannot be modified. To add or remove key-value pairs, 
            //a new instance must be created with the updated contents.
            IList();
            IDictionary();
            IStack();


            //Concurrent
            //allow multiple threads to access and modify the collection concurrently
            CDictionary();
            CDictionary1();
            CQueue();
            CBag();
            CStack();

            Console.Read();
        }

        static void IList()
        {
            ImmutableList<int> numbers = ImmutableList.CreateRange(new int[] { 1, 2, 3 });
            ImmutableList<int> newNumbers = numbers.Add(4);

        }
        static void IDictionary()
        {
            ImmutableDictionary<string, int> scores = ImmutableDictionary.Create<string, int>()
               .Add("Alice", 95)
               .Add("Bob", 87)
               .Add("Charlie", 92);

            ImmutableDictionary<string, int> newScores = scores.SetItem("Bob", 90);

        }
        static void IStack()
        {
            ImmutableStack<int> stack = ImmutableStack.CreateRange(new int[] { 1, 2, 3 });
            ImmutableStack<int> newStack = stack.Push(4);

        }
        static void CDictionary()
        {
            ConcurrentDictionary<string, int> ages = new ConcurrentDictionary<string, int>();

            // Add or update an element in the dictionary
            //adds k-v if key exists otherwise updates age
            ages.AddOrUpdate("Alice", 25, (name, age) => age + 1);
            ages.AddOrUpdate("Alice", 25, (name, age) => age + 1);
            ages.AddOrUpdate("Bob", 30, (name, age) => age + 1);

            // Get the value of an element by key
            int aliceAge = ages.GetOrAdd("Alice", 0);
            int bobAge = ages.GetOrAdd("Bob", 0);

            Console.WriteLine("Alice's age is {0}, Bob's age is {1}", aliceAge, bobAge);
        }

        static void CDictionary1()
        {
            //A thread-safe implementation of the Dictionary collection that can be used to store and 
            //retrieve key-value pairs.
            ConcurrentDictionary<string, int> dict = new ConcurrentDictionary<string, int>();
            dict.TryAdd("one", 1);
            dict.TryAdd("two", 2);
            dict.TryAdd("three", 3);

            int value;
            if (dict.TryGetValue("one", out value))
            {
                Console.WriteLine("Value of key 'one': {0}", value);
            }

        }
        static void CQueue()
        {
            //A thread-safe implementation of the Queue collection that can be used to store and 
            //retrieve objects in a first-in, first-out (FIFO) manner.
            ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            int item;
            if (queue.TryDequeue(out item))
            {
                Console.WriteLine("Dequeued item: {0}", item);
            }
        }

        static void CBag()
        {
            //A thread-safe implementation of the Bag collection that can be used to store and 
            //retrieve objects in an unordered manner.
            ConcurrentBag<int> bag = new ConcurrentBag<int>();
            bag.Add(1);
            bag.Add(2);
            bag.Add(3);

            int item;
            if (bag.TryTake(out item))
            {
                Console.WriteLine("Taken item: {0}", item);
            }
        }

        static void CStack()
        {
            //A thread-safe implementation of the Stack collection that can be used to store and 
            //retrieve objects in a last-in, first-out (LIFO) manner.
            ConcurrentStack<int> stack = new ConcurrentStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            int item;
            if (stack.TryPop(out item))
            {
                Console.WriteLine("Popped item: {0}", item);
            }
        }
    }
}