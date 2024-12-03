using System;
using System.Diagnostics;

class IntegralCalculation
{
    static void Main(string[] args)
    {
        // Параметры интегрирования
        double a = 0.1;
        double b = 1.0;
        double epsilon = 0.0001;
        int maxSteps = 1000;
        double previousIntegral = 0.0;
        double currentIntegral = 0.0;

        int FN = 1; // номер шага, на котором выводим значение интеграла в отладчик
        int LN = 2; // номер шага, на котором выводим значение интеграла в трассировщик

        int step = 1;
        bool done = false;

        while (!done && step < maxSteps)
        {
            int n = (int)Math.Pow(2, step);  // количество шагов
            double h = (b - a) / n;  // размер шага
            currentIntegral = 0.0;

            // Формула прямоугольников
            for (int i = 0; i < n; i++)
            {
                double x = a + i * h + h / 2;  // средняя точка каждого отрезка


                Debug.Assert(x >= a && x <= b, "x вышел за границы интегрирования");

                currentIntegral += f(x);
            }

            currentIntegral *= h;

            // Оценка погрешности по правилу Рунге
            double delta = Math.Abs(currentIntegral - previousIntegral) / 3.0;


            Console.WriteLine($"Шаг {step}: Интеграл = {currentIntegral}, Погрешность = {delta}");

            // Проверка точности
            if (delta <= epsilon)
            {
                done = true;
            }

            // Сохраняем интеграл для следующей итерации
            previousIntegral = currentIntegral;

            // Вывод значения на FN-ом шаге
            if (step == FN)
            {
                Debug.WriteLine($"FN шаг: Значение интеграла = {currentIntegral}");
            }

            // Вывод значения на LN-ом шаге
            if (step == LN)
            {
                Trace.WriteLine($"LN шаг: Значение интеграла = {currentIntegral}");
            }

            step++;
        }

        if (!done)
        {
            Console.WriteLine("Достигнуто максимальное количество шагов, но точность не достигнута.");
        }
        else
        {
            Console.WriteLine($"Интеграл = {currentIntegral} достигнут с точностью {epsilon} за {step - 1} шагов.");
        }
    }

    // Функция для интегрирования
    static double f(double x)
    {
        return Math.Log(1 + x) / x;
    }
}


//class FactorialSum
//{
//    static void Main(string[] args)
//    {
//        // Начальные параметры
//        int maxN = 20;  // Верхняя граница, чтобы не столкнуться с переполнением
//        long factorial = 1;  // n0 = 1
//        long sum = 0;

//        for (int i = 1; i <= maxN; i++)
//        {
//            // Вычисляем факториал
//            try
//            {
//                checked  // Включаем проверку переполнения
//                {
//                    factorial *= i;
//                }
//            }
//            catch (OverflowException)
//            {
//                // Ловим переполнение и выводим сообщение
//                Console.WriteLine($"Арифметическое переполнение при вычислении факториала для n = {i}");
//                break;
//            }

//            // Проверка переполнения
//            Debug.Assert(factorial > 0, $"Переполнение при вычислении факториала для n = {i}");

//            // Добавляем факториал в сумму
//            sum += factorial;

//            // Вывод значений
//            Console.WriteLine($"Факториал {i}! = {factorial}, текущая сумма = {sum}");
//        }

//        // Итоговый результат
//        Console.WriteLine($"Сумма факториалов от 1 до {maxN} = {sum}");
//    }
//}