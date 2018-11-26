namespace Dijkstra
{
    public interface IComparer<T>
    {
        bool Compare(T t1, T t2);
    }
}