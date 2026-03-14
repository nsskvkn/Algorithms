using System;

namespace Algorithms.lab2;

static class Program {
    static void Main(string[] args) {
        if (args.Length == 0) {
            Console.WriteLine("Запускаємо Test1:");
            Test1.Run();
            Console.WriteLine("\n=========================================\n");
            Console.WriteLine("Запускаємо Test2:");
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