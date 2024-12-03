using Xunit;

public class StackTests
{
    [Fact]
    public void Push_Pop_ShouldReturnPushedValue()
    {
        var stack = new MyStack<int>();
        stack.Push(1);
        var result = stack.Pop();
        Assert.Equal(1, result);
    }

    [Fact]
    public void Push_Peek_ShouldReturnTopValue()
    {
        var stack = new MyStack<int>();
        stack.Push(1);
        var result = stack.Peek();
        Assert.Equal(1, result);
        var result2 = stack.Peek();
        Assert.Equal(1, result2);

    }

    [Fact]
    public void Pop_EmptyStack_ShouldThrowException()
    {
        var stack = new MyStack<int>();
        Assert.Throws<InvalidOperationException>(() => stack.Pop());
    }

    [Fact]
    public void Peek_EmptyStack_ShouldThrowException()
    {
        var stack = new MyStack<int>();
        Assert.Throws<InvalidOperationException>(() => stack.Peek());
    }

    [Fact]
    public void IsEmpty_EmptyStack_ShouldReturnTrue()
    {
        var stack = new MyStack<int>();
        Assert.True(stack.IsEmpty());
    }

    [Fact]
    public void IsEmpty_NonEmptyStack_ShouldReturnFalse()
    {
        var stack = new MyStack<int>();
        stack.Push(1);
        Assert.False(stack.IsEmpty());
    }

    [Fact]
    public void Clear_NonEmptyStack_ShouldEmptyStack()
    {
        var stack = new MyStack<int>();
        stack.Push(1);
        stack.Clear();
        Assert.True(stack.IsEmpty());
    }
    [Fact]
    public void PrintStack_ShouldThrowException_WhenStackIsEmpty()
    {
        // Arrange
        var stack = new MyStack<int>();

        // Act & Assert
        var exception = Assert.Throws<InvalidOperationException>(() => stack.PrintStack());
        Assert.Equal("Стек пуст.", exception.Message);
    }

    [Fact]
    public void PrintStack_ShouldPrintAllElements_WhenStackIsNotEmpty()
    {
        // Arrange
        var stack = new MyStack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        using var sw = new StringWriter();
        Console.SetOut(sw);

        // Act
        stack.PrintStack();

        // Assert
        var expectedOutput = "3" + Environment.NewLine +
                             "2" + Environment.NewLine +
                             "1" + Environment.NewLine;

        Assert.Equal(expectedOutput, sw.ToString());
    }
}
