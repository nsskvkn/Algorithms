using System;
using System.Linq;

namespace Algorithms.lab4;
static class Test1 {
    // Друк починається з Області, за якою йде сортування
    static void printStudents(Student[] students) {
        Console.WriteLine($"{"Region",-15} {"City",-15} {"Last name",-12} {"First name",-12} {"Group"}");
        foreach (var i in students) {
            Console.WriteLine($"{i.Region,-15} {i.City,-15} {i.LastName,-12} {i.FirstName,-12} {i.Group}");
        }
    }

    // Універсальне сортування вибіркою з використанням делегата Comparison<T>
    static T[] selectionSort<T>(T[] list, Comparison<T> comp) {
        T[] sorted = list.ToArray(); // Створюємо копію
        int len = sorted.Length;
        for (int i = 0; i < len - 1; i++) {
            int min_idx = i;
            for (int j = i + 1; j < len; j++) {
                // Якщо comp повертає < 0, значить sorted[j] менше за поточний мінімум
                if (comp(sorted[j], sorted[min_idx]) < 0) {
                    min_idx = j;
                }
            }
            if (min_idx != i) {
                // Сучасний обмін значень через кортежі (Tuples)
                (sorted[i], sorted[min_idx]) = (sorted[min_idx], sorted[i]);
            }
        }
        return sorted;
    }

    public static void Run() {
        var unsorted = new Student[] {
            new("Шевченко", "Олег", "КН-21", "Бровари", "Київська"),
            new("Іваненко", "Анна", "ПІ-22", "Львів", "Львівська"),
            new("Коваленко", "Ігор", "КН-21", "Біла Церква", "Київська"),
            new("Петренко", "Марія", "АМ-11", "Одеса", "Одеська"),
            new("Сидоренко", "Максим", "ПІ-22", "Стрий", "Львівська")
        };

        Console.WriteLine("Unsorted array (Level 1):");
        printStudents(unsorted);

        Console.WriteLine("\nSorting the array by Region in ascending order (Selection Sort):");
        // Передаємо лямбду для порівняння за областю
        var sorted = selectionSort(unsorted, (a, b) => a.Region.CompareTo(b.Region));
        
        printStudents(sorted);
    }
}