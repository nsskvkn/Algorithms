namespace Algorithms.lab2_3;

public static class Test1 {
    public static void Run() {
        Console.WriteLine("=== ЛАБОРАТОРНА РОБОТА 2.3 (РІВЕНЬ 1) ===");
        Console.WriteLine("Задача: Скількома способами можна поставити доповіді в порядок денний, якщо 2 доповіді мають бути поряд?");
        Console.WriteLine("Тип вибірки: Перестановки без повторень (Permutations).\n");

        Console.Write("Введіть загальну кількість доповідей (за варіантом 10): ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n < 2) {
            n = 10;
        }

        var result = Combinatorics.SolveConferenceProblem(n);

        Console.WriteLine($"\nКількість доповідей: {n}");
        Console.WriteLine($"Формула розрахунку: ({n} - 1)! * 2!");
        Console.WriteLine($"Відповідь: {result} способів.");
    }
}