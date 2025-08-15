
public class Person : IComparable, IComparer<Person>
{
    public string FirstName { get; set; }
    public string LastName  { get; set; }
    public DateTime BirthDate { get; set; }

    public Person() : this("Имя", "Фамилия", new DateTime(2000, 1, 1)) { }

    public Person(string firstName, string lastName, DateTime birthDate)
    {
        FirstName = firstName;
        LastName  = lastName;
        BirthDate = birthDate;
    }

    // IComparable — сравнение по фамилии (а затем по имени, чтобы порядок был стабильнее)
    public int CompareTo(object? obj)
    {
        if (obj is not Person other) throw new ArgumentException("Not a Person");
        int byLast = string.Compare(LastName, other.LastName, StringComparison.Ordinal);
        if (byLast != 0) return byLast;
        return string.Compare(FirstName, other.FirstName, StringComparison.Ordinal);
    }

    // IComparer<Person> — сравнение по дате рождения
    public int Compare(Person? x, Person? y)
    {
        if (x is null && y is null) return 0;
        if (x is null) return -1;
        if (y is null) return 1;
        return DateTime.Compare(x.BirthDate, y.BirthDate);
    }

    public override string ToString()
        => $"{LastName} {FirstName}, рожд. {BirthDate:yyyy-MM-dd}";

    public virtual string ToShortString()
        => $"{LastName} {FirstName}";

    #region Равенство/хеш — как в ЛР5 (нужно для ключей словаря)
    public override bool Equals(object? obj)
    {
        if (obj is not Person p) return false;
        return LastName == p.LastName
            && FirstName == p.FirstName
            && BirthDate == p.BirthDate;
    }

    public override int GetHashCode()
        => HashCode.Combine(LastName, FirstName, BirthDate);

    public static bool operator ==(Person a, Person b)
        => a is null ? b is null : a.Equals(b);

    public static bool operator !=(Person a, Person b)
        => !(a == b);
    #endregion
}