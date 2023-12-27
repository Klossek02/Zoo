using Project1;
using System.Collections;

namespace Project2
{
     class DoublyLinkedList<T> : ICollection<T>
    {
        private Node<T>? head;
        private Node<T>? tail;

        public DoublyLinkedList()
        {
            head = null;
            tail = null;
        }

        public void Add(T item)
        {
            if (head == null)
            {
                Node<T> newNode = new(item);
                head = newNode;
                tail = newNode;
            }
            else if (head == tail)
            {
                Node<T> newNode = new(item, head);
                head.Next = newNode;
                tail = newNode;
            }
            else
            {
                Node<T> lastNode = tail;
                Node<T> newNode = new(item, lastNode);
                lastNode.Next = newNode;
                tail = newNode;
            }
        }

        public void Remove(T item)
        {
            if (head.Value.Equals(item))
            {
                if (head == tail)
                {
                    head = null;
                    tail = null;
                }
                else
                {
                    head = head.Next;
                    head.Previous = null;
                    if (head.Next == null)
                    {
                        tail = head;
                    }
                }
            }
            else if (tail.Value.Equals(item))
            {
                tail = tail.Previous;
                tail.Next = null;
                if (tail.Previous == null)
                {
                    head = tail;
                }
            }
            else
            {
                Node<T> node = head;
                while (!node.Value.Equals(item))
                {
                    node = node.Next;
                }
                node.Previous.Next = node.Next;
                node.Next.Previous = node.Previous;
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

        public IEnumerator<T> GetBackwardEnumerator()
        {
            if (tail != null)
            {
                Node<T> node = tail;
                yield return node.Value;
                while (node.Previous != null)
                {
                    node = node.Previous;
                    yield return node.Value;
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            return GetForwardEnumerator();
        }

         class Node<T>
        {
            public T Value;
            public Node<T> Previous;
            public Node<T> Next;

            public Node(T value, Node<T> previous = null, Node<T> next = null)
            {
                Value = value;
                Previous = previous;
                Next = next;
            }
        }
    }
}
