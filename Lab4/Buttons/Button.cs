//3
namespace Lab4;
public class Button : Control
{
    // Собственное свойство
    public ConsoleColor Color { get; set; }

    // Конструктор
    public Button(string text, int x, int y, ConsoleColor color) : base(text, x, y)
    {
        Color = color;
    }

    // Собственный метод (для переопределения)
    public virtual void Click()
    {
        if (IsActive)
        {
            Console.WriteLine($"Кнопка '{Text}' была нажата.");
        }
        else
        {
            Console.WriteLine($"Невозможно нажать кнопку '{Text}', она заблокирована.");
        }
    }
}