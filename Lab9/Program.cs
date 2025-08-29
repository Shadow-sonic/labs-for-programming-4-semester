
using Lab9.Models;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // 1. Создание объекта
        var student = new Student("Иван", "Иванов", Education.Bachelor, "21-Б",
            new System.Collections.Generic.List<Exam>
            {
                new Exam("Математика", 5, new DateTime(2023,6,1)),
                new Exam("Физика", 4, new DateTime(2023,6,3))
            });

        var copy = student.DeepCopy();

        Console.WriteLine("Исходный объект:");
        Console.WriteLine(student);
        Console.WriteLine("\nКопия:");
        Console.WriteLine(copy);

        // 2. Ввод имени файла
        Console.Write("\nВведите имя файла: ");
        string filename = Console.ReadLine() ?? "student.dat";

        if (!File.Exists(filename))
        {
            Console.WriteLine("Файл не найден, создаём новый...");
            student.Save(filename);
        }
        else
        {
            student.Load(filename);
        }

        Console.WriteLine("\nОбъект после загрузки:");
        Console.WriteLine(student);

        // 4. Добавление экзамена и сохранение
        if (student.AddFromConsole())
        {
            student.Save(filename);
        }

        Console.WriteLine("\nПосле добавления:");
        Console.WriteLine(student);

        // 5. Использование статических методов
        Student.Load(filename, student);
        student.AddFromConsole();
        Student.Save(filename, student);

        Console.WriteLine("\nПосле статических методов:");
        Console.WriteLine(student);

        // 7. Рекурсивный вывод файлов и папок
        Console.WriteLine("\nСодержимое текущей папки:");
        PrintDirectory(new DirectoryInfo(Directory.GetCurrentDirectory()), "");
    }

    static void PrintDirectory(DirectoryInfo dir, string indent)
    {
        Console.WriteLine($"{indent}[{dir.Name}]");
        foreach (var file in dir.GetFiles())
        {
            Console.WriteLine($"{indent}  {file.Name}");
        }
        foreach (var subDir in dir.GetDirectories())
        {
            PrintDirectory(subDir, indent + "  ");
        }
    }
}