using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;

namespace TestManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Class1 obj = new Class1();

            // arrays
            int[] num = new int[5] { 1, 2, 3, 4, 5 };
            foreach (var n in num)
            {
                Console.WriteLine(n);
            }


            // lists
            List<string> names = new List<string>() { "Alice", "Bob", "Charlie" };
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            List<Class1> classes = new List<Class1>();


            // Dictionary 
            Dictionary<int, string> dict1 = new Dictionary<int, string>();
            dict1.Add(1, "Deepu");
            dict1.Add(2, "Yadav");

            var map = new Dictionary<string, int>();

            var map2 = new Dictionary<int, String>()
            {
                { 1, "apl" },
                { 2, "bpl" }
            };


            Dictionary<String, Class1> dict2 = new();


            // Immutable Dictionary
            var immutableDict = ImmutableDictionary<int, string>.Empty
                .Add(1, "One")
                .Add(2, "Two");


            immutableDict.Add(3, "Three"); // This creates a new dictionary


            foreach (var kvp in immutableDict)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }


            /*
             
             
                    | Feature                     | ImmutableDictionary  | ReadOnlyDictionary                |
                    | --------------------------- | -------------------- | --------------------------------- |
                    | Can underlying data change? | ❌ No                 | ✅ Yes                             |
                    | Is it truly immutable?      | ✅ Yes                | ❌ No                              |
                    | Thread-safe                 | ✅ High               | ❌ Not guaranteed                  |
                    | Write operations            | Creates new instance | Throws error via wrapper          |
                    | Read operations             | Allowed              | Allowed                           |
                    | Use case                    | Safe shared state    | Expose internal dictionary safely |

             
                    read only dictionary can provide funtionality to update existing dictionary values.
             
             
             */











            /****************************************************************************************************************************************************************
             * ***/

            /*
             ✅ 4. HashSet<T>
                📌 What is it?
                Stores unique elements only. No duplicates.
             
             */

            HashSet<int> numbers = new HashSet<int>();
            numbers.Add(1);
            Console.WriteLine(numbers.Add(1)); // False, duplicate
            numbers.Add(2);
            Console.WriteLine(numbers.GetHashCode());

            var set = new HashSet<int>();

            var set1 = new HashSet<int>() { 1, 2, 3, 4 };

            int[] numbers2 = { 1, 2, 2, 3 };
            var set2 = new HashSet<int>(numbers);

            HashSet<int> set3 = new();


            // HashSet With a Custom Equality Comparer
            var set4 = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "apple",
                "Apple"  // treated as duplicate
            };



            // Immutable HashSet
            var set5 = ImmutableHashSet.Create<int>(1, 2, 3);

            var set6 = ImmutableHashSet.CreateBuilder<int>();
            set6.Add(1);
            set6.Add(2);
            var finalSet = set6.ToImmutableHashSet();


            /*
             
                    | Syntax                       | Purpose                        |
                    | ---------------------------- | ------------------------------ |
                    | `new HashSet<int>()`         | Basic                          |
                    | `{ ... }` initializer        | Start with values              |
                    | `new()`                      | Short modern syntax            |
                    | `new HashSet<T>(collection)` | Build from existing collection |
                    | `new HashSet<T>(comparer)`   | Customize equality             |
                    | `ImmutableHashSet`           | Fully immutable version        |

             
             */



            /******************************************************************************************************************************************************************
             * ***/

            // queue

            Queue<string> q = new Queue<string>();
            q.Enqueue("A");
            q.Enqueue("B");

            Console.WriteLine(q.Dequeue()); // A


            /*********************************************************************************************************************************************************************
             * ***/

            // stack
            Stack<int> st = new Stack<int>();
            st.Push(1);
            st.Push(2);

            Console.WriteLine(st.Pop());  // 2


            /***********************************************************************************************************************************************************************
             * ***/

            // linked list

            var ll = new LinkedList<int>();
            ll.AddLast(5);
            ll.AddFirst(10);

//            ⭐ Use cases:

                //Insert / remove often in the middle

                //Implement queue/ deque behavior








            Console.ReadLine();










            /*
             
                | Data Structure   | Order  | Duplicates  | Index Access  | Speed Summary             |
                | ---------------- | ------ | ----------- | ------------- | ------------------------- |
                | Array            | Yes    | Yes         | Yes           | Fastest, fixed size       |
                | List             | Yes    | Yes         | Yes           | Fast, dynamic             |
                | Dictionary       | No     | Keys unique | No            | O(1) lookup               |
                | HashSet          | No     | No          | No            | Fast membership           |
                | Queue            | FIFO   | Yes         | No            | Fast enqueue/dequeue      |
                | Stack            | LIFO   | Yes         | No            | Fast push/pop             |
                | LinkedList       | Yes    | Yes         | No            | Fast middle insertions    |
                | SortedList       | Sorted | Keys unique | Yes via index | Good for sorted data      |
                | SortedDictionary | Sorted | Keys unique | No            | Good for frequent inserts |

             
             
             
             */
        }
    }
}
