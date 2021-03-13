using System;
using System.Threading.Tasks;

namespace csharp_eight.src.sample03
{
    // This Sample is waiting for tasks to be completed before executing a new one..
    // This would be very helpful to run a parallel tasks..
    public class TasksParallel
    {
        public TasksParallel()
        {
            // Creating a new Tasks...
            Task taskA = Task.Run(() =>
            {
                Console.WriteLine("Starting...");
            }).ContinueWith(antecedent =>
            {
                Console.WriteLine("Continuing A...");
            });

            Task taskB = taskA.ContinueWith(
                antecedent => Console.WriteLine("Continuing B..."));
            Task taskC = taskA.ContinueWith(
                antecedent => Console.WriteLine("Continuing C..."));

            Task.WaitAll(taskB, taskC);
            Console.WriteLine("Finished!");
        }
    }
}