using System.Collections.Generic;
using System.Linq;

namespace Dijkstra
{
    public interface IHeap<T>
    {
        void Add(T newValue);

        T DeleteMin();
    }

    public class Heap<T> : IHeap<T>
    {
        private IHeapStrategy<T> _strategy;
        private List<T> _list = new List<T>();

        public Heap(IHeapStrategy<T> strategy)
        {
            _strategy = strategy;
        }

        public void Add(T newValue)
        {
            _list.Add(newValue);

            BubbleUp(newValue, _list.Count() - 1);
            
        }

        private void BubbleUp(T newValue, int newIndex)
        {
            if (newIndex > 0)
            {
                var parentIndex = ArrayBackedBinaryTreeHelper.GetParentIndex(newIndex);
                var parentValue = _list[parentIndex];
                if (!_strategy.Compare(parentValue, newValue))
                {
                    _list[parentIndex] = newValue;
                    _list[newIndex] = parentValue;

                    //Rekursivt anrop
                    BubbleUp(newValue, parentIndex);
                }
            }
        }

        public T DeleteMin()
        {
            var value = _list.First();
            _list = _list.Skip(1).ToList();
            return value;
        }
    }
}