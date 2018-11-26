namespace Dijkstra
{
    public interface IHeapStrategy<T>
    {
        bool Compare(T t1, T t2);
    }
}