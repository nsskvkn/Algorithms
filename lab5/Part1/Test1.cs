using System;
using System.Collections.Generic;
namespace Algorithms.lab5;
public static class Test1 {
    public static void Run() {
        Console.WriteLine("=== РІВЕНЬ 1: Інтерполяційний пошук ===");
        
        var rnd = new Random(123);
        var students = new Student[20];
        for (int i = 0; i < 20; i++) {
            students[i] = new Student($"Ім'я{i}", $"Прізвище{i}", $"ПоБ{i}", rnd.Next(100, 999), i % 2 == 0);
        }

        // Правило формування: упорядкування за військ. підготовкою, а всередині - за Id
        Array.Sort(students, (a, b) => {
            if (a.HasMilitaryTraining != b.HasMilitaryTraining)
                return a.HasMilitaryTraining.CompareTo(b.HasMilitaryTraining);
            return a.Id.CompareTo(b.Id);
        });

        foreach (var s in students) Console.WriteLine(s);

        int startIndex = Array.FindIndex(students, s => s.HasMilitaryTraining);
        if (startIndex == -1) {
            Console.WriteLine("Немає студентів з військовою підготовкою.");
            return;
        }

        int targetId = students[^1].Id; 
        Console.WriteLine($"\nШукаємо студента з заліковкою {targetId} серед тих, хто проходить підготовку...");

        int index = InterpolationSearcher.Search(students, targetId, s => s.Id, startIndex, students.Length - 1);

        if (index != -1) Console.WriteLine($"Знайдено: {students[index]}");
        else Console.WriteLine("Не знайдено.");
    }
}