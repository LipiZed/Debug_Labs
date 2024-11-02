using Debug_Lab8;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

public class GraphTests : IDisposable
{
    private readonly string testFilePath = "test_edges.txt";

    public GraphTests()
    {
        // Создаём временный файл со списком рёбер для тестирования
        File.WriteAllLines(testFilePath, new[]
        {
            "a-b",
            "a-c",
            "b-c",
            "b-d",
            "c-e"
        });
    }

    public void Dispose()
    {
        // Удаляем временный файл после тестов
        if (File.Exists(testFilePath))
        {
            File.Delete(testFilePath);
        }
    }

    [Fact]
    public void EdgeListReader_ShouldCreateAdjacencyMatrix()
    {
        // Arrange
        EdgeListReader reader = new EdgeListReader();

        // Act
        int[,] adjacencyMatrix = reader.ReadGraph(testFilePath);
        Dictionary<string, int> vertexIndices = reader.VertexIndices;

        // Assert
        Assert.Equal(5, adjacencyMatrix.GetLength(0));
        Assert.Equal(5, adjacencyMatrix.GetLength(1));

        // Проверяем наличие рёбер
        Assert.Equal(1, adjacencyMatrix[vertexIndices["a"], vertexIndices["b"]]);
        Assert.Equal(1, adjacencyMatrix[vertexIndices["a"], vertexIndices["c"]]);
        Assert.Equal(1, adjacencyMatrix[vertexIndices["b"], vertexIndices["c"]]);
        Assert.Equal(1, adjacencyMatrix[vertexIndices["b"], vertexIndices["d"]]);
        Assert.Equal(1, adjacencyMatrix[vertexIndices["c"], vertexIndices["e"]]);

        // Проверяем симметричность для неориентированного графа
        Assert.Equal(1, adjacencyMatrix[vertexIndices["b"], vertexIndices["a"]]);
        Assert.Equal(1, adjacencyMatrix[vertexIndices["c"], vertexIndices["a"]]);
        Assert.Equal(1, adjacencyMatrix[vertexIndices["c"], vertexIndices["b"]]);
        Assert.Equal(1, adjacencyMatrix[vertexIndices["d"], vertexIndices["b"]]);
        Assert.Equal(1, adjacencyMatrix[vertexIndices["e"], vertexIndices["c"]]);
        Dispose();
    }

    [Fact]
    public void Graph_FindShortestPath_ShouldReturnCorrectDistances()
    {
        // Arrange
        EdgeListReader reader = new EdgeListReader();
        int[,] adjacencyMatrix = reader.ReadGraph(testFilePath);
        Dictionary<string, int> vertexIndices = reader.VertexIndices;
        Graph graph = new Graph(adjacencyMatrix, vertexIndices);

        // Act
        int[] distances = graph.FindShortestPath("a");

        // Assert
        Assert.Equal(0, distances[vertexIndices["a"]]); // Расстояние от 'a' до самой себя
        Assert.Equal(1, distances[vertexIndices["b"]]); // Расстояние от 'a' до 'b'
        Assert.Equal(1, distances[vertexIndices["c"]]); // Расстояние от 'a' до 'c'
        Assert.Equal(2, distances[vertexIndices["d"]]); // Расстояние от 'a' до 'd'
        Assert.Equal(2, distances[vertexIndices["e"]]); // Расстояние от 'a' до 'e'
        Dispose();
    }
}
