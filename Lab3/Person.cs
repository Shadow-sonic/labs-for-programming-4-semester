
namespace Lab3;

public class Person
{
    private string name;
    private string surname;
    private DateTime dateOfBirth;

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

    public DateTime DateOfBirth
    {
        get { return dateOfBirth; }
        set { dateOfBirth = value; }
    }

    public int YearOfBirth
    {
        get { return dateOfBirth.Year; }
        set { dateOfBirth = new DateTime(value, dateOfBirth.Month, dateOfBirth.Day); }
    }

    public override string ToString()
    {
        return $"Имя: {name}, Фамилия: {surname}, Дата рождения: {dateOfBirth.ToShortDateString()}";
    }

    public virtual string ToShortString()
    {
        return $"Имя: {name}, Фамилия: {surname}";
    }
}