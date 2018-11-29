using System;
using System.Collections;
using System.Collections.Generic;

namespace Dijkstra.Algorithm
{
    //public class ExcelLikeAlphabet : IEnumerable<string>
    //{
    //    public IEnumerator<string> GetEnumerator()
    //    {

    //    }

    //    IEnumerator IEnumerable.GetEnumerator()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    public class DijkstrasAlgorithm
    {
        public Heap<IHeapNode> minHeap = new Heap<IHeapNode>(new MinStrategy<IHeapNode>(new HeapNodeComparer()));
        public HashSet<IHeapNode> visited = new HashSet<IHeapNode>();

        public List<INode> CreateShortestPathTree(IGraph<int> graph, char from)
        {

        }
    }

    public class INode
    {
        public string Name { get; set; }
        public int ShortestPathLength { get; set; }
        public INode PreviousNode { get; set; }
    }
}
{