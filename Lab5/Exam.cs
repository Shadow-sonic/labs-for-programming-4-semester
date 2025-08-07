namespace Lab5;
// Класс Exam для экзаменов
public class Exam : IDateAndCopy
{
    public string SubjectName { get; set; }
    public int Grade { get; set; }
    public DateTime Date { get; set; }

    public Exam(string subjectName, int grade, DateTime examDate)
    {
        SubjectName = subjectName;
        Grade = grade;
        Date = examDate;
    }

    public Exam()
    {
        SubjectName = "Default Subject";
        Grade = 0;
        Date = new DateTime(2000, 1, 1);
    }

    public override string ToString()
    {
        return $"Предмет: {SubjectName}, Оценка: {Grade}, Дата: {Date.ToShortDateString()}";
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        var other = (Exam)obj;
        return SubjectName == other.SubjectName && Grade == other.Grade && Date == other.Date;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(SubjectName, Grade, Date);
    }

    public object DeepCopy()
    {
        return new Exam(SubjectName, Grade, Date);
    }
}