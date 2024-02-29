using System;

namespace Graph
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph<int> g = new Graph<int>();

            g.AddEdge(0, 1);
            g.AddEdge(1, 2);
            g.AddEdge(2, 3);
            g.AddEdge(0, 4);
            g.AddEdge(4, 5);
            g.AddEdge(5, 6);
            g.AddEdge(0, 7);
            g.AddEdge(7, 8);
            g.AddEdge(8, 9);
            g.AddEdge(0, 10);
            g.AddEdge(10, 11);
            g.AddEdge(11, 12);
            //g.PrintGraph();
            g.PrintDFS(0);
        }
    }
}
