//5
public sealed class RoundButton : Button
{
    // Собственное свойство
    public int Radius { get; set; }

    // Конструктор
    public RoundButton(string text, int x, int y, ConsoleColor color, int radius) : base(text, x, y, color)
    {
        Radius = radius;
    }
    
    // Собственный метод
    public void Spin()
    {
        Console.WriteLine($"Круглая кнопка '{Text}' вращается.");
    }
}