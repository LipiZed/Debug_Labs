using System;

public class MyTrim
{
    private string _input_str;
    private char[] _chars;
    public MyTrim(string input_str, char[] chars)
    {
        _input_str = input_str;
        _chars = chars;
    }

    // Метод для обрезки строки
    public string TrimString()
    {
        if (_input_str.Length > 0 && _chars.Contains(_input_str[0]))
        {
            _input_str = _input_str.Remove(0, 1);
        }

        if (_input_str.Length > 0 && _chars.Contains(_input_str[_input_str.Length - 1]))
        {
            _input_str = _input_str.Remove(_input_str.Length - 1, 1);
        }

        return _input_str;
    }


}

public class Program
{
    public static void Main(string[] args)
    {
        
    }
}


