using Lab8.Collections;
using Lab8.Models;
using Lab8.Journals;

namespace Lab8;

public static class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        var sc1 = new StudentCollection<string>("Коллекция №1");
        var sc2 = new StudentCollection<string>("Коллекция №2");

        var journal = new Journals.Journal();

        // Подписка
        sc1.StudentsChanged += journal.OnStudentsChanged;
        sc2.StudentsChanged += journal.OnStudentsChanged;

        // Студенты
        var st1 = new Student("Анна", "Кузнецова", new DateTime(2002, 3, 12), Education.Bachelor, "22-Б");
        var st2 = new Student("Петр", "Петров", new DateTime(2000, 10, 5), Education.Specialist, "20-СП");

        // Добавление
        sc1.Add("st1", st1);
        sc2.Add("st2", st2);

        // Изменение свойств
        st1.Group = "33-Б";
        st2.EducationForm = Education.Master;

        // Удаление
        sc1.Remove(st1);

        // Изменение уже удалённого элемента
        st1.Group = "44-Б"; 

        Console.WriteLine("=== Журнал изменений ===");
        Console.WriteLine(journal);
    }
}
