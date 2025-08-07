using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lab5
{
    class Program
    {
        static void Main()
        {
            // 1. Создание двух объектов Person с совпадающими данными
            Console.WriteLine("Пункт 1: Проверка равенства объектов Person");
            Person p1 = new Person("Алексей", "Смирнов", new DateTime(1995, 10, 15));
            Person p2 = new Person("Алексей", "Смирнов", new DateTime(1995, 10, 15));
            Console.WriteLine($"p1 == p2: {p1 == p2}"); // True
            Console.WriteLine($"p1 != p2: {p1 != p2}"); // False
            Console.WriteLine($"Равны ли ссылки на объекты: {object.ReferenceEquals(p1, p2)}"); // False
            Console.WriteLine($"Хэш-код p1: {p1.GetHashCode()}");
            Console.WriteLine($"Хэш-код p2: {p2.GetHashCode()}");
            Console.WriteLine("---------------------------------\n");

            // 2. Создание объекта Student и добавление данных
            Console.WriteLine("Пункт 2: Создание объекта Student и вывод данных");
            Student student = new Student(new Person("Мария", "Иванова", new DateTime(2001, 3, 20)), Education.Specialist, 405);
            student.AddExams(
                new Exam("Математика", 5, new DateTime(2023, 1, 15)),
                new Exam("Физика", 4, new DateTime(2023, 1, 20))
            );
            student.AddTests(
                new Test("Математика", true),
                new Test("История", false)
            );
            Console.WriteLine(student.ToString());
            Console.WriteLine("---------------------------------\n");

            // 3. Вывод свойства типа Person
            Console.WriteLine("Пункт 3: Вывод свойства Person для объекта Student");
            Person studentPersonData = student.PersonData;
            Console.WriteLine(studentPersonData.ToString());
            Console.WriteLine("---------------------------------\n");

            // 4. Глубокое копирование
            Console.WriteLine("Пункт 4: Глубокое копирование");
            Student studentCopy = (Student)student.DeepCopy();
            Console.WriteLine("Исходный объект до изменений:");
            Console.WriteLine(student.ToShortString());
            Console.WriteLine("Копия до изменений:");
            Console.WriteLine(studentCopy.ToShortString());

            // Изменение исходного объекта
            student.Name = "Алексей";
            ((Exam)student.Exams[0]).Grade = 3;
            Console.WriteLine("\nИсходный объект после изменений:");
            Console.WriteLine(student.ToShortString());
            Console.WriteLine("Копия после изменений (должна остаться без изменений):");
            Console.WriteLine(studentCopy.ToShortString());
            Console.WriteLine("---------------------------------\n");

            // 5. Обработка исключения
            Console.WriteLine("Пункт 5: Обработка исключения при некорректном номере группы");
            try
            {
                student.GroupNumber = 50; // Некорректное значение
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Обнаружено исключение: {ex.Message}");
            }
            Console.WriteLine("---------------------------------\n");

            // 6. Итератор для всех зачетов и экзаменов
            Console.WriteLine("Пункт 6: Итератор для всех зачетов и экзаменов");
            foreach (var item in student.AllExamsAndTestsIterator())
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("---------------------------------\n");

            // 7. Итератор для экзаменов с оценкой > 3
            Console.WriteLine("Пункт 7: Итератор для экзаменов с оценкой выше 3");
            foreach (Exam exam in student.ExamsWithGradeGreaterThan(3))
            {
                Console.WriteLine(exam.ToString());
            }
            Console.WriteLine("---------------------------------\n");

            // Дополнительное задание
            Console.WriteLine("Пункт 8 (Дополнительное): Пересечение предметов");
            student.AddTests(new Test("Физика", true));
            foreach (var subject in student)
            {
                Console.WriteLine(subject);
            }
            Console.WriteLine("---------------------------------\n");

            Console.WriteLine("Пункт 9 (Дополнительное): Сданные зачеты и экзамены");
            foreach (var item in student.PassedExamsAndTests())
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("---------------------------------\n");

            Console.WriteLine("Пункт 10 (Дополнительное): Сданные зачеты, для которых сдан и экзамен");
            foreach (var test in student.PassedTestsWithPassedExam())
            {
                Console.WriteLine(test.ToString());
            }
            Console.WriteLine("---------------------------------\n");
        }
    }
}