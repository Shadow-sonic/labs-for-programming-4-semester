using Lab7.Collections;
using Lab7.Models;
using Lab7.Journals;

namespace Lab7;

public static class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // 1. Создать две коллекции StudentCollection
        var sc1 = new StudentCollectionWithEvents("Коллекция №1");
        var sc2 = new StudentCollectionWithEvents("Коллекция №2");

        // 2. Создать два журнала
        var j1 = new Journal();
        var j2 = new Journal();

        // j1 подписан на оба события только из первой коллекции
        sc1.StudentsCountChanged += j1.CollectionChanged;
        sc1.StudentReferenceChanged += j1.CollectionChanged;

        // j2 подписан только на StudentReferenceChanged из обеих коллекций
        sc1.StudentReferenceChanged += j2.CollectionChanged;
        sc2.StudentReferenceChanged += j2.CollectionChanged;

        // 3. Внести изменения
        var stA = new Student("Анна", "Кузнецова", new DateTime(2002, 3, 12), Education.Bachelor, "22-Б");
        var stB = new Student("Петр", "Петров", new DateTime(2000, 10, 5), Education.Specialist, "20-СП");
        var stC = new Student("Светлана", "Сидорова", new DateTime(1999, 6, 30), Education.Master, "19-М");

        // Добавления
        sc1.AddStudents(stA, stB);
        sc2.AddStudents(stC);

        // Замена по индексатору
        sc1[0] = new Student("Алексей", "Смирнов", new DateTime(2001, 5, 1), Education.Bachelor, "21-Б");
        sc2[0] = new Student("Игорь", "Новиков", new DateTime(2000, 8, 20), Education.Specialist, "20-СП");

        // Удаление по индексу
        sc1.Remove(1);

        // 4. Вывод журналов
        Console.WriteLine("\n=== Журнал 1 (оба события, только Коллекция №1) ===");
        Console.WriteLine(j1);

        Console.WriteLine("\n=== Журнал 2 (ReferenceChanged из обеих коллекций) ===");
        Console.WriteLine(j2);

    }
}
