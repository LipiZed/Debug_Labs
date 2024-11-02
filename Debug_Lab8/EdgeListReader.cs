using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debug_Lab8
{
    public class EdgeListReader : IGraphReader
    {
        public Dictionary<string, int> VertexIndices { get; private set; } = new Dictionary<string, int>();

        public int[,] ReadGraph(string filePath)
        {
            List<Tuple<string, string>> edges = new List<Tuple<string, string>>();
            HashSet<string> vertices = new HashSet<string>();

            // Чтение рёбер из файла
            foreach (string line in File.ReadLines(filePath))
            {
                string[] nodes = line.Split('-');
                if (nodes.Length == 2)
                {
                    edges.Add(Tuple.Create(nodes[0], nodes[1]));
                    vertices.Add(nodes[0]);
                    vertices.Add(nodes[1]);
                }
            }

            // Индексируем вершины
            int index = 0;
            foreach (var vertex in vertices)
            {
                VertexIndices[vertex] = index++;
            }

            // Создаем матрицу смежности
            int size = VertexIndices.Count;
            int[,] adjacencyMatrix = new int[size, size];
            foreach (var edge in edges)
            {
                int u = VertexIndices[edge.Item1];
                int v = VertexIndices[edge.Item2];
                adjacencyMatrix[u, v] = 1;
                adjacencyMatrix[v, u] = 1; // Для неориентированного графа
            }

            return adjacencyMatrix;
        }
    }

}
