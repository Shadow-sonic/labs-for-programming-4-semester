namespace Lab3;
public class Student
{
    private Person personData;
    private Education educationForm;
    private int groupNumber;
    private Exam[] exams;

    public Student(Person personData, Education educationForm, int groupNumber)
    {
        this.personData = personData;
        this.educationForm = educationForm;
        this.groupNumber = groupNumber;
        this.exams = new Exam[0];
    }

    public Student()
    {
        personData = new Person();
        educationForm = Education.Bachelor;
        groupNumber = 101;
        exams = new Exam[0];
    }

    public Person PersonData
    {
        get { return personData; }
        set { personData = value; }
    }

    public Education EducationForm
    {
        get { return educationForm; }
        set { educationForm = value; }
    }

    public int GroupNumber
    {
        get { return groupNumber; }
        set { groupNumber = value; }
    }

    public Exam[] Exams
    {
        get { return exams; }
        set { exams = value; }
    }

    public double AverageGrade
    {
        get
        {
            if (exams == null || exams.Length == 0)
            {
                return 0;
            }
            return exams.Average(e => e.Grade);
        }
    }

    public bool this[Education education]
    {
        get { return educationForm == education; }
    }

    public void AddExams(params Exam[] newExams)
    {
        if (newExams == null || newExams.Length == 0)
        {
            return;
        }

        int originalLength = exams.Length;
        Array.Resize(ref exams, originalLength + newExams.Length);
        Array.Copy(newExams, 0, exams, originalLength, newExams.Length);
    }

    public override string ToString()
    {
        string examsString = exams != null && exams.Length > 0
            ? string.Join("\n", exams.Select(e => e.ToString()))
            : "Нет сданных экзаменов";

        return $"Студент: {personData}\n" +
               $"Форма обучения: {educationForm}\n" +
               $"Группа: {groupNumber}\n" +
               $"Экзамены:\n{examsString}";
    }

    public virtual string ToShortString()
    {
        return $"Студент: {personData.ToShortString()}\n" +
               $"Форма обучения: {educationForm}\n" +
               $"Группа: {groupNumber}\n" +
               $"Средний балл: {AverageGrade:F2}";
    }
}
