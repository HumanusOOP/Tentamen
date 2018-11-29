namespace Dijkstra
{
    public class To<T>
    {
        private IGraph<T> _graph;
        private T[][] _matrix;
        private int _from;
        private int _to;

        public To(IGraph<T> graph, T[][] matrix, int from, char to)
        {
            _graph = graph;
            _matrix = matrix;
            _to = to - 65;
            _from = from;
        }

        public T Value => _matrix[_from][_to];

        public Set<T> Set(T value)
        {
            _matrix[_from][_to] = value;
            return new Set<T>(_graph, _matrix, _from, _to, value);
        }
    }


}
