namespace Lab5;
// Класс Student, производный от Person
public class Student : Person, IDateAndCopy, IEnumerable
{
    private Education educationForm;
    private int groupNumber;
    private ArrayList exams;
    private ArrayList tests;

    public Education EducationForm
    {
        get { return educationForm; }
        set { educationForm = value; }
    }

    public int GroupNumber
    {
        get { return groupNumber; }
        set
        {
            if (value <= 100 || value >= 599)
            {
                throw new ArgumentOutOfRangeException("groupNumber", "Номер группы должен быть в диапазоне от 101 до 599.");
            }
            groupNumber = value;
        }
    }

    public Person PersonData
    {
        get { return new Person(name, surname, dateOfBirth); }
        set
        {
            name = value.Name;
            surname = value.Surname;
            dateOfBirth = value.Date;
        }
    }

    public ArrayList Exams
    {
        get { return exams; }
        set { exams = value; }
    }

    public ArrayList Tests
    {
        get { return tests; }
        set { tests = value; }
    }

    public double AverageGrade
    {
        get
        {
            if (exams == null || exams.Count == 0)
            {
                return 0;
            }
            return exams.Cast<Exam>().Average(e => e.Grade);
        }
    }

    public Student(Person person, Education education, int group) : base(person.Name, person.Surname, person.Date)
    {
        educationForm = education;
        GroupNumber = group;
        exams = new ArrayList();
        tests = new ArrayList();
    }

    public Student() : base()
    {
        educationForm = Education.Bachelor;
        groupNumber = 101;
        exams = new ArrayList();
        tests = new ArrayList();
    }

    public override string ToString()
    {
        string examsStr = exams.Count > 0 ? string.Join("\n", exams.Cast<Exam>().Select(e => e.ToString())) : "Нет экзаменов.";
        string testsStr = tests.Count > 0 ? string.Join("\n", tests.Cast<Test>().Select(t => t.ToString())) : "Нет зачетов.";
        
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

    public void AddExams(params Exam[] newExams)
    {
        exams.AddRange(newExams);
    }

    public void AddTests(params Test[] newTests)
    {
        tests.AddRange(newTests);
    }

    public override object DeepCopy()
    {
        var studentCopy = new Student(new Person(name, surname, dateOfBirth), educationForm, groupNumber);
        studentCopy.exams = new ArrayList();
        foreach (Exam exam in exams)
        {
            studentCopy.exams.Add(exam.DeepCopy());
        }
        studentCopy.tests = new ArrayList();
        foreach (Test test in tests)
        {
            studentCopy.tests.Add(test.DeepCopy());
        }
        return studentCopy;
    }

    // Итератор для всех зачетов и экзаменов
    public IEnumerable AllExamsAndTestsIterator()
    {
        foreach (var exam in exams)
        {
            yield return exam;
        }
        foreach (var test in tests)
        {
            yield return test;
        }
    }

    // Итератор для экзаменов с оценкой выше заданного значения
    public IEnumerable ExamsWithGradeGreaterThan(int grade)
    {
        foreach (Exam exam in exams)
        {
            if (exam.Grade > grade)
            {
                yield return exam;
            }
        }
    }

    // Дополнительные итераторы
    public IEnumerator GetEnumerator()
    {
        return new StudentEnumerator(this);
    }

    public IEnumerable PassedExamsAndTests()
    {
        foreach (Exam exam in exams)
        {
            if (exam.Grade > 2)
            {
                yield return exam;
            }
        }
        foreach (Test test in tests)
        {
            if (test.IsPassed)
            {
                yield return test;
            }
        }
    }

    public IEnumerable PassedTestsWithPassedExam()
    {
        var passedExamsSubjects = exams.Cast<Exam>().Where(e => e.Grade > 2).Select(e => e.SubjectName);
        foreach (Test test in tests)
        {
            if (test.IsPassed && passedExamsSubjects.Contains(test.SubjectName))
            {
                yield return test;
            }
        }
    }
}
