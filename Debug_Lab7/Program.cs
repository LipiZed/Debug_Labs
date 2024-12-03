using System;

public class Node<T>
{
    public T Data { get; set; } 
    public Node<T> Next { get; set; } 

    public Node(T data)
    {
        Data = data;
        Next = null;
    }
}

public class MyStack<T>
{
    private Node<T> top; // Верхний элемент стека

    public MyStack()
    {
        top = null;
    }

    // Добавление элемента в стек
    public void Push(T data)
    {
        Node<T> newNode = new Node<T>(data); // Создаем новый узел
        newNode.Next = top; // Устанавливаем ссылку на текущий верхний элемент
        top = newNode; // Новый узел становится верхним элементом
    }

    // получение элмента из стека
    public T Pop()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Стек пуст.");

        T data = top.Data; // Получаем данные из верхнего узла
        top = top.Next; // Смещаем верхний элемент вниз по списку
        return data; // Возвращаем удаленный элемент
    }

    // Получение верхнего элемента без его удаления
    public T Peek()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Стек пуст.");

        return top.Data; // Возвращаем данные верхнего узла
    }

    // Проверка, пуст ли стек
    public bool IsEmpty()
    {
        return top == null;
    }

    // Очистка стека
    public void Clear()
    {
        top = null; // Устанавливаем верхний элемент в null, что удаляет все ссылки
    }

    // Вывод содержимого стека
    public void PrintStack()
    {
        Node<T> current = top;
        if (current == null)
        {
            throw new InvalidOperationException("Стек пуст.");
        }
        while (current != null)
        {
            Console.WriteLine(current.Data);
            current = current.Next;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
    }
}
