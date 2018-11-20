using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTentamen
{
    public interface IQueue<T>
    {
        void Enqueue(T elem);
        T Peek();
        T Dequeue();
        void Clear();
        bool Contains(T element);
        int Size();
    }
    public class Queue<T> : IQueue<T>
    {
        private LinkedList<T> backingList = new LinkedList<T>();

        public void Clear()
        {
            backingList.Clear();
        }

        public bool Contains(T element)
        {
            return backingList.Contains(element);
        }

        public T Dequeue()
        {
            var elem = backingList.First();
            backingList.RemoveFirst();
            return elem;
        }

        public void Enqueue(T elem)
        {
            backingList.AddLast(elem);
        }

        public T Peek()
        {
            return backingList.First();
        }

        public int Size()
        {
            return backingList.Count();
        }
    }
}
