using System.Collections.Generic;

namespace Dijkstra.Algorithm
{
    public class DijkstrasAlgorithm
    {
        public Heap<Node> minHeap = new Heap<Node>(new MinStrategy<Node>(new HeapNodeComparer()));
        public HashSet<char> visited = new HashSet<char>();

        Dictionary<char, Node> nodes = new Dictionary<char, Node>();
        public List<Node> CreateShortestPathTree(IGraph<int?> graph, char from)
        {
          
        }
    }
}
