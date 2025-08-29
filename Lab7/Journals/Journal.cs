using Lab7.Collections;
using Lab7.Models;
using Lab7.Journals;

namespace Lab7.Journals;

public class Journal
{
    private readonly List<JournalEntry> entries = new();

    // обработчик для обоих типов событий
    public void CollectionChanged(object source, StudentListHandlerEventArgs args)
    {
        entries.Add(new JournalEntry(
            args.CollectionName,
            args.ChangeType,
            args.ChangedStudent?.ToShortString() ?? "null"
        ));
    }

    public override string ToString()
        => string.Join("\n", entries);
}