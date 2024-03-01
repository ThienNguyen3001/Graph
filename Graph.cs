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
        public List<T> BFS(T from, T to)
        {
            Dictionary<T, T> parent = new Dictionary<T, T>();
            Queue<T> queue = new Queue<T>();

            queue.Enqueue(from);
            parent[from] = default(T); // Đỉnh xuất phát không có đỉnh cha

            while (queue.Count > 0)
            {
                T current = queue.Dequeue();

                if (current.Equals(to))
                {
                    return ReconstructPath(parent, to);
                }

                if (!edgesList.ContainsKey(current)) // Nếu không có đỉnh con, bỏ qua
                    continue;

                foreach (T child in edgesList[current])
                {
                    if (!parent.ContainsKey(child))
                    {
                        parent[child] = current;
                        queue.Enqueue(child);
                    }
                }
            }

            return null; // Không tìm thấy đường đi từ from đến to        }
        }
        public List<T> DFS(T from, T to)
        {
            Dictionary<T, bool> visited = new Dictionary<T, bool>();
            Stack<T> stack = new Stack<T>();
            Dictionary<T, T> parent = new Dictionary<T, T>();

            stack.Push(from);
            visited[from] = true;
            parent[from] = default(T);

            while (stack.Count > 0)
            {
                T current = stack.Pop();

                if (current.Equals(to))
                {
                    return ReconstructPath(parent, to);
                }

                if (!edgesList.ContainsKey(current)) // Nếu không có đỉnh con, bỏ qua
                    continue;

                foreach (T child in edgesList[current])
                {
                    if (!visited.ContainsKey(child) || !visited[child])
                    {
                        visited[child] = true;
                        parent[child] = current;
                        stack.Push(child);
                    }
                }
            }

            return new List<T>(); // Không tìm thấy đường đi từ from đến to
        }
        private List<T> ReconstructPath(Dictionary<T, T> parent, T to)
        {
            List<T> path = new List<T>();
            T current = to;
            while (!current.Equals(default(T)))
            {
                path.Add(current);
                current = parent[current];
            }
            path.Reverse();
            return path;
        }        
    }
}