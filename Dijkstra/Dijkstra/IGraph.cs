namespace Dijkstra
{
    public class From<T>
    {
        private readonly Dijkstra.IGraph<T> graph;
        private T[][] _matrix;
        private int _from;

        public From(IGraph<T> graph, T[][] matrix, char from)
        {
            this.graph = graph;
            _matrix = matrix;
            _from = from - 65;
        }

        public To<T> To(char to)
        {
            return new To<T>(graph, _matrix, _from, to);
        }
    }

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
    
    

    public class AdjecencyMatrix<T> : IGraph<T>
    {
        public T[][] _matrix;

        public AdjecencyMatrix(int n)
        {
            _matrix = new T[n][];
            for (int i = 0; i < n; i++)
            {
                _matrix[i] = new T[n];
            }
        }

        public From<T> From(char from)
        {
            return new From<T>(this, _matrix, from);
        }


    }

    public interface IGraph<T>
    {
        From<T> From(char from);
    }


}
