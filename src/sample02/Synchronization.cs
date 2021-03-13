using System;
using System.Threading.Tasks;

namespace csharp_eight.src.sample02.Synchronization
{
    // By using lock keyword in types, you can avoid race condition when they been
    // accessed multiple times to other code blocks.
    public class Synchronization
    {
        readonly static object _Sync = new object();
        const int _Total = int.MaxValue;
        static long _Count = 0;


        public Synchronization()
        {
            // Synchronization....
            Task taskDec = Task.Run(() => Decrement());

            // We can safely access the _Count variable here since we have a lock keyword...
            for (int i = 0; i < _Total; i++)
            {
                lock (_Sync)
                {
                    _Count++;
                }
            }

            taskDec.Wait();

            Console.WriteLine($"Count = {_Count}");
        }

        // Synchronization to avoid race condition...
        // Using lock keyword to avoid race condition when dealing with modifying static data...
        static void Decrement()
        {
            for (int i = 0; i < _Total; i++)
            {
                lock (_Sync)
                {
                    _Count--;
                }
            }
        }
    }
}