using System.Collections;

namespace Project2
{
    class Vector<T> : ICollection<T>
    {
        private Node<T> head;

        public Vector()
        {
            head = null;
        }

        public void Add(T item)
        {
            if (head == null)
            {
                head = new Node<T>(item);
            }
            else
            {
                Node<T> node = head;
                while (node.Next != null)
                {
                    node = node.Next;
                }
                node.Next = new(item);
            }
        }

        public void Remove(T item)
        {
            if (head.Value.Equals(item))
            {
                Node<T> next = head.Next;
                head = next;
            }
            else
            {
                Node<T> node = head;
                while (!node.Next.Value.Equals(item))
                {
                    node = node.Next;
                }
                node.Next = node.Next.Next;
            }
        }

        public IEnumerator<T> GetForwardEnumerator()
        {
            if (head != null)
            {
                Node<T> node = head;
                yield return node.Value;
                while (node.Next != null)
                {
                    node = node.Next;
                    yield return node.Value;
                }
            }
        }
        public IEnumerator GetEnumerator()
        {
            return GetForwardEnumerator();
        }

        public IEnumerator<T> GetBackwardEnumerator()
        {
            if (head != null)
            {
                List<T> values = new();
                Node<T> node = head;
                values.Add(node.Value);
                while (node.Next != null)
                {
                    node = node.Next;
                    values.Add(node.Value);
                }

                for (int index = values.Count - 1; index >= 0; index--)
                {
                    yield return values[index];
                }
            }
        }

        private class Node<T>
        {
            public T Value;
            public Node<T> Next;

            public Node(T value, Node<T> next = null)
            {
                Value = value;
                Next = next;
            }
        }
    }
}
