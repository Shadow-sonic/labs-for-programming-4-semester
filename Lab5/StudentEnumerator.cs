namespace Lab5;
// Вспомогательный класс для итератора
public class StudentEnumerator : IEnumerator<object>
{
    private readonly Student student;
    private int position = -1;
    private readonly List<string> subjectNames;

    public StudentEnumerator(Student student)
    {
        this.student = student;
        var examSubjects = student.Exams.Cast<Exam>().Select(e => e.SubjectName);
        var testSubjects = student.Tests.Cast<Test>().Select(t => t.SubjectName);
        subjectNames = examSubjects.Intersect(testSubjects).ToList();
    }

    public bool MoveNext()
    {
        position++;
        return position < subjectNames.Count;
    }

    public void Reset()
    {
        position = -1;
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public object Current
    {
        get
        {
            try
            {
                return subjectNames[position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }
}