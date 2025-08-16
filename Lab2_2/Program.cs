namespace Lab2_2;
class Program
{
    static void Main()
    {
        // 1. Конструктор по умолчанию
        Button myButton = new Button();
        Console.WriteLine($"Создана кнопка: '{myButton.Text}', цвет: {myButton.Color}");
        myButton.Click();
        Console.WriteLine();

        // 2. Конструктор с одним параметром
        Button saveButton = new Button("Сохранить");
        Console.WriteLine($"Создана кнопка: '{saveButton.Text}', цвет: {saveButton.Color}");
        saveButton.Click();
        Console.WriteLine();

        // 3. Конструктор с полной кастомизацией
        Button exitButton = new Button("Выйти", ConsoleColor.Red, 10, 20);
        Console.WriteLine($"Создана кнопка: '{exitButton.Text}', цвет: {exitButton.Color}, позиция: ({exitButton.XPosition}, {exitButton.YPosition})");
        exitButton.Click();
        Console.WriteLine();

        // Вызов статического метода
        Button.DisplayDefaultSize();

        // Вызов обычных методов
        myButton.RecalculatePosition(15, 30);
        Console.WriteLine($"Новая позиция кнопки '{myButton.Text}': ({myButton.XPosition}, {myButton.YPosition})");

        // Вызов перегруженного метода
        myButton.RecalculatePosition(5, -10, true);
        Console.WriteLine($"Смещенная позиция кнопки '{myButton.Text}': ({myButton.XPosition}, {myButton.YPosition})");

        myButton.Disable();
        myButton.Click();
        Console.WriteLine();

        Console.WriteLine("--- Демонстрация присваивания объектов ---");

        Button anotherButton = myButton;
        Console.WriteLine($"myButton: '{myButton.Text}', позиция: ({myButton.XPosition}, {myButton.YPosition})");
        Console.WriteLine($"anotherButton: '{anotherButton.Text}', позиция: ({anotherButton.XPosition}, {anotherButton.YPosition})");

        // Изменение состояния через один объект
        anotherButton.RecalculatePosition(50, 50);

        Console.WriteLine("\nПосле изменения через 'anotherButton':");
        Console.WriteLine($"myButton: '{myButton.Text}', позиция: ({myButton.XPosition}, {myButton.YPosition})");
        Console.WriteLine($"anotherButton: '{anotherButton.Text}', позиция: ({anotherButton.XPosition}, {anotherButton.YPosition})");

        Console.WriteLine("\nНажмите любую клавишу для завершения...");
    }
}