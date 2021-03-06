﻿namespace Dijkstra
{
    public class MinStrategy<T> : IHeapStrategy<T>
    {
        private IComparer<T> _comparer;

        public MinStrategy(IComparer<T> comparer)
        {
            _comparer = comparer;
        }

        // Returns true if t1 is less than t2
        public bool Compare(T t1, T t2)
        {
            return _comparer.Compare(t1, t2);
        }
    }
}