namespace Lab9.Models;

[Serializable]
public class Exam
{
    public string Subject { get; set; }
    public int Mark { get; set; }
    public DateTime Date { get; set; }

    public Exam() { }

    public Exam(string subject, int mark, DateTime date)
    {
        Subject = subject;
        Mark = mark;
        Date = date;
    }

    public override string ToString()
        => $"{Subject}, Оценка: {Mark}, Дата: {Date.ToShortDateString()}";
}