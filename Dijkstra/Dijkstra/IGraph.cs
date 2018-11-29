using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    public static class LetterIndexers
    {
        public static T From<T>(this T[] @this, char i)
        {
            return @this[i - 65];
        }

        public static Value<T> To<T>(this T[] @this, char i)
        {
            return new Value<T>(@this, i - 65);
        }
    }

    public class Value<T>
    {
        private readonly T[] backingArray;
        private readonly int pos;

        public Value(T[] backingArray, int pos)
        {
            this.backingArray = backingArray;
            this.pos = pos;
        }

        public ValueOptions<T> Set(T value)
        {
            backingArray[pos] = value;
            return new ValueOptions<T>(backingArray, pos);
        }
    }

    public class ValueOptions<T>
    {
        private T[] backingArray;
        private int pos;

        public ValueOptions(T[] backingArray, int pos)
        {
            this.backingArray = backingArray;
            this.pos = pos;
        }

        public void BiDirectional()
        {

        }
    }

    public class AdjecencyMatrix<T> : IGraph
    {
        public T[][] _matrix;

        public AdjecencyMatrix(int n)
        {
            _matrix = new T[n][];
            for(int i = 0; i<n; i++)
            {
                _matrix[i] = new T[n];
            }
        }

        public T[] From(char from)
        {
            return _matrix.From(from);
        }


    }

    interface IGraph
    {
        void Add(char from, char to, int value);
    }

    
}
