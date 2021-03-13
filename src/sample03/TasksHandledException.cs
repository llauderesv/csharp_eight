using System;
using System.Threading.Tasks;

namespace csharp_eight.src.sample03
{
    public class TasksHandledException
    {
        public TasksHandledException()
        {
            TaskHandledException();
        }

        // Handling Exception in Tasks.Run...
        // We can catch the exception inside tasks using .Handle keyword on it..
        private void TaskHandledException()
        {
            Task taskA = Task.Run(() =>
                throw new InvalidOperationException());

            try
            {
                taskA.Wait();
            }
            catch (AggregateException exception)
            {
                exception.Handle(eachException =>
                {
                    Console.WriteLine($"ERROR: {eachException.Message}");
                    return true;
                });
            }
        }
    }
}