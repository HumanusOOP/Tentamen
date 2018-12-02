using System.Collections.Generic;

namespace Dijkstra
{
    public interface IHeap<T> : IEnumerable<T>
    {
        void Add(T newValue);

        T RemoveMin();
    }
}