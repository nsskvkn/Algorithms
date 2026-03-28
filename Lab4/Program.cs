using System;
using System.Linq;

namespace Algorithms.lab4;
static class Program {
    static void Main(string[] args) {
        Console.OutputEncoding = System.Text.Encoding.UTF8; // Для коректного виводу кирилиці

        // Для ручного запуску з IDE, якщо args порожні, можеш задати значення за замовчуванням
        if (args.Length == 0) {
            args = new string[] { "test1" }; // Зміни на "test2" для перевірки другого рівня
        }

        switch (args[0].ToLower()) {
            case "test1":
                Test1.Run();
                break;
            case "test2":
                Test2.Run();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(args), "Invalid demo. Use test1 or test2.");
        }
    }
}