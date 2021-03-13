using System;
using System.Threading.Tasks;
using csharp_eight.src.sample01.Deconstruction;
using csharp_eight.src.sample03;
using csharp_eight.src.sample02.Synchronization;
using csharp_eight.src.sample02.IEnumerableYield;

using static System.Console;
using static csharp_eight.src.sample01.RetryPattern;

namespace csharp_eight
{
    class Program
    {
        static async Task Main(string[] args)
        {

            // Sample 01:
            // Retry pattern & Deconstruction
            // static async Task<string> GetName()
            // {
            //     var rnd = new Random().Next(0, 40);
            //     if (rnd > 25)
            //         throw new Exception($"Random value: {rnd} exceeded max allowed value.");

            //     await Task.Delay(TimeSpan.FromSeconds(5));

            //     return await Task.FromResult<string>("Vincent Llauderes");
            // }
            // var name = await Retry<string>(GetName, retryCount: 5);
            // WriteLine(name);

            // Rectangle rectangle = new Rectangle(150, 80);
            // (int width, int height) = rectangle;

            // WriteLine($"Width: {width}");
            // WriteLine($"Height: {height}");


            // Sample 03:
            // TasksSynchronization & Tasks Parallel
            // var taskParallel = new TasksParallel();
            // var synchronization = new Synchronization();

            // Sample 02:
            // Using IEnumerable to access property if Pair class
            var pair = new Pair<string>("one", "two");
            foreach (var value in pair)
            {
                WriteLine($"Pair value: {value}");
            }
            WriteLine("Accessing Pair value using property: {0}, {1}", pair.First, pair.Second);

        }
    }
}
