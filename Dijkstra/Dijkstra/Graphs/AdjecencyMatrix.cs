namespace Dijkstra
{
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


}
