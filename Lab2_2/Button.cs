using System;

public class Button
{
    // Размер кнопки по умолчанию. Является константой, так как не меняется после компиляции.
    public const int DEFAULT_SIZE = 100;
    
    // Уникальный ID кнопки. Задаётся только в конструкторе и не может быть изменён.
    private readonly Guid _id;

    // Данные, доступ к которым осуществляется через публичные свойства
    private string _text;
    private ConsoleColor _color;
    private bool _isEnabled;

    // Простое поле, демонстрирующее публичный доступ
    public string Description;

    // Автоматические свойства для более чистого кода
    public int XPosition { get; private set; }
    public int YPosition { get; private set; }
    
    // Свойство с ручным геттером и сеттером для приватного поля
    public string Text
    {
        get { return _text; }
        set { _text = value ?? "Button"; } // Если значение null, используем "Button" по умолчанию
    }

    // Свойство только для чтения
    public ConsoleColor Color => _color;

    // Инициализирует кнопку с базовыми значениями.
    public Button() : this("Default Button")
    {
    }

    // Позволяет задать текст кнопки при создании.
    public Button(string text)
    {
        _id = Guid.NewGuid(); // Устанавливаем уникальный ID
        _text = text;
        _color = ConsoleColor.White;
        XPosition = 0;
        YPosition = 0;
        _isEnabled = true;
        Description = "An interactive UI element.";
    }

    // Позволяет задать все основные свойства кнопки.
    public Button(string text, ConsoleColor color, int x, int y)
    {
        _id = Guid.NewGuid();
        _text = text;
        _color = color;
        XPosition = x;
        YPosition = y;
        _isEnabled = true;
        Description = "A custom-styled interactive UI element.";
    }


    // 1. Метод "Нажать":
    // Имитирует нажатие на кнопку, если она активна.
    public void Click()
    {
        if (_isEnabled)
        {
            Console.WriteLine($"Кнопка '{Text}' (ID: {_id}) была нажата.");
        }
        else
        {
            Console.WriteLine($"Невозможно нажать кнопку '{Text}', она заблокирована.");
        }
    }

    // 2. Метод "Рассчитать новое положение":
    // Меняет положение кнопки. Демонстрирует один из перегруженных методов.
    public void RecalculatePosition(int newX, int newY)
    {
        Console.WriteLine($"Изменение позиции '{Text}': ({XPosition}, {YPosition}) -> ({newX}, {newY})");
        XPosition = newX;
        YPosition = newY;
    }
    
    // 3. Перегрузка метода "Рассчитать новое положение":
    // Меняет положение кнопки, используя относительные значения.
    public void RecalculatePosition(int deltaX, int deltaY, bool relative)
    {
        if (relative)
        {
            Console.WriteLine($"Смещение позиции '{Text}' на: ({deltaX}, {deltaY})");
            XPosition += deltaX;
            YPosition += deltaY;
        }
    }

    // Метод, который можно вызвать без создания экземпляра класса.
    public static void DisplayDefaultSize()
    {
        Console.WriteLine($"Размер кнопки по умолчанию: {DEFAULT_SIZE}x{DEFAULT_SIZE} пикселей.");
    }
    
    // 4. Метод "Заблокировать"
    public void Disable()
    {
        _isEnabled = false;
        Console.WriteLine($"Кнопка '{Text}' заблокирована.");
    }
    
    // Демонстрирует освобождение ресурсов, вызывается сборщиком мусора
    ~Button()
    {
        Console.WriteLine($"Объект 'Button' (ID: {_id}) удален.");
    }
}