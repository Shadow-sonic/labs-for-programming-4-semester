using Lab8.Collections;
using Lab8.Models;
using Lab8.Journals;

namespace Lab8.Collections;

public enum Action { Add, Remove, Property }

public class StudentsChangedEventArgs<TKey> : EventArgs
{
    public string CollectionName { get; }
    public Action ChangeType { get; }
    public string PropertyName { get; }
    public TKey Key { get; }

    public StudentsChangedEventArgs(string collectionName, Action changeType, string propertyName, TKey key)
    {
        CollectionName = collectionName;
        ChangeType = changeType;
        PropertyName = propertyName;
        Key = key;
    }

    public override string ToString()
        => $"Коллекция: {CollectionName}, Изменение: {ChangeType}, " +
            $"Свойство: {PropertyName}, Ключ: {Key}";
}

public delegate void StudentsChangedHandler<TKey>(object source, StudentsChangedEventArgs<TKey> args);