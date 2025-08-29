using Lab7.Collections;
using Lab7.Models;
using Lab7.Journals;

namespace Lab7.Collections;

public class StudentCollectionWithEvents
{
    private readonly List<Student> students = new();

    public string CollectionName { get; set; }

    public StudentCollectionWithEvents(string name)
    {
        CollectionName = name;
    }

    // события
    public event StudentListHandler? StudentsCountChanged;
    public event StudentListHandler? StudentReferenceChanged;

    // методы
    public void AddDefaults()
    {
        var s = new Student("Иван", "Иванов", new DateTime(2001, 2, 15), Education.Specialist, "21-СП");
        AddStudents(s);
    }

    public void AddStudents(params Student[] studs)
    {
        foreach (var s in studs)
        {
            students.Add(s);
            StudentsCountChanged?.Invoke(this,
                new StudentListHandlerEventArgs(CollectionName, "Добавлен элемент", s));
        }
    }

    public bool Remove(int j)
    {
        if (j < 0 || j >= students.Count)
            return false;
            
        var removed = students[j];
        students.RemoveAt(j);
        StudentsCountChanged?.Invoke(this,
            new StudentListHandlerEventArgs(CollectionName, "Удалён элемент", removed));
        return true;
    }

    // индексатор
    public Student this[int index]
    {
        get => students[index];
        set
        {
            students[index] = value;
            StudentReferenceChanged?.Invoke(this,
                new StudentListHandlerEventArgs(CollectionName, "Заменён элемент", value));
        }
    }

    public override string ToString()
        => string.Join("\n", students);
}
