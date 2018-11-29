namespace Dijkstra
{
    public class Set<T>
    {
        private readonly IGraph<T> _graph;
        private T[][] _matrix;
        private int _from;
        private int _to;
        private readonly T _value;

        public Set(IGraph<T> graph, T[][] matrix, int from, int to, T value)
        {
            _graph = graph;
            _matrix = matrix;
            _from = from;
            _to = to;
            _value = value;
        }

        public IGraph<T> BiDirectional()
        {
            _matrix[_to][_from] = _value;
            return _graph;
        }
    }


}
