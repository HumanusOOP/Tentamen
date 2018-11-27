using System;

namespace Dijkstra
{
    public class ArrayBackedBinaryTreeHelper
    {
        public static int GetParentIndex(int index)
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

        public static (int left, int right) GetChildrenIndices(int index)
        {
            var left = (index * 2) + 1;
            var right = left + 1;
            return (left, right);
        }
    }
}