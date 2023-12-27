namespace Project2
{
    interface ICollection<T> : IEnumerable<T>
    {
        public void Add(T element);
        public void Remove(T element);
        public IEnumerator<T> GetForwardEnumerator();
        public IEnumerator<T> GetBackwardEnumerator();
        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetForwardEnumerator();

        public static T? Find(ICollection<T> collection, Func<T, bool> predicate, bool searchDirection = true)
        {
            IEnumerator<T> enumerator;
            if (searchDirection)
            {
                enumerator = collection.GetForwardEnumerator();
            }
            else
            {
                enumerator = collection.GetBackwardEnumerator();
            }
            while (enumerator.MoveNext())
            {
                if (predicate.Invoke(enumerator.Current))
                {
                    return enumerator.Current;
                }
            }
            return default;
        }

        public static void Print(ICollection<T> collection, Func<T, bool> predicate, bool searchDirection = true)
        {
            IEnumerator<T> enumerator;
            if (searchDirection)
            {
                enumerator = collection.GetForwardEnumerator();
            }
            else
            {
                enumerator = collection.GetBackwardEnumerator();
            }
            while (enumerator.MoveNext())
            {
                if (predicate.Invoke(enumerator.Current))
                {
                    Console.WriteLine(enumerator.Current.ToString());
                }
            }
        }
    }
}