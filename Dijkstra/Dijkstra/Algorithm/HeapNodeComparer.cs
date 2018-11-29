namespace Dijkstra.Algorithm
{
    public class HeapNodeComparer : IComparer<IHeapNode>
    {
        public bool Compare(IHeapNode t1, IHeapNode t2)
        {
            return t1.Value < t2.Value;
        }
    }
}
