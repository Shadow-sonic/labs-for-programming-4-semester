public class StudentCollection
{
    private readonly List<Student> _students = new();

    public void AddDefaults()
    {
        var s1 = new Student("Иван", "Иванов", new DateTime(2001, 2, 15), Education.Specialist, "21-СП");
        s1.AddExams(new Exam("Матанализ", 90, DateTime.Today.AddDays(-100)),
                    new Exam("ООП", 86, DateTime.Today.AddDays(-80)));
        s1.AddTests(new Test("КПиЯП", true), new Test("Физ-ра", true));

        var s2 = new Student("Петр", "Петров", new DateTime(2000, 10, 5), Education.Bachelor, "20-Б")
            { };
        s2.AddExams(new Exam("Алгебра", 75, DateTime.Today.AddDays(-120)),
                    new Exam("БД", 82, DateTime.Today.AddDays(-60)));
        s2.AddTests(new Test("История", true));

        var s3 = new Student("Светлана", "Сидорова", new DateTime(1999, 6, 30), Education.Master, "19-М");
        s3.AddExams(new Exam("Философия", 88, DateTime.Today.AddDays(-90)),
                    new Exam("Сети", 92, DateTime.Today.AddDays(-50)));
        s3.AddTests(new Test("Психология", true), new Test("Английский", true));

        AddStudents(s1, s2, s3);
    }

    public void AddStudents(params Student[] students) => _students.AddRange(students);

    public override string ToString()
        => string.Join("\n\n", _students.Select(s => s.ToString()));

    public string ToShortString()
        => string.Join("\n", _students.Select(s => s.ToShortString()));

    // Сортировки
    public void SortByLastName()
        => _students.Sort(); // Person : IComparable — сравнение по фамилии/имени

    public void SortByBirthDate()
    {
        // Person реализует IComparer<Person> — используем адаптер
        var comparer = new Person(); // как IComparer<Person>
        _students.Sort((a, b) => comparer.Compare(a, b));
    }

    public void SortByAverageMark()
        => _students.Sort(new StudentAverageMarkComparer());

    // Свойства/методы по заданию
    public double MaxAverageMark => _students.Count == 0 ? 0.0 : _students.Max(s => s.AverageMark);

    public IEnumerable<Student> Specialists => _students.Where(s => s.Education == Education.Specialist);

    public List<Student> AverageMarkGroup(double value)
        => _students.Where(s => Math.Abs(s.AverageMark - value) < 1e-9).ToList();

    // Для вывода групп по среднему — вспомогательный метод
    public IEnumerable<IGrouping<double, Student>> GroupByAverage()
        => _students.GroupBy(s => s.AverageMark);
}
