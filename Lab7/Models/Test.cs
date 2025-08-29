using Lab7.Collections;
using Lab7.Models;
using Lab7.Journals;

namespace Lab7.Models;

public sealed class Test
{
    public string Subject { get; set; }
    public bool IsPassed { get; set; }

    public Test(string subject, bool isPassed)
    {
        Subject = subject;
        IsPassed = isPassed;
    }

    public override string ToString()
        => $"{Subject}: {(IsPassed ? "зачтено" : "не зачтено")}";
}