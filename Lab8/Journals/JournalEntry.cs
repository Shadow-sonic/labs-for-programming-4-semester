using Lab8.Collections;
using Lab8.Models;
using Lab8.Journals;

namespace Lab8.Journals;
public class JournalEntry
{
    public string CollectionName { get; }
    public Collections.Action ChangeType { get; }
    public string PropertyName { get; }
    public string KeyInfo { get; }

    public JournalEntry(string collectionName, Collections.Action changeType, string propertyName, string keyInfo)
    {
        CollectionName = collectionName;
        ChangeType = changeType;
        PropertyName = propertyName;
        KeyInfo = keyInfo;
    }

    public override string ToString()
        => $"[{CollectionName}] {ChangeType}, свойство: {PropertyName}, ключ: {KeyInfo}";
}