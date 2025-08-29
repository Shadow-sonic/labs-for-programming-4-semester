using Lab7.Collections;
using Lab7.Models;
using Lab7.Journals;

namespace Lab7.Journals;

public class JournalEntry
{
    public string CollectionName { get; }
    public string ChangeType { get; }
    public string StudentInfo { get; }

    public JournalEntry(string collectionName, string changeType, string studentInfo)
    {
        CollectionName = collectionName;
        ChangeType = changeType;
        StudentInfo = studentInfo;
    }

    public override string ToString()
        => $"[{CollectionName}] {ChangeType} — {StudentInfo}";
}