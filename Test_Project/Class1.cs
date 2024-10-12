using System;
using Xunit;
using Debug_Lab6;
public class ConverterTests
{
    // Параметрический тест для метода черного ящика
    [Theory]
    [InlineData("10", "1010")]       // Положительное число
    [InlineData("-10", "-1010 or 11111111111111111111111111110110")] // Отрицательное число
    [InlineData("2147483647", "1111111111111111111111111111111")]  // Положительное граничное число
    [InlineData("-2147483647", "-1111111111111111111111111111111 or 10000000000000000000000000000001")] // Отрицательное граничное число
    [InlineData("1", "1")]           // Положительное граничное число (1)
    [InlineData("-1", "-1 or 11111111111111111111111111111111")]   // Отрицательное граничное число (-1)
    [InlineData("0", "0")]           // Ноль
    public void ToBinary_ShouldReturnCorrectBinary_ForValidInputs(string input, string expected)
    {
        var converter = new Converter();

        string result = converter.ToBinary(input);

        Assert.Equal(expected, result);
    }

    // Тест для некорректного ввода (пустая строка)
    [Fact]
    public void ToBinary_ShouldThrowArgumentException_ForEmptyString()
    {

        var converter = new Converter();
        string input = "";

        var exception = Assert.Throws<ArgumentException>(() => converter.ToBinary(input));
        Assert.Equal("Вы ввели не целое число или число превышает допустимый максимум", exception.Message);
    }

    // Тест для некорректного ввода (буквы вместо цифр)
    [Fact]
    public void ToBinary_ShouldThrowArgumentException_ForInvalidString()
    {
        var converter = new Converter();
        string input = "abc";

        var exception = Assert.Throws<ArgumentException>(() => converter.ToBinary(input));
        Assert.Equal("Вы ввели не целое число или число превышает допустимый максимум", exception.Message);
    }
}
