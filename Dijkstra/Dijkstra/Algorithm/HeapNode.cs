namespace Dijkstra.Algorithm
{
    public class HeapNode : IHeapNode
    {
        public HeapNode(string name, int value)
        {
            Name = name;
            Value = value;
        }
        public int Value { get; set; }
        public string Name { get; set; }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
