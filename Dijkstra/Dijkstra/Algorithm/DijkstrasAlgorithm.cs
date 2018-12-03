using System.Collections.Generic;
using System.Linq;

namespace Dijkstra.Algorithm
{
    public class DijkstrasAlgorithm
    {
        public Heap<Node> minHeap = new Heap<Node>(new MinStrategy<Node>(new HeapNodeComparer()));
        public HashSet<char> visited = new HashSet<char>();

        Dictionary<char, Node> shortestPathTree = new Dictionary<char, Node>();
        public List<Node> CreateShortestPathTree(IGraph<int?> graph, char from)
        {


            var fromNode = new Node(from) { Value = 0 };
            shortestPathTree.Add(from, fromNode);

            var currentNode = shortestPathTree[from];

            while (true)
            {
                if (!visited.Contains(currentNode.Name))
                {
                    visited.Add(currentNode.Name);
                    foreach (var adj in graph.From(currentNode.Name).AdjecentNodes())
                    {
                        if (!visited.Contains(adj.name))
                        {
                            var node = GetNode(adj.name);
                            if (node.Value > currentNode.Value + adj.value)
                            {
                                node.Value = currentNode.Value + adj.value.Value;
                                node.PreviousNode = currentNode;
                                minHeap.Add(node);
                            }
                        }
                    }
                }

                currentNode = minHeap.RemoveMin();
                if (currentNode == null) {
                    break;
                }
            }
            return shortestPathTree.Values.ToList();
        }

        private Node GetNode(char name)
        {
            if (!shortestPathTree.ContainsKey(name))
            {
                shortestPathTree[name] = new Node(name);
            }

            return shortestPathTree[name];
        }
    }
}
