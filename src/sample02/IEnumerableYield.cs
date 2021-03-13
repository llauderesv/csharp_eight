using System.Collections;
using System.Collections.Generic;

namespace csharp_eight.src.sample02.IEnumerableYield
{
    public class Pair<T> : IEnumerable<T>
    {
        public Pair(T first, T second)
        {
            First = first;
            Second = second;
        }

        public T First { get; private set; }
        public T Second { get; private set; }

        // Using yield to return array of values is very usefull because you don't need to necessarily 
        // declare a temp array to push to an existing item and return those values.
        // By using yield keyword you can achieve the samething with minimal coding effort with increase of 
        // Programmer productivity...
        public IEnumerator<T> GetEnumerator()
        {
            yield return First;
            yield return Second;
        }

        // Find Enumerator in specific context...
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}