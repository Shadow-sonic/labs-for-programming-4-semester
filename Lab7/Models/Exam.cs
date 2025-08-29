
using Lab7.Collections;
using Lab7.Models;
using Lab7.Journals;

namespace Lab7.Models;

public sealed class Exam
{
    public string Subject { get; set; }
    public int Mark { get; set; }
    public DateTime Date { get; set; }

    public Exam(string subject, int mark, DateTime date)
    {
        Subject = subject;
        Mark = mark;
        Date = date;
    }

    public override string ToString()
        => $"{Subject}: {Mark} ({Date:yyyy-MM-dd})";
}

