// .NET 7 Console App
// ЛР №6 — Вариант 1: Person/Student, StudentCollection, TestCollections
// Все требования задания реализованы и прокомментированы.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

#region Базовые модели (Education, Exam, Test)



public class TestCollections
{
    private readonly List<Person> _listPerson;
    private readonly List<string> _listString;
    private readonly Dictionary<Person, Student> _dictPersonStudent;
    private readonly Dictionary<string, Student> _dictStringStudent;

    // Статический генератор (взаимно-однозначное соответствие int -> Student -> (Person-часть))
    public static Student GenerateElement(int n)
    {
        // Уникальные данные на основе n (однозначное соответствие):
        // ВАЖНО: для равенства TKey (Person) используем одинаковые правила (Фамилия, Имя, ДР).
        string first = $"Name{n}";
        string last  = $"Last{n}";
        DateTime birth = new DateTime(2000, 1, 1).AddDays(n);

        var st = new Student(first, last, birth,
                             (Education)(n % Enum.GetValues(typeof(Education)).Length),
                             $"G{n:000}");

        // Пара экзаменов — чтобы средний был детерминированным
        st.AddExams(new Exam("ОП", 60 + (n % 41), DateTime.Today.AddDays(-n - 1)),
                    new Exam("ООП", 60 + ((n * 3) % 41), DateTime.Today.AddDays(-n - 2)));
        // Зачёты — просто пару штук
        st.AddTests(new Test("ПП", n % 2 == 0), new Test("Физ-ра", true));

        return st;
    }

    public TestCollections(int count)
    {
        if (count < 0) throw new ArgumentOutOfRangeException(nameof(count));

        _listPerson = new List<Person>(capacity: count);
        _listString = new List<string>(capacity: count);
        _dictPersonStudent = new Dictionary<Person, Student>(capacity: count);
        _dictStringStudent = new Dictionary<string, Student>(capacity: count);

        for (int i = 0; i < count; i++)
        {
            Student s = GenerateElement(i);
            Person k = s.BasePerson;              // TKey из TValue (НЕ сам s!)
            string ks = k.ToString();             // ключ-строка для второй пары коллекций

            _listPerson.Add(k);
            _listString.Add(ks);
            _dictPersonStudent[k] = s;
            _dictStringStudent[ks] = s;
        }
    }

    private static long Measure(Action action, int repeat = 1)
    {
        // Для более стабильных замеров можно увеличить repeat и усреднить.
        var sw = Stopwatch.StartNew();
        for (int i = 0; i < repeat; i++) action();
        sw.Stop();
        return sw.ElapsedTicks; // тики — точнее миллисекунд
    }

    public void SearchTest()
    {
        // Подготовим 4 случая: первый, центральный, последний и отсутствующий
        int n = _listPerson.Count;
        if (n == 0)
        {
            Console.WriteLine("Коллекции пусты — искать нечего.");
            return;
        }

        Person first = _listPerson[0];
        Person middle = _listPerson[n / 2];
        Person last = _listPerson[n - 1];
        // отсутствующий — с данными, которых не было (n гарантированно вне диапазона [0..n-1])
        Person missing = GenerateElement(n).BasePerson;

        var cases = new (string Name, Person P)[]
        {
            ("первый", first),
            ("центральный", middle),
            ("последний", last),
            ("отсутствующий", missing),
        };

        Console.WriteLine("\n=== Замеры поиска ===");
        foreach (var (label, keyPerson) in cases)
        {
            string keyString = keyPerson.ToString();
            Student value = _dictPersonStudent.ContainsKey(keyPerson)
                ? _dictPersonStudent[keyPerson]
                : GenerateElement(999_999); // для отсутствующего — синтетическое значение

            // List<Person>.Contains
            long tListPerson = Measure(() => { _ = _listPerson.Contains(keyPerson); }, repeat: 1);
            Console.WriteLine($"List<Person>.Contains — {label}: {tListPerson} ticks");

            // List<string>.Contains
            long tListString = Measure(() => { _ = _listString.Contains(keyString); }, repeat: 1);
            Console.WriteLine($"List<string>.Contains — {label}: {tListString} ticks");

            // Dictionary<Person,Student>.ContainsKey
            long tDictPersonKey = Measure(() => { _ = _dictPersonStudent.ContainsKey(keyPerson); }, repeat: 1);
            Console.WriteLine($"Dictionary<Person,Student>.ContainsKey — {label}: {tDictPersonKey} ticks");

            // Dictionary<string,Student>.ContainsKey
            long tDictStringKey = Measure(() => { _ = _dictStringStudent.ContainsKey(keyString); }, repeat: 1);
            Console.WriteLine($"Dictionary<string,Student>.ContainsKey — {label}: {tDictStringKey} ticks");

            // Dictionary<Person,Student>.ContainsValue
            long tDictPersonVal = Measure(() => { _ = _dictPersonStudent.ContainsValue(value); }, repeat: 1);
            Console.WriteLine($"Dictionary<Person,Student>.ContainsValue — {label}: {tDictPersonVal} ticks");

            Console.WriteLine();
        }
    }
}

#endregion

