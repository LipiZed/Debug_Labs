using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debug_Lab8
{
    public class MatrixWriter : IGraphWriter
    {
        public void WriteGraph(int[,] adjacencyMatrix, string filePath)
        {
            int vertices = adjacencyMatrix.GetLength(0);
            using (var writer = new System.IO.StreamWriter(filePath))
            {
                writer.WriteLine(vertices);

                for (int i = 0; i < vertices; i++)
                {
                    for (int j = 0; j < vertices; j++)
                    {
                        writer.Write(adjacencyMatrix[i, j] + " ");
                    }
                    writer.WriteLine();
                }
            }
        }
    }

}
