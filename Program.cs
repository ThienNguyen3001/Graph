using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph<int> g = new Graph<int>();

            g.AddEdge(1, 6);
            g.AddEdge(1,3);
            g.AddEdge(3,4);
            g.AddEdge(3, 7);
            g.AddEdge(6, 2);
            g.AddEdge(6, 3);
            g.AddEdge(6, 4);
            g.AddEdge(2, 4);
            g.AddEdge(2, 5);
            g.AddEdge(4, 7);
            g.AddEdge(4, 5);

            //g.PrintGraph();
            List<int> l = new List<int>();
            l = g.BFS(3,5);
            foreach (var item in l)
            {
                Console.WriteLine(item);
            }
            l = g.DFS(3, 5);
            foreach (var item in l)
            {
                Console.WriteLine(item);
            }
        }
    }
}
