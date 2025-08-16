using System;

namespace Lab4;
// 1. Абстрактный корневой класс
public abstract class UIElementAbstract
{
    // Общие свойства, доступные для всех потомков
    public string Text { get; set; }
    public int XPosition { get; set; }
    public int YPosition { get; set; }

    // Конструктор
    public UIElementAbstract(string text, int x, int y)
    {
        Text = text;
        XPosition = x;
        YPosition = y;
    }

    // Абстрактный метод, который должен быть реализован в каждом неабстрактном потомке
    public abstract void Render();

    // Перегруженный метод ToString() для базового вывода
    public override string ToString()
    {
        return $"Тип: {GetType().Name}, Текст: '{Text}', Позиция: ({XPosition}, {YPosition})";
    }
}