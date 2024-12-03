using System;

public class CircleAreaChecker
{
    public double Radius { get; set; } // Радиус окружности
    public double AngleBoundary1 { get; set; } 
    public double AngleBoundary2 { get; set; } 

   
    public CircleAreaChecker(double radius, double angleBoundary1, double angleBoundary2)
    {
        Radius = radius;
        AngleBoundary1 = angleBoundary1;
        AngleBoundary2 = angleBoundary2;
    }

    // Метод для проверки принадлежности точки к одной из областей
    public string TestPoint(double x, double y)
    {
        double distance = Math.Sqrt(x * x + y * y);
        double angle = Math.Atan2(y, x) * (180 / Math.PI); // Угол в градусах

        if (angle < 0) // Приводим угол к положительному значению
        {
            angle += 360;
        }
        if (distance == 0)
        {
            return "Точка находится в начале координат";
        }
        // Проверка принадлежности к области
        if (distance > Radius)
        {
            return "Точка находится за пределами окружности."; // Внешняя область
        }
        
        else if (distance == Radius)
        {
            // Проверка на границе окружности
            if (angle == AngleBoundary1 || angle == AngleBoundary2)
            {
                return "Точка находится на границе закрашенной области."; // Точка на границе закрашенной области
            }
            if (angle + 0.001 > AngleBoundary1 || angle + 0.001 > AngleBoundary2)
            {
                return "Точна находится на границе окружности, но не в закрашенной области";
            }
            if (angle - 0.001 < AngleBoundary1 || angle - 0.001 < AngleBoundary2)
            {
                return "Точка находится внутри закрашенной области";
            }
            return "Точка находится на границе окружности, но не в закрашенной области."; // Точка на границе, но не в закрашенной области
        }
        else if (angle >= AngleBoundary1 && angle <= AngleBoundary2)
        {

            return "Точка находится в закрашенной области."; // Закрашенная область
        }
        else
        {
            return "Точка находится в незакрашенной области."; // Незакрашенная область
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        CircleAreaChecker checker = new CircleAreaChecker(10, 45, 135); // Радиус 10, углы 45° и 135°

        // Тестовые точки
        double[][] testPoints = {
            new double[] {5, 5},
            new double[] {8, 0},  // Незакрашенная область
            new double[] {15, 15}, // Внешняя область
            new double[] {10 * Math.Cos(Math.PI / 4), 10 * Math.Sin(Math.PI / 4)}, // Точка на краю закрашенной области (45°)
            new double[] {10 * Math.Cos(3 * Math.PI / 4), 10 * Math.Sin(3 * Math.PI / 4)}, // Точка на краю закрашенной области (135°)
            new double[] {11, 0},  // Внешняя область
            new double[] {10, 0}, // На границе окружности, но не в закрашенной области
            new double[] {0, 0}, // В начале координат
        };

        foreach (var point in testPoints)
        {
            string result = checker.TestPoint(point[0], point[1]);
            Console.WriteLine($"Точка ({point[0]}, {point[1]}): {result}");
        }
    }
}
