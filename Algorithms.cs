using Project1;

namespace Project2
{
    class Alghorithms
    {
        public static T Find<T>(IEnumerator<T> iterator, Func<T, bool> predicate)
        {
            while (iterator.MoveNext())
            {
                if (predicate(iterator.Current))
                {
                    return iterator.Current;
                }
            }
            return default;
        }

        public static int ForEach<T>(IEnumerator<T> iterator, Action<T> function)
        {
            int counter = 0;
            while (iterator.MoveNext())
            {
                function(iterator.Current);
            }
            return counter;
        }

        public static int CountIf<T>(IEnumerator<T> iterator, Func<T, bool> predicate)
        {
            int counter = 0;
            while (iterator.MoveNext())
            {
                if (predicate(iterator.Current))
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
