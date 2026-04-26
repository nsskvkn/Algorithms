using System;

namespace Algorithms.Homework;

static class Program {
    static void Main(string[] args) {
        // Налаштування кодування для коректного відображення символів (кирилиці)
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Якщо аргументів немає, просто запускаємо розв'язання
        if (args.Length == 0) {
            LupSolver.Run();
            return;
        }

        switch (args[0].ToLower()) {
            case "test1":
                LupSolver.Run();
                break;
            default:
                throw new Exception("Invalid demo");
        }
    }
}
