using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph<char> g = new Graph<char>();

            //g.AddEdge(1, 6);
            //g.AddEdge(1,3);
            //g.AddEdge(3,4);
            //g.AddEdge(3, 7);
            //g.AddEdge(6, 2);
            //g.AddEdge(6, 3);
            //g.AddEdge(6, 4);
            //g.AddEdge(2, 4);
            //g.AddEdge(2, 5);
            //g.AddEdge(4, 7);
            //g.AddEdge(4, 5);

            g.AddEdge('W', 'P');
            g.AddEdge('P', 'S');
            g.AddEdge('P', 'Q');
            g.AddEdge('S', 'U');
            g.AddEdge('Q', 'R');
            g.AddEdge('Q', 'U');
            g.AddEdge('R', 'T');
            g.AddEdge('R', 'V');
            g.AddEdge('R', 'W');
            g.AddEdge('V', 'T');
            g.AddEdge('V', 'Q');
            g.AddEdge('T', 'Q');
            g.AddEdge('Q', 'U');
            g.AddEdge('U', 'P');

            //g.PrintGraph();
            List<char> l = new List<char>();
            l = g.BFS('W','T');
            foreach (var item in l)
            {
                Console.WriteLine(item);
            }
            //l = g.DFS('P', 'W');
            //foreach (var item in l)
            //{
            //    Console.WriteLine();
            //}
        }
    }
}
