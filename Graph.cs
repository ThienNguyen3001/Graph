using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Graph
{
    public class Graph<T> // dùng đồ thị có hướng
    {
        private Dictionary<T, List<T>> edgesList;
        public Graph()
        {
            edgesList = new Dictionary<T, List<T>>();
        }
        public void AddEdge(T from, T to)
        {
            if (!edgesList.ContainsKey(from))
                edgesList[from] = new List<T>();
            edgesList[from].Add(to);
        }
        public void PrintGraph()
        {
            foreach (var vertex in edgesList)
            {
                Console.Write(vertex.Key + " -> ");
                foreach (var neighbor in vertex.Value)
                {
                    Console.Write(neighbor + " ");
                }
                Console.WriteLine();
            }
        }
        private List<T> BFS(T from)
        {
            Dictionary<T, bool> visited = new Dictionary<T, bool>();
            List<T> result = new List<T>();
            Queue<T> queue = new Queue<T>();

            visited[from] = true;
            queue.Enqueue(from);

            while (queue.Count > 0)
            {
                T current = queue.Dequeue();
                result.Add(current);

                if (!edgesList.ContainsKey(current)) // nếu ko có tổ tiên, bỏ qua
                    continue;

                foreach (T child in edgesList[current])
                {
                    if (!visited.ContainsKey(child) || !visited[child])
                    {
                        visited[child] = true;
                        queue.Enqueue(child);
                    }
                }
            }

            return result;
        }
        public void PrintBFS(T from)
        {
            List<T> bfs = new List<T>();
            bfs = BFS(from);
            foreach(var i in bfs)
            {
                Console.Write(i+" ");
            }
        }
        private List<T> DFS(T from)
        {
            Stack<T> dfs = new Stack<T>();
            Dictionary<T, bool> visited = new Dictionary<T, bool>();
            List<T> result = new List<T>();

            dfs.Push(from);
            visited[from] = true; // Đánh dấu nút bắt đầu đã được thăm 

            while (dfs.Count > 0)
            {
                T current = dfs.Pop(); // Rút đỉnh khỏi ngăn xếp

                result.Add(current); 

                if (!edgesList.ContainsKey(current)) // nếu ko có tổ tiên, bỏ qua
                    continue;

                foreach (T child in edgesList[current]) // Duyệt qua tất cả các con của nút hiện tại
                {
                    if (!visited.ContainsKey(child) || !visited[child]) // Nếu một nút con chưa được thăm
                    {
                        dfs.Push(child); 
                        visited[child] = true; 
                    }
                }
            }
            return result; 
        }
        public void PrintDFS(T from)
        {
            List<T> res = new List<T>();
            res = DFS(from);
            foreach (var edge in res)
            {
                Console.Write(edge + " ");
            }
        }
        public void TopoSort()
        {
            
        }
    }
}