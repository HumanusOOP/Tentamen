namespace Dijkstra.Algorithm
{
    public class HeapNodeComparer : IComparer<Node>
    {
        public bool Compare(Node t1, Node t2)
        {
            return t1.Value < t2.Value;
        }
    }
}
