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
    }
}