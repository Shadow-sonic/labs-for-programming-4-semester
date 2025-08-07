namespace Lab5;
// Класс Test для зачетов
public class Test : IDateAndCopy
{
    public string SubjectName { get; set; }
    public bool IsPassed { get; set; }
    public DateTime Date { get; set; }

    public Test(string subjectName, bool isPassed)
    {
        SubjectName = subjectName;
        IsPassed = isPassed;
        Date = DateTime.Now;
    }

    public Test()
    {
        SubjectName = "Default Subject";
        IsPassed = false;
        Date = DateTime.Now;
    }

    public override string ToString()
    {
        return $"Зачет: {SubjectName}, Сдан: {IsPassed}, Дата: {Date.ToShortDateString()}";
    }

    public object DeepCopy()
    {
        return new Test(SubjectName, IsPassed);
    }
}