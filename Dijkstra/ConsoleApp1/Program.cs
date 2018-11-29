using Dijkstra;
using Dijkstra.Algorithm;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var matrix = new AdjecencyMatrix<int>(4);
           
            matrix
                .From('A').To('B').Set(3).BiDirectional()
                .From('A').To('C').Set(1).BiDirectional()
                .From('A').To('D').Set(1).BiDirectional()
                .From('B').To('C').Set(3).BiDirectional()
                .From('B').To('D').Set(1).BiDirectional();

            new DijkstrasAlgorithm().CreateShortestPathTree(matrix, 'A');
        }
    }



}
