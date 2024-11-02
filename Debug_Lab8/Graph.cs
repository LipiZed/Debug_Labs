using System;
using System.Collections.Generic;
using System.IO;

public class Graph
{
    private int[,] adjacencyMatrix;
    private Dictionary<string, int> vertexIndices;

    public Graph(int[,] adjacencyMatrix, Dictionary<string, int> vertexIndices)
    {
        this.adjacencyMatrix = adjacencyMatrix;
        this.vertexIndices = vertexIndices;
    }

    // Метод для нахождения кратчайшего пути из указанной вершины
    public int[] FindShortestPath(string startVertex)
    {
        int start = vertexIndices[startVertex];
        int vertexCount = adjacencyMatrix.GetLength(0);
        int[] distances = new int[vertexCount];
        bool[] visited = new bool[vertexCount];

        for (int i = 0; i < vertexCount; i++)
        {
            distances[i] = int.MaxValue;
            visited[i] = false;
        }
        distances[start] = 0;

        for (int i = 0; i < vertexCount - 1; i++)
        {
            int minDistanceVertex = -1;
            int minDistance = int.MaxValue;

            for (int v = 0; v < vertexCount; v++)
            {
                if (!visited[v] && distances[v] < minDistance)
                {
                    minDistance = distances[v];
                    minDistanceVertex = v;
                }
            }

            visited[minDistanceVertex] = true;

            for (int v = 0; v < vertexCount; v++)
            {
                if (!visited[v] && adjacencyMatrix[minDistanceVertex, v] != 0 &&
                    distances[minDistanceVertex] != int.MaxValue &&
                    distances[minDistanceVertex] + adjacencyMatrix[minDistanceVertex, v] < distances[v])
                {
                    distances[v] = distances[minDistanceVertex] + adjacencyMatrix[minDistanceVertex, v];
                }
            }
        }

        return distances;
    }

}
