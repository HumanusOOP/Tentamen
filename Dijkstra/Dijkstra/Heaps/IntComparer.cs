namespace Dijkstra
{
    public class IntComparer : IComparer<int>
    {
        //Returns true if t1 is less than t2
        public bool Compare(int t1, int t2)
        {
            return t1 < t2;
        }
    }
}