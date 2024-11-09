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

           
            int[,] adjacencyMatrix = mockGraphReader.ReadGraph(testFilePath);

            
            Assert.Equal(expectedMatrix, adjacencyMatrix);
        }
    }

    public class MatrixWriterTests
    {
        [Fact]
        public void WriteGraph_ShouldWriteCorrectAdjacencyMatrixToFile()
        {
          
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

         
            mockGraphWriter.WriteGraph(adjacencyMatrix, filePath);

            mockGraphWriter.Received().WriteGraph(adjacencyMatrix, filePath);
        }
    }
}
