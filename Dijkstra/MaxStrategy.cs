namespace Dijkstra
{
    internal class MaxStrategy<T> : IHeapStrategy<T>
    {
        private IComparer<T> _comparer;

        public MaxStrategy(IComparer<T> comparer)
        {
            _comparer = comparer;
        }
        public bool Compare(T t1, T t2)
        {
            return _comparer.Compare(t2, t1);
        }
    }
}