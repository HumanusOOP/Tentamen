using System;
using System.Collections;
using System.Collections.Generic;

namespace Dijkstra
{
    public class AdjecencyMatrix<T> : IGraph<T>
    {
        private T[][] _matrix;

        public AdjecencyMatrix(int n, Func<T, bool> isNode)
        {
            _matrix = new T[n][];
            for (int i = 0; i < n; i++)
            {
                _matrix[i] = new T[n];
            }

            IsConnected = isNode;
        }

        public From<T> From(char from)
        {
            return new From<T>(this, _matrix, from);
        }

        public IEnumerator<char> GetEnumerator()
        {
            for (int i = 0; i < _matrix.Length; i++){
                yield return (char)(i + 65);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Func <T, bool> IsConnected { set; get; }

        public int NodeCount => _matrix.Length;

        
    }
}
