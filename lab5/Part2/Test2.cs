using System;
using System.Collections.Generic;
namespace Algorithms.lab5;
public static class Test2 {
    public static void Run() {
        Console.WriteLine("=== РІВЕНЬ 2: BST-дерево (вставка в корінь) ===");
        var tree = new BinaryTree<Student, string>(s => s.FirstName);
        
        var students = new[] {
            new Student("Марія", "Бойко", "Іванівна", 101, true),
            new Student("Андрій", "Шевченко", "Петрович", 102, false),
            new Student("Яна", "Коваленко", "Сергіївна", 103, true),
            new Student("Богдан", "Ткаченко", "Дмитрович", 104, false)
        };

        foreach (var s in students) {
            Console.WriteLine($"\nВставка: {s.FirstName}");
            tree.InsertAtRoot(s);
            Console.Write("Обхід у ширину: ");
            tree.PrintBFS();
        }

        Console.WriteLine(new string('=', 20));
        string searchKey = "Яна";
        Console.WriteLine($"Пошук студента за ключем '{searchKey}':");
        var found = tree.Search(searchKey);
        
        if (found is not null) Console.WriteLine($"Знайдено: {found.Value}");
        else Console.WriteLine("Не знайдено");
    }
}