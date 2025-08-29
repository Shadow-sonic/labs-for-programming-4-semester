using System;
using System.Collections.Generic;
using Lab8.Collections;
using Lab8.Models;
using Lab8.Journals;


namespace Lab8.Collections;
public class StudentCollection<TKey>
{
    private readonly Dictionary<TKey, Student> students = new();

    public string CollectionName { get; set; }

    public event StudentsChangedHandler<TKey>? StudentsChanged;

    public StudentCollection(string name)
    {
        CollectionName = name;
    }

    public void Add(TKey key, Student st)
    {
        students[key] = st;
        st.PropertyChanged += OnStudentPropertyChanged;

        StudentsChanged?.Invoke(this,
            new StudentsChangedEventArgs<TKey>(CollectionName, Action.Add, "", key));
    }

    public bool Remove(Student st)
    {
        TKey? keyToRemove = default;
        bool found = false;

        foreach (var pair in students)
        {
            if (pair.Value == st)
            {
                keyToRemove = pair.Key;
                found = true;
                break;
            }
        }

        if (!found) return false;

        st.PropertyChanged -= OnStudentPropertyChanged;
        students.Remove(keyToRemove!);

        StudentsChanged?.Invoke(this,
            new StudentsChangedEventArgs<TKey>(CollectionName, Action.Remove, "", keyToRemove!));
        return true;
    }

    private void OnStudentPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (sender is Student st)
        {
            foreach (var pair in students)
            {
                if (pair.Value == st)
                {
                    StudentsChanged?.Invoke(this,
                        new StudentsChangedEventArgs<TKey>(CollectionName, Action.Property, e.PropertyName, pair.Key));
                    break;
                }
            }
        }
    }

    public override string ToString()
    {
        var result = $"Коллекция {CollectionName}:\n";
        foreach (var kv in students)
            result += $"Ключ: {kv.Key}, Значение: {kv.Value}\n";
        return result;
    }
}