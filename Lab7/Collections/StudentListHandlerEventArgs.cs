using System;
using System.Collections.Generic;
using Lab7.Collections;
using Lab7.Models;
using Lab7.Journals;


namespace Lab7.Collections;

// Делегат для событий коллекции
public delegate void StudentListHandler(object source, StudentListHandlerEventArgs args);

// Аргументы события
public class StudentListHandlerEventArgs : EventArgs
{
    public string CollectionName { get; }
    public string ChangeType { get; }
    public Student ChangedStudent { get; }

    public StudentListHandlerEventArgs(string collectionName, string changeType, Student student)
    {
        CollectionName = collectionName;
        ChangeType = changeType;
        ChangedStudent = student;
    }

    public override string ToString()
        => $"Коллекция: {CollectionName}, Изменение: {ChangeType}, Объект: {ChangedStudent?.ToShortString()}";
}