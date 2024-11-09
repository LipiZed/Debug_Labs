using System;
using System.Collections.Generic;
using System.IO;
using Debug_Lab8;
using NSubstitute;
using Xunit;

namespace GraphTests
{
    public class EdgeListReaderTests
    {
        [Fact]
        public void ReadGraph_ShouldReturnCorrectAdjacencyMatrix()
        {
            // Arrange
            var mockGraphReader = Substitute.For<IGraphReader>();
            string testFilePath = "testGraph.txt";
            var expectedMatrix = new int[,]
            {
                { 0, 1, 0, 1, 0 },
                { 1, 0, 1, 0, 1 },
                { 0, 1, 0, 1, 1 },
                { 1, 0, 1, 0, 0 },
                { 0, 1, 1, 0, 0 }
            };

            // Симулируем поведение чтения из файла с помощью NSubstitute
            mockGraphReader.ReadGraph(testFilePath).Returns(expectedMatrix);

            // Act
            int[,] adjacencyMatrix = mockGraphReader.ReadGraph(testFilePath);

            // Assert
            Assert.Equal(expectedMatrix, adjacencyMatrix);
        }
    }

    public class GraphTests
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
        public void FindShortestPath_ShouldReturnCorrectDistances()
        {
            // Arrange
            var graph = new Graph(adjacencyMatrix, vertexIndices);
            string startVertex = "a";
            var expectedDistances = new int[] { 0, 1, 2, 1, 2 };

            // Act
            int[] distances = graph.FindShortestPath(startVertex);

            // Assert
            Assert.Equal(expectedDistances, distances);
        }
    }

    public class MatrixWriterTests
    {
        [Fact]
        public void WriteGraph_ShouldWriteCorrectAdjacencyMatrixToFile()
        {
            // Arrange
            var mockGraphWriter = Substitute.For<IGraphWriter>();
            string filePath = "outputGraph.txt";
            var adjacencyMatrix = new int[,]
            {
                { 0, 1, 0, 1, 0 },
                { 1, 0, 1, 0, 1 },
                { 0, 1, 0, 1, 1 },
                { 1, 0, 1, 0, 0 },
                { 0, 1, 1, 0, 0 }
            };

            // Act
            mockGraphWriter.WriteGraph(adjacencyMatrix, filePath);

            // Assert
            mockGraphWriter.Received().WriteGraph(adjacencyMatrix, filePath);
        }
    }
}
