using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dijkstra;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = new AdjecencyMatrix<int>(4);
            matrix.From('A').To('B').Set(5).BiDirectional();
            matrix.From('A').To('C').Set(2).BiDirectional();
            matrix.From('B').To('C').Set(2).BiDirectional();
            matrix.From('B').To('D').Set(1).BiDirectional();
        }
    }
}
