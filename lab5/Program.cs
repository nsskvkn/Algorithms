using System;
using System.Collections.Generic;
namespace Algorithms.lab5;
public static class Program {
    public static void Main(string[] args) {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        if (args.Length == 0) {
            Test1.Run();
            Console.WriteLine("\n" + new string('-', 40) + "\n");
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
                throw new ArgumentOutOfRangeException(nameof(args), "Invalid demo");
        }
    }
}