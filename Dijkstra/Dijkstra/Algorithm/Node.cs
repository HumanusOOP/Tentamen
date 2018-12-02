using System;

namespace Dijkstra.Algorithm
{
    public class Node
    {
        public Node(char name)
        {
            Name = name;
            Value = Int32.MaxValue;
        }

        public char Name { get; private set; }
        public int Value { get; set; }
        public Node PreviousNode { get; set; }
    }
}
