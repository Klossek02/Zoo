using System.Collections;

namespace Project2
{
    class Heap<T> : ICollection<T>
    {
        private List<T> values;
        private IComparer<T> comparer;

        public Heap(IComparer<T> comparer)
        {
            values = new();
            this.comparer = comparer;
        }

        public void Add(T item)
        {
            int size = values.Count;
            if (size == 0)
            {
                values.Add(item);
            }
            else
            {
                values.Add(item);
                for (int i = size / 2 - 1; i >= 0; i--)
                {
                    Heapify(i);
                }
            }
        }

        public void Remove(T item)
        {
            int size = values.Count;
            int index;
            for (index = 0; index < size; index++)
            {
                if (comparer.Compare(item, values[index]) == 0)
                {
                    break;
                }
            }

            (values[index], values[size - 1]) = (values[size - 1], values[index]);
            values.RemoveAt(size - 1);

            for (index = size / 2 - 1; index >= 0; index--)
            {
                Heapify(index);
            }
        }

        private void Heapify(int i)
        {
            int size = values.Count;
            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;


            if (l < size && comparer.Compare(values[l], values[largest]) > 0)
            {
                largest = l;
            }
            if (r < size && comparer.Compare(values[r], values[largest]) > 0)
            {
                largest = r;
            }

            if (largest != i)
            {
                T temp = values[largest];
                values[largest] = values[i];
                values[i] = temp;

                Heapify(largest);
            }
        }

        public IEnumerator<T> GetForwardEnumerator()
        {
            for (int index = 0; index < values.Count; index++)
            {
                yield return values[index];
            }
        }

        public IEnumerator GetEnumerator()
        {
            return GetForwardEnumerator();
        }

        public IEnumerator<T> GetBackwardEnumerator()
        {
            for (int index = values.Count - 1; index >= 0; index--)
            {
                yield return values[index];
            }
        }
    }
}