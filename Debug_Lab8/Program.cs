namespace Debug_Lab8
{
    class Program
    {
        public static void Main(string[] args)
        {
            string inputFilePath = "C:\\Users\\komet\\source\\repos\\Debug_Lab8\\Debug_Lab8\\edges.txt";

            // Чтение графа из файла и создание матрицы смежности
            EdgeListReader reader = new EdgeListReader();
            int[,] adjacencyMatrix = reader.ReadGraph(inputFilePath);
            Dictionary<string, int> vertexIndices = reader.VertexIndices;

            // Создание графа
            Graph graph = new Graph(adjacencyMatrix, vertexIndices);

            string startingPoint = "a";

            // Поиск кратчайших путей от вершины "a"
            int[] shortestPaths = graph.FindShortestPath(startingPoint);

            // Запись результатов в файл
            MatrixWriter writer = new MatrixWriter();
            writer.WriteGraph(adjacencyMatrix, "C:\\Users\\komet\\source\\repos\\Debug_Lab8\\Debug_Lab8\\result.txt");
        }
    }
} 