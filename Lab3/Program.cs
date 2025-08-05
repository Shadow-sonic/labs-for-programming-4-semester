using System;
using System.Linq;

namespace Lab3;

class Program
{
    static void Main(string[] args)
    {
        // 5. Создание объекта Student и вывод ToShortString()
        Student student = new Student(new Person("Иван", "Иванов", new DateTime(2002, 5, 10)), Education.Bachelor, 301);
        Console.WriteLine("Пункт 5: Вывод ToShortString()");
        Console.WriteLine(student.ToShortString());
        Console.WriteLine("---------------------------------\n");

        // 6. Вывод значений индексатора
        Console.WriteLine("Пункт 6: Вывод индексатора");
        Console.WriteLine($"Education.Specialist: {student[Education.Specialist]}");
        Console.WriteLine($"Education.Bachelor: {student[Education.Bachelor]}");
        Console.WriteLine($"Education.SecondEducation: {student[Education.SecondEducation]}");
        Console.WriteLine("---------------------------------\n");

        // 7. Присвоение значений свойствам и вывод ToString()
        student.PersonData.Name = "Петр";
        student.PersonData.Surname = "Петров";
        student.EducationForm = Education.Specialist;
        student.GroupNumber = 401;
        Console.WriteLine("Пункт 7: Вывод ToString() после присвоения значений");
        Console.WriteLine(student.ToString());
        Console.WriteLine("---------------------------------\n");

        // 8. Добавление экзаменов и вывод ToString()
        student.AddExams(
            new Exam("Математика", 5, new DateTime(2023, 1, 15)),
            new Exam("Физика", 4, new DateTime(2023, 1, 20)),
            new Exam("Информатика", 5, new DateTime(2023, 1, 25))
        );
        Console.WriteLine("Пункт 8: Вывод ToString() после добавления экзаменов");
        Console.WriteLine(student.ToString());
        Console.WriteLine("---------------------------------\n");

        // 9. Сравнение времени выполнения операций с массивами типа Exam
        Console.WriteLine("Пункт 9: Сравнение времени выполнения операций с массивами Exam");
        Console.WriteLine("Введите число строк и столбцов через пробел, запятую или точку с запятой (например, 5 10):");
        string input = Console.ReadLine();
        string[] dimensions = input.Split(new char[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);

        int nrow = int.Parse(dimensions[0]);
        int ncolumn = int.Parse(dimensions[1]);
        int totalElements = nrow * ncolumn;

        // Инициализация массивов
        Exam[] oneDimensionalArray = new Exam[totalElements];
        for (int i = 0; i < totalElements; i++)
        {
            oneDimensionalArray[i] = new Exam();
        }

        Exam[,] twoDimensionalArray = new Exam[nrow, ncolumn];
        for (int i = 0; i < nrow; i++)
        {
            for (int j = 0; j < ncolumn; j++)
            {
                twoDimensionalArray[i, j] = new Exam();
            }
        }

        Exam[][] jaggedArray = new Exam[nrow][];
        for (int i = 0; i < nrow; i++)
        {
            int elementsInRow = totalElements / nrow + (i < totalElements % nrow ? 1 : 0);
            jaggedArray[i] = new Exam[elementsInRow];
            for (int j = 0; j < elementsInRow; j++)
            {
                jaggedArray[i][j] = new Exam();
            }
        }

        Console.WriteLine($"\nЧисло строк: {nrow}, Число столбцов: {ncolumn}");

        // Измерение времени для одномерного массива
        int startTimeOneD = Environment.TickCount;
        for (int i = 0; i < totalElements; i++)
        {
            oneDimensionalArray[i].Grade = 5;
        }
        int endTimeOneD = Environment.TickCount;
        int timeOneD = endTimeOneD - startTimeOneD;
        Console.WriteLine($"Время выполнения для одномерного массива: {timeOneD} мс");

        // Измерение времени для двумерного прямоугольного массива
        int startTimeTwoD = Environment.TickCount;
        for (int i = 0; i < nrow; i++)
        {
            for (int j = 0; j < ncolumn; j++)
            {
                twoDimensionalArray[i, j].Grade = 5;
            }
        }
        int endTimeTwoD = Environment.TickCount;
        int timeTwoD = endTimeTwoD - startTimeTwoD;
        Console.WriteLine($"Время выполнения для двумерного прямоугольного массива: {timeTwoD} мс");

        // Измерение времени для двумерного ступенчатого массива
        int startTimeJagged = Environment.TickCount;
        for (int i = 0; i < nrow; i++)
        {
            for (int j = 0; j < jaggedArray[i].Length; j++)
            {
                jaggedArray[i][j].Grade = 5;
            }
        }
        int endTimeJagged = Environment.TickCount;
        int timeJagged = endTimeJagged - startTimeJagged;
        Console.WriteLine($"Время выполнения для двумерного ступенчатого массива: {timeJagged} мс");
    }
}
