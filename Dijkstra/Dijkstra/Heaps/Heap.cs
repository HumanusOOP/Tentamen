using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Dijkstra
{
    public interface IHeap<T> : IEnumerable<T>
    {
        void Add(T newValue);

        T DeleteMin();
    }

    public class Heap<T> : IHeap<T>
    {
        private IHeapStrategy<T> _strategy;
        private List<T> _list = new List<T>();
        private int _length = 0;

        public Heap(IHeapStrategy<T> strategy)
        {
            _strategy = strategy;
        }

        public void Add(T newValue)
        {

            _list.Add(newValue);
            _length++;
            BubbleUp(newValue, _list.Count() - 1);

        }

        private void BubbleUp(T newValue, int newIndex)
        {
            if (newIndex > 0)
            {
                var parentIndex = newIndex.GetParentIndex();
                var parentValue = _list[parentIndex];
                if (!_strategy.Compare(parentValue, newValue))
                {
                    _list.Swap(parentIndex, newIndex);
                    BubbleUp(newValue, parentIndex);
                }
            }
        }
        
        public T DeleteMin()
        {
            var value = _list.First();
            _length = _length - 1;
            _list.RemoveAt(0);
            if(_length <= 1)
            {
                return value;
            }

            _list.Insert(0, _list.Last());
            _list.RemoveAt(_length);
            Sink();
            return value;
        }

        public void Sink(int index = 0)
        {
            var children = index.GetChildrenIndices();
            if (children.left >= _length)
            {
                return;
            }

            var newIndex = children.right < _length
                ? (_strategy.Compare(_list[children.left], _list[children.right]) ? children.left : children.right)
                : children.left;

            if (_strategy.Compare(_list[newIndex], _list[index]))
            {
                _list.Swap(index, newIndex);
                Sink(newIndex);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}