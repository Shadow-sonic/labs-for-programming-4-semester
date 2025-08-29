//2
namespace Lab4;
public class Control : UIElement
{
    // Собственное свойство
    public bool IsActive { get; set; }

    // Конструктор
    public Control(string text, int x, int y) : base(text, x, y)
    {
        IsActive = true;
    }

    // Переопределение абстрактного метода
    public override void Render()
    {
        Console.WriteLine($"Отрисовка элемента управления '{Text}'. Он {(IsActive ? "активен" : "неактивен")}.");
    }

    // Переопределение ToString()
    public override string ToString()
    {
        return base.ToString() + $", Активен: {IsActive}";
    }

    // Собственный метод
    public void Disable()
    {
        IsActive = false;
        Console.WriteLine($"Элемент управления '{Text}' заблокирован.");
    }

}