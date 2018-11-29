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


}
