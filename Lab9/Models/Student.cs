using System.Runtime.Serialization.Formatters.Binary;

namespace Lab9.Models;

[Serializable]
public class Student : ICloneable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Education EducationForm { get; set; }
    public string Group { get; set; }
    public List<Exam> Exams { get; set; } = new();

    public Student() { }

    public Student(string first, string last, Education edu, string group, List<Exam> exams)
    {
        FirstName = first;
        LastName = last;
        EducationForm = edu;
        Group = group;
        Exams = exams;
    }

    // --- Глубокое копирование ---
    public object Clone()
    {
        return DeepCopy();
    }

    public Student DeepCopy()
    {
        var copy = new Student(FirstName, LastName, EducationForm, Group, new List<Exam>());
        foreach (var exam in Exams)
            copy.Exams.Add(new Exam(exam.Subject, exam.Mark, exam.Date));
        return copy;
    }

    // --- Экземплярные методы ---
    public bool Save(string filename)
    {
        try
        {
            using FileStream fs = new FileStream(filename, FileMode.Create);
#pragma warning disable SYSLIB0011
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, this);
#pragma warning restore SYSLIB0011
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при сохранении: {ex.Message}");
            return false;
        }
    }

    public bool Load(string filename)
    {
        try
        {
            if (!File.Exists(filename))
                return false;

            using FileStream fs = new FileStream(filename, FileMode.Open);
#pragma warning disable SYSLIB0011
            BinaryFormatter bf = new BinaryFormatter();
            Student? obj = bf.Deserialize(fs) as Student;
#pragma warning restore SYSLIB0011

            if (obj == null) return false;

            // копируем данные
            FirstName = obj.FirstName;
            LastName = obj.LastName;
            EducationForm = obj.EducationForm;
            Group = obj.Group;
            Exams = obj.Exams;

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при загрузке: {ex.Message}");
            return false;
        }
    }

    public bool AddFromConsole()
    {
        Console.WriteLine("Введите экзамен (формат: предмет;оценка;дата): ");
        Console.WriteLine("Дата в формате ГГГГ-ММ-ДД");
        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
            return false;

        try
        {
            var parts = input.Split(';');
            if (parts.Length != 3)
                throw new Exception("Неверный формат данных!");

            string subject = parts[0].Trim();
            int mark = int.Parse(parts[1]);
            DateTime date = DateTime.Parse(parts[2]);

            Exams.Add(new Exam(subject, mark, date));
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка ввода: {ex.Message}");
            return false;
        }
    }

    // --- Статические методы ---
    public static bool Save(string filename, Student obj)
    {
        return obj.Save(filename);
    }

    public static bool Load(string filename, Student obj)
    {
        return obj.Load(filename);
    }

    public override string ToString()
    {
        string exams = Exams.Count == 0 ? "нет экзаменов" : string.Join("; ", Exams);
        return $"{LastName} {FirstName}, {EducationForm}, группа {Group}, Экзамены: {exams}";
    }
}