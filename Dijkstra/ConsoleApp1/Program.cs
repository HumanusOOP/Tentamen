using Dijkstra;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var matrix = new AdjecencyMatrix<int>(4);
           
            matrix
                .From('A').To('B').Set(5).BiDirectional()
                .From('A').To('C').Set(2).BiDirectional()
                .From('B').To('C').Set(2).BiDirectional()
                .From('B').To('D').Set(1).BiDirectional();
        }
    }
}
