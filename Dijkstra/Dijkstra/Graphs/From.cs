using System;
using System.Collections.Generic;
using System.Linq;

namespace Dijkstra
{
    public class From<T>
    {
        private readonly IGraph<T> graph;
        private T[][] _matrix;
        private int _from;

        public From(IGraph<T> graph, T[][] matrix, char from)
        {
            this.graph = graph;
            _matrix = matrix;
            _from = from - 65;
        }

        public (char name, T value)[] AdjecentNodes()
        {
            return _matrix[_from]
                .Select((to, i) => new { Name = (char)(i + 65), Connected = graph.IsConnected(to), Value = to }).Where(x => x.Connected).Select(x => ValueTuple.Create(x.Name, x.Value)).ToArray();
        }

        public To<T> To(char to)
        {
            return new To<T>(graph, _matrix, _from, to);
        }
    }


}
