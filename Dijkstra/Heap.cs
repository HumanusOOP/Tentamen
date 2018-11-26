using System.Collections.Generic;
using System.Linq;

namespace Dijkstra
{
    internal class Heap<T>
    {
        private IHeapStrategy<T> _strategy;
        private List<T> _list = new List<T>();

        public Heap(IHeapStrategy<T> strategy)
        {
            _strategy = strategy;
        }

        internal void Add(T newValue)
        {
            _list.Add(newValue);

            Swap(newValue, _list.Count() - 1);
            
        }

        private void Swap(T newValue, int newIndex)
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
                    Swap(newValue, parentIndex);
                }
            }
        }

        internal T DeleteMin()
        {
            var value = _list.First();
            _list = _list.Skip(1).ToList();
            return value;
        }
    }
}