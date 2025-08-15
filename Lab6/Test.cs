
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