using System;

namespace Algorithms.lab1;

static class Program {
    static void Main(string[] args) {
        if (args.Length == 0) {
            
            Console.WriteLine("Аргументи не передано. Запускаємо всі тести послідовно:\n");
            Test1.Run();
            Console.WriteLine("\n=========================================\n");
            Test2.Run();
            return;
        }

        switch (args[0].ToLower()) {
            case "test1":
                Test1.Run();
                break;
            case "test2":
                Test2.Run();
                break;
            default:
                throw new Exception("Invalid demo");
        }
    }
}