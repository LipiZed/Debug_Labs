using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debug_Lab8
{
    internal interface IGraphReader
    {
        int[,] ReadGraph(string filePath);
    }
}
