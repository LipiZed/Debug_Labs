using System;
using System.Collections.Generic;
using System.IO;
using Debug_Lab8;
using FluentAssertions;
using Xunit;

namespace GraphTests
{
    public class EdgeListReaderFluentTests
    {
        [Fact]
        public void ReadGraph_ShouldContainCorrectVerticesAndEdges()
        {
            // Arrange
            var edgeListReader = new EdgeListReader();
            string testFilePath = "testGraph.txt";

            // Пишем тестовые данные в файл
            File.WriteAllLines(testFilePath, new[] { "a-b", "b-c", "c-d", "d-a", "b-g", "c-g" });

            // Act
            var adjacencyMatrix = edgeListReader.ReadGraph(testFilePath);

            // Assert
            edgeListReader.VertexIndices.Should().ContainKeys("a", "b", "c", "d", "g");
            adjacencyMatrix[edgeListReader.VertexIndices["a"], edgeListReader.VertexIndices["b"]].Should().Be(1);
            adjacencyMatrix[edgeListReader.VertexIndices["b"], edgeListReader.VertexIndices["c"]].Should().Be(1);
        }

        [Fact]
        public void ReadGraph_VertexIndicesShouldMatchMatrixDimensions()
        {
            // Arrange
            var edgeListReader = new EdgeListReader();
            string testFilePath = "testGraph2.txt";

            File.WriteAllLines(testFilePath, new[] { "a-b", "b-c", "c-d", "d-a" });

            // Act
            var adjacencyMatrix = edgeListReader.ReadGraph(testFilePath);

            // Assert
            adjacencyMatrix.GetLength(0).Should().Be(edgeListReader.VertexIndices.Count);
            adjacencyMatrix.GetLength(1).Should().Be(edgeListReader.VertexIndices.Count);
        }
    }

    public class GraphFluentTests
    {
        private readonly Dictionary<string, int> vertexIndices = new()
        {
            { "a", 0 },
            { "b", 1 },
            { "c", 2 },
            { "d", 3 },
            { "g", 4 }
        };

        private readonly int[,] adjacencyMatrix = new int[,]
        {
            { 0, 1, 0, 1, 0 },
            { 1, 0, 1, 0, 1 },
            { 0, 1, 0, 1, 1 },
            { 1, 0, 1, 0, 0 },
            { 0, 1, 1, 0, 0 }
        };

        [Fact]
        public void FindShortestPath_ShouldHaveCorrectDistanceForEachVertex()
        {
            // Arrange
            var graph = new Graph(adjacencyMatrix, vertexIndices);

            // Act
            var distances = graph.FindShortestPath("a");

            // Assert
            distances.Should().HaveCount(vertexIndices.Count)
                .And.ContainInOrder(0, 1, 2, 1, 2);
        }

        [Fact]
        public void FindShortestPath_ShouldHaveZeroDistanceToItself()
        {
            // Arrange
            var graph = new Graph(adjacencyMatrix, vertexIndices);

            // Act
            var distances = graph.FindShortestPath("c");

            // Assert
            distances[vertexIndices["c"]].Should().Be(0);
        }
    }

    public class MatrixWriterFluentTests
    {
        [Fact]
        public void WriteGraph_ShouldOutputCorrectFileContent()
        {
            // Arrange
            var matrixWriter = new MatrixWriter();
            var filePath = "outputGraphTest.txt";
            var adjacencyMatrix = new int[,]
            {
                { 0, 1, 0, 1 },
                { 1, 0, 1, 0 },
                { 0, 1, 0, 1 },
                { 1, 0, 1, 0 }
            };

            // Act
            matrixWriter.WriteGraph(adjacencyMatrix, filePath);

            // Assert
            File.Exists(filePath).Should().BeTrue("file should be created");
            var fileContent = File.ReadAllLines(filePath);
            fileContent[0].Should().Be("4", "first line should indicate the number of vertices");
            fileContent[1].Should().Be("0 1 0 1 ");
            fileContent[2].Should().Be("1 0 1 0 ");
        }

        [Fact]
        public void WriteGraph_FileShouldContainCorrectMatrixSize()
        {
            // Arrange
            var matrixWriter = new MatrixWriter();
            var filePath = "outputGraphSizeTest.txt";
            var adjacencyMatrix = new int[,]
            {
                { 0, 1 },
                { 1, 0 }
            };

            // Act
            matrixWriter.WriteGraph(adjacencyMatrix, filePath);

            // Assert
            var fileContent = File.ReadAllLines(filePath);
            fileContent.Length.Should().Be(3, "file should contain vertex count and matrix rows");
            fileContent[1].Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Should().HaveCount(2, "each row should match the matrix size");
        }
    }
}
