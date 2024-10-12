using System;
using static System.Net.Mime.MediaTypeNames;

namespace Debug_Lab6
{

    public class Converter()
    {
        public string ToBinary(string number)
        {
            if (!int.TryParse(number, out int s))
            {
                throw new ArgumentException("Вы ввели не целое число или число превышает допустимый максимум");
            }
            if (number[0] == '-')
            {
                int y = Int32.Parse(number[1..number.Length]);
                int z = Int32.Parse(number);
                return "-" + Convert.ToString(y, 2) + " or " + Convert.ToString(z, 2);
            }
            int x = Int32.Parse(number);
            return Convert.ToString(x, 2);
        }
    }
    class Programm
    {
        public static void Main(string[] args)
        {
           Converter converter = new Converter();
           Console.WriteLine(converter.ToBinary("214748364"));
        }
    }
    
}

