namespace Lab5;

public class Student : Person, IDateAndCopy, IEnumerable<object>
{
    private Education educationForm;
    private int groupNumber;
    private List<Exam> exams;  // заменил ArrayList на дженерик
    private List<Test> tests;  // то же самое

    public Education EducationForm
    {
        get => educationForm;
        set => educationForm = value;
    }

    public int GroupNumber
    {
        get => groupNumber;
        set
        {
            if (value <= 100 || value >= 599)
                throw new ArgumentOutOfRangeException(nameof(GroupNumber), "Номер группы должен быть от 101 до 599.");
            groupNumber = value;
        }
    }

    public Person PersonData
    {
        get => new Person(name, surname, dateOfBirth);
        set
        {
            name = value.Name;
            surname = value.Surname;
            dateOfBirth = value.Date;
        }
    }

    public List<Exam> Exams
    {
        get => exams;
        set => exams = value;
    }

    public List<Test> Tests
    {
        get => tests;
        set => tests = value;
    }

    public double AverageGrade => exams == null || exams.Count == 0
        ? 0
        : exams.Average(e => e.Grade);

    public Student(Person person, Education education, int group)
        : base(person.Name, person.Surname, person.Date)
    {
        educationForm = education;
        GroupNumber = group;
        exams = new List<Exam>();
        tests = new List<Test>();
    }

    public Student() : base()
    {
        educationForm = Education.Bachelor;
        groupNumber = 101;
        exams = new List<Exam>();
        tests = new List<Test>();
    }

    public override string ToString()
    {
        string examsStr = exams.Count > 0 ? string.Join("\n", exams) : "Нет экзаменов.";
        string testsStr = tests.Count > 0 ? string.Join("\n", tests) : "Нет зачетов.";

        return $"Студент: {base.ToString()}\n" +
               $"Форма обучения: {educationForm}\n" +
               $"Группа: {groupNumber}\n" +
               $"Экзамены:\n{examsStr}\n" +
               $"Зачеты:\n{testsStr}";
    }

    public override string ToShortString()
    {
        return $"Студент: {base.ToShortString()}\n" +
               $"Форма обучения: {educationForm}\n" +
               $"Группа: {groupNumber}\n" +
               $"Средний балл: {AverageGrade:F2}";
    }

    public void AddExams(params Exam[] newExams) => exams.AddRange(newExams);

    public void AddTests(params Test[] newTests) => tests.AddRange(newTests);

    public override object DeepCopy()
    {
        var studentCopy = new Student(new Person(name, surname, dateOfBirth), educationForm, groupNumber)
        {
            exams = exams.Select(e => (Exam)e.DeepCopy()).ToList(),
            tests = tests.Select(t => (Test)t.DeepCopy()).ToList()
        };
        return studentCopy;
    }

    // --- Универсальные итераторы ---
    public IEnumerable<object> AllExamsAndTestsIterator()
    {
        foreach (var exam in exams) yield return exam;
        foreach (var test in tests) yield return test;
    }

    public IEnumerable<object> ExamsWithGradeGreaterThan(int grade)
    {
        foreach (Exam exam in exams)
            if (exam.Grade > grade)
                yield return exam;
    }

    public IEnumerator<object> GetEnumerator()
    {
        foreach (var e in exams) yield return e;
        foreach (var t in tests) yield return t;
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerable<object> PassedExamsAndTests()
    {
        foreach (Exam exam in exams)
            if (exam.Grade > 2)
                yield return exam;

        foreach (Test test in tests)
            if (test.IsPassed)
                yield return test;
    }

    public IEnumerable<Test> PassedTestsWithPassedExam()
    {
        var passedExamsSubjects = exams
            .Where(e => e.Grade > 2)
            .Select(e => e.SubjectName);

        foreach (Test test in tests)
            if (test.IsPassed && passedExamsSubjects.Contains(test.SubjectName))
                yield return test;
    }
}
