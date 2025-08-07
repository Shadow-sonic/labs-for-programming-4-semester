namespace Lab5;
// Класс Person
public class Person : IDateAndCopy
{
    protected string name;
    protected string surname;
    protected DateTime dateOfBirth;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Surname
    {
        get { return surname; }
        set { surname = value; }
    }

    public DateTime Date
    {
        get { return dateOfBirth; }
        set { dateOfBirth = value; }
    }

    public Person(string name, string surname, DateTime dateOfBirth)
    {
        this.name = name;
        this.surname = surname;
        this.dateOfBirth = dateOfBirth;
    }

    public Person()
    {
        name = "DefaultName";
        surname = "DefaultSurname";
        dateOfBirth = new DateTime(2000, 1, 1);
    }

    public override string ToString()
    {
        return $"Имя: {name}, Фамилия: {surname}, Дата рождения: {dateOfBirth.ToShortDateString()}";
    }

    public virtual string ToShortString()
    {
        return $"Имя: {name}, Фамилия: {surname}";
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        var other = (Person)obj;
        return name == other.name && surname == other.surname && dateOfBirth == other.dateOfBirth;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(name, surname, dateOfBirth);
    }

    public static bool operator ==(Person p1, Person p2)
    {
        if (ReferenceEquals(p1, null))
        {
            return ReferenceEquals(p2, null);
        }
        return p1.Equals(p2);
    }

    public static bool operator !=(Person p1, Person p2)
    {
        return !(p1 == p2);
    }

    public virtual object DeepCopy()
    {
        return new Person(name, surname, dateOfBirth);
    }
}