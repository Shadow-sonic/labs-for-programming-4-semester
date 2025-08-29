
using Lab7.Collections;
using Lab7.Models;
using Lab7.Journals;
namespace Lab7.Models;

public class Student : Person
{
    public Education Education { get; set; }
    public string Group { get; set; }

    // Требование ЛР6: списки зачетов и экзаменов как List<Test> и List<Exam>
    public List<Test> Tests { get; } = new();
    public List<Exam> Exams { get; } = new();

    // Свойство среднего балла по экзаменам
    public double AverageMark => Exams.Count == 0 ? 0 : Exams.Average(e => e.Mark);

    // Требование про TValue: должно быть свойство, возвращающее ссылку на объект TKey (Person)
    // с совпадающими данными базовой части. ВАЖНО: возвращаем НЕ this, а НОВЫЙ Person.
    public Person BasePerson => new Person(FirstName, LastName, BirthDate);

    public Student() : this("Имя", "Фамилия", new DateTime(2000, 1, 1),
                            Education.Bachelor, "00-00")
    { }

    public Student(string firstName, string lastName, DateTime birthDate,
                   Education education, string group)
        : base(firstName, lastName, birthDate)
    {
        Education = education;
        Group = group;
    }

    public void AddExams(params Exam[] exams) => Exams.AddRange(exams);
    public void AddTests(params Test[] tests) => Tests.AddRange(tests);

    public override string ToString()
    {
        var examsStr = Exams.Count == 0 ? "нет"
            : string.Join("; ", Exams.Select(e => e.ToString()));
        var testsStr = Tests.Count == 0 ? "нет"
            : string.Join("; ", Tests.Select(t => t.ToString()));

        return $"{base.ToString()}, {Education}, группа {Group}\n" +
               $"Экзамены: {examsStr}\n" +
               $"Зачёты: {testsStr}\n" +
               $"Средний балл: {AverageMark:F2}";
    }

    public override string ToShortString()
        => $"{base.ToShortString()}, {Education}, группа {Group}, " +
           $"Avg={AverageMark:F2}, зачётов={Tests.Count}, экзаменов={Exams.Count}";

    // Для ContainsValue по словарю — считаем студентов равными, если равны их базовые Person-части
    public override bool Equals(object? obj)
    {
        if (obj is not Student s) return false;
        // Важное решение: равенство студентов определяем по базовым полям Person
        return base.Equals((Person)s);
    }

    public override int GetHashCode()
        => base.GetHashCode();
}
