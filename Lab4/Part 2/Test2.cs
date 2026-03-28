using System;
using System.Linq;

namespace Algorithms.lab4;
static class Test2 {
    // Вивід через масив індексів
    static void printStudentsByIndex(Student[] students, int[] indices) {
        Console.WriteLine($"{"Region",-15} {"City",-15} {"Last name",-12} {"First name",-12} {"Group"}");
        foreach (int idx in indices) {
            var i = students[idx];
            Console.WriteLine($"{i.Region,-15} {i.City,-15} {i.LastName,-12} {i.FirstName,-12} {i.Group}");
        }
    }

    // Сортування ЗА ІНДЕКСАМИ (повертає відсортований масив int, об'єкти не рухає)
    static int[] indexSort<T>(T[] array, Comparison<T> comp) {
        int[] indices = new int[array.Length];
        for (int i = 0; i < indices.Length; i++) {
            indices[i] = i;
        }

        int len = indices.Length;
        for (int i = 0; i < len - 1; i++) {
            int min_idx = i;
            for (int j = i + 1; j < len; j++) {
                // Порівнюємо самі елементи, використовуючи їхні індекси
                if (comp(array[indices[j]], array[indices[min_idx]]) < 0) {
                    min_idx = j;
                }
            }
            if (min_idx != i) {
                // Переставляємо ТІЛЬКИ ІНДЕКСИ
                (indices[i], indices[min_idx]) = (indices[min_idx], indices[i]);
            }
        }
        return indices;
    }

    public static void Run() {
        var students = new Student[] {
            new("Шевченко", "Олег", "КН-21", "Бровари", "Київська"),
            new("Іваненко", "Анна", "ПІ-22", "Львів", "Львівська"),
            new("Коваленко", "Ігор", "КН-21", "Біла Церква", "Київська"),
            new("Петренко", "Марія", "АМ-11", "Одеса", "Одеська"),
            new("Сидоренко", "Максим", "ПІ-22", "Стрий", "Львівська")
        };

        // Створюємо початкові індекси (0, 1, 2, 3, 4) для виводу "до"
        int[] initialIndices = Enumerable.Range(0, students.Length).ToArray();

        Console.WriteLine("Original array (Level 2):");
        printStudentsByIndex(students, initialIndices);

        // Передаємо лямбду для подвійного критерію: Область, а потім Місто
        var sortedIndices = indexSort(students, (a, b) => {
            int regionComp = a.Region.CompareTo(b.Region);
            if (regionComp != 0) return regionComp; // Якщо області різні, сортуємо за ними
            return a.City.CompareTo(b.City);        // Якщо області однакові, сортуємо за містом
        });

        Console.WriteLine("\nStudents after sorting by Region then City (Index Sort):");
        printStudentsByIndex(students, sortedIndices);
    }
}