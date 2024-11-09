using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debug_Lab8
{
    public interface IGraphWriter
    {
        void WriteGraph(int[,] adjacencyMatrix, string filePath);
    }
}
