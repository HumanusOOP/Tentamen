using System;
using System.Collections.Generic;

namespace Dijkstra
{
    public static class ArrayBackedBinaryTreeExtensions
    {
        public static int GetParentIndex(this int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Index must be positive");
            }
            if (index == 0)
            {
                throw new Exception("Root has no parent");
            }

            return (index - 1) / 2;
        }

        public static (int left, int right) GetChildrenIndices(this int index)
        {
            var left = (index * 2) + 1;
            var right = left + 1;
            return (left, right);
        }

        public static void Swap<T>(this List<T> @this, int i1, int i2)
        {
            var temp = @this[i1];
            @this[i1] = @this[i2];
            @this[i2] = temp;
        }
    }
}