namespace Lab5;
// Интерфейс для глубокого копирования и даты
public interface IDateAndCopy
{
    object DeepCopy();
    DateTime Date { get; set; }
}
