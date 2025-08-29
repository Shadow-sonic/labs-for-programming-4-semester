
using Lab8.Collections;
using Lab8.Models;
using Lab8.Journals;
using System.ComponentModel;

namespace Lab8.Models;

public class Student : INotifyPropertyChanged
{
    private string group;
    private Education education;

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }

    public string Group
    {
        get => group;
        set
        {
            group = value;
            OnPropertyChanged(nameof(Group));
        }
    }

    public Education EducationForm
    {
        get => education;
        set
        {
            education = value;
            OnPropertyChanged(nameof(EducationForm));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public Student(string f, string l, DateTime b, Education edu, string g)
    {
        FirstName = f;
        LastName = l;
        BirthDate = b;
        education = edu;
        group = g;
    }

    public string ToShortString()
        => $"{LastName} {FirstName}, {EducationForm}, {Group}";

    public override string ToString()
        => $"{LastName} {FirstName}, {BirthDate.ToShortDateString()}, {EducationForm}, группа {Group}";
}
