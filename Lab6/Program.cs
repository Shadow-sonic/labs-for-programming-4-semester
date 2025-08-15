public static class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding  = System.Text.Encoding.UTF8;

        // ===== 1. StudentCollection: добавление и вывод =====
        Console.WriteLine("=== 1) StudentCollection: добавление и вывод ===");
        var sc = new StudentCollection();
        sc.AddDefaults();
        sc.AddStudents(
            new Student("Анна", "Кузнецова", new DateTime(2002, 3, 12), Education.Specialist, "22-СП")
            {
                // заполнение для наглядности
            }
        );
        // Пара экзаменов Анне:
        sc.AverageMarkGroup(0); // просто вызов, чтобы убедиться в наличии метода
        Console.WriteLine("\nПолный вывод:\n");
        Console.WriteLine(sc.ToString());

        // ===== 2. Сортировки =====
        Console.WriteLine("\n=== 2) Сортировки ===");

        Console.WriteLine("\n— По фамилии:");
        sc.SortByLastName();
        Console.WriteLine(sc.ToShortString());

        Console.WriteLine("\n— По дате рождения:");
        sc.SortByBirthDate();
        Console.WriteLine(sc.ToShortString());

        Console.WriteLine("\n— По среднему баллу:");
        sc.SortByAverageMark();
        Console.WriteLine(sc.ToShortString());

        // ===== 3. Операции со списком =====
        Console.WriteLine("\n=== 3) Операции со списком ===");
        Console.WriteLine($"Максимальный средний балл: {sc.MaxAverageMark:F2}");

        Console.WriteLine("\nСтуденты с формой обучения Specialist:");
        foreach (var s in sc.Specialists)
            Console.WriteLine("  " + s.ToShortString());

        Console.WriteLine("\nГруппировка по среднему баллу:");
        foreach (var grp in sc.GroupByAverage())
        {
            Console.WriteLine($"  Avg={grp.Key:F2}:");
            foreach (var s in grp)
                Console.WriteLine("    " + s.ToShortString());
        }

        // ===== 4. TestCollections + замеры =====
        Console.WriteLine("\n=== 4) TestCollections: замеры поиска ===");
        int count = ReadPositiveInt("Введите число элементов коллекций: ");
        var tc = new TestCollections(count);
        tc.SearchTest();

        Console.WriteLine("\nГотово. Нажмите Enter, чтобы выйти...");
        Console.ReadLine();
    }

    private static int ReadPositiveInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? s = Console.ReadLine();
            try
            {
                if (int.TryParse(s, out int v) && v >= 0)
                    return v;

                throw new FormatException("Ожидалось неотрицательное целое число.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка ввода: {ex.Message}. Повторите попытку.\n");
            }
        }
    }
}
