using System;
using System.Linq;

namespace Lab3;

// Класс Exam для хранения информации об экзаменах
public class Exam
{
    public string SubjectName { get; set; }
    public int Grade { get; set; }
    public DateTime ExamDate { get; set; }

    public Exam(string subjectName, int grade, DateTime examDate)
    {
        SubjectName = subjectName;
        Grade = grade;
        ExamDate = examDate;
    }

    public Exam()
    {
        SubjectName = "Default Subject";
        Grade = 0;
        ExamDate = new DateTime(2000, 1, 1);
    }

    public override string ToString()
    {
        return $"Предмет: {SubjectName}, Оценка: {Grade}, Дата: {ExamDate.ToShortDateString()}";
    }
}

