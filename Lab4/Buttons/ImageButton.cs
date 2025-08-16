//4
namespace Lab4;
public class ImageButton : Button
{
    // Собственное свойство
    public string ImagePath { get; set; }

    // Конструктор
    public ImageButton(string text, int x, int y, ConsoleColor color, string imagePath) : base(text, x, y, color)
    {
        ImagePath = imagePath;
    }

    // Переопределение метода Click()
    public override void Click()
    {
        if (IsActive)
        {
            Console.WriteLine($"Кнопка '{Text}' с изображением '{ImagePath}' была нажата.");
        }
        else
        {
            Console.WriteLine($"Невозможно нажать кнопку '{Text}' с изображением, она заблокирована.");
        }
    }

    // Собственный метод
    public void DisplayImage()
    {
        Console.WriteLine($"Отображение изображения из файла: {ImagePath}");
    }
}