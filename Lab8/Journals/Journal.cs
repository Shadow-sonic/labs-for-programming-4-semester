using Lab8.Collections;
using Lab8.Models;
using Lab8.Journals;

namespace Lab8.Journals;
public class Journal
{
    private readonly List<JournalEntry> entries = new();

    public void OnStudentsChanged<TKey>(object source, StudentsChangedEventArgs<TKey> args)
    {
        entries.Add(new JournalEntry(
            args.CollectionName,
            args.ChangeType,
            args.PropertyName,
            args.Key?.ToString() ?? "null"
        ));
    }

    public override string ToString()
        => string.Join("\n", entries);
}