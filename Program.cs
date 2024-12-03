using System;
using System.Text;
namespace SoftwareTestingLabsExamples01x03
{
    class Program
    {
        //Метод, считающий сумму элементов массива
        static int sum(int[] x, int N)
        {   //32
            int s = 0; //33
            for (int i = 0; i < N; i++) //34
                s += x[i];  //35
            return s;   //36
        }
        //Метод для ввода целых чисел с клавиатуры
        static int ReadInt(string prompt)
        { //37
            Console.Write(prompt);  //38
            int x = int.Parse(Console.ReadLine());  //39
            return x;   //40
        }
        static void Main(string[] args)
        {//0
            const int N = 10;//1
            int[] a = new int[N] { 1, 3, -5, 0, 4, 6, -1, 9, 3, 2 };    //2
            //Найдем максимальный элемент массива //3
            int m = a[0];   //4
            for (int i = 1; i < N; i++)     //5
                if (m < a[i])   //6
                    m = a[i];   //7
            Console.WriteLine(m);   //8
            //Найдем сумму элементов массива    //9
            int s;  //10
            s = sum(a, N);  //11
            Console.WriteLine(s);   //12
            int z = s / m;  //13
            int k = 0;  //14
            for (int i = 0; i < N; i++) //15
                if (a[i] > z)   //16
                    k += a[i];  //17
                else//18
                    k -= a[i];  //19
            Console.WriteLine(k);   //20
            int x, y;   //21
            x = ReadInt("");    //22
            y = ReadInt("");    //23
            s = 0;  //24
            int iterator = 0;
            while ((x != 0) && (x != 0))    //25
            { //26
                x--;    //27
                y--;    //28
                s += x + y; //29
            }   //30
            Console.WriteLine(s);   //31
        }
    }
}
