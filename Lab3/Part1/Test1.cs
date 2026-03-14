using System;

namespace Algorithms.lab3;

static class Test1 {
    static void printList(BinaryTree<Student> studentTree) {
        Console.WriteLine($"{"First name",-12} {"Last name",-12} {"Student id",-12} {"Gender",-8} {"Residence",-12} {"Course"}");
        foreach (var node in studentTree) {
            Console.WriteLine(node.Value);
        }
    }

    public static void Run() {
        // Критерій 4 варіанта: Студентки 1-го курсу, які проживають у гуртожитку
        Predicate<Student> predicate = s => s.Course == 1 && s.Gender == Gender.Female && s.Residence == Residence.Dormitory;

        Console.WriteLine(new string('=', 70));
        Console.WriteLine("PART 1: Creating tree and In-Order traversal");
        Console.WriteLine(new string('=', 70));
        
        var tree = new BinaryTree<Student>();
        
        // Додаємо студентів (StudentId - це ключ)
        tree.Insert(new Student("Anna", "Kovalenko", 12, Gender.Female, Residence.Dormitory, 1)); // Підходить під умову
        tree.Insert(new Student("Ivan", "Shevchenko", 14, Gender.Male, Residence.Apartment, 2));
        tree.Insert(new Student("Maria", "Boyko", 11, Gender.Female, Residence.Dormitory, 1)); // Підходить під умову
        tree.Insert(new Student("Petro", "Tkachenko", 4, Gender.Male, Residence.Dormitory, 1));
        tree.Insert(new Student("Olena", "Melnyk", 1, Gender.Female, Residence.Home, 1));
        tree.Insert(new Student("Iryna", "Hryhorenko", 2, Gender.Female, Residence.Dormitory, 3));
        tree.Insert(new Student("Oleg", "Ivanov", 9, Gender.Male, Residence.Apartment, 4));
        tree.Insert(new Student("Daria", "Petrova", 0, Gender.Female, Residence.Dormitory, 1)); // Підходить під умову

        // Виведення дерева паралельним обходом (посортовано за StudentId)
        printList(tree);

        Console.WriteLine(new string('=', 70));
        Console.WriteLine("PART 2: Searching by criterion");
        Console.WriteLine(new string('=', 70));
        Console.WriteLine("Criterion: 1st year female students living in a dormitory:\n");
        
        var foundNodes = tree.Where(predicate);
        
        Console.WriteLine($"{"First name",-12} {"Last name",-12} {"Student id",-12} {"Gender",-8} {"Residence",-12} {"Course"}");
        foreach (var node in foundNodes) {
            Console.WriteLine(node.Value);
        }
        Console.WriteLine(new string('=', 70));
    }
}