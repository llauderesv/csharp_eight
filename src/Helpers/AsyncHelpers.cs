using System;
using System.Threading.Tasks;
using static System.Console;

namespace csharp_eight.src.Helpers
{
    // Retry pattern with
    public static class AsyncHelpers
    {
        public static async Task<T> Retry<T>(Func<Task<T>> action, int retryCount)
        {
            // Infinite loop so that we can apply retry behavior until we terminate 
            // the execution.
            for (; ; )
            {
                try
                {
                    return await action();
                }
                catch (Exception error)
                {
                    if (retryCount <= 0)
                    {
                        WriteLine("Retry count {0} failed.", retryCount);
                        throw;
                    }

                    retryCount -= 1;

                    WriteLine("Exception ocurred: {0}", error.Message);
                    WriteLine("Retrying method call: {0}", retryCount);
                }

                await Task.Delay(TimeSpan.FromSeconds(Math.Pow(2, retryCount)));
            }
        }

        public static async Task Retry(Func<Task> action, int retryCount)
        {
            for (; ; )
            {
                try
                {
                    await action();
                }
                catch (Exception error)
                {
                    if (retryCount <= 0)
                        throw;

                    retryCount -= 1;

                    WriteLine("Exception ocurred: {0}", error.Message);
                    WriteLine("Retrying method call: {0}", retryCount);
                }

                await Task.Delay(TimeSpan.FromSeconds(Math.Pow(2, retryCount)));
            }
        }
    }
}