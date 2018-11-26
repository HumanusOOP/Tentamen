namespace Dijkstra
{
    public class IntComparer : IComparer<int>
    {
        public bool Compare(int t1, int t2)
        {
            return t1 < t2;
        }
    }
}