using System;

namespace Algorithms.lab1;

static class Test1 {
    static void safeCall(Action action) {
        try {
            action();
        } catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }

    public static void Run() {
        Console.WriteLine("--- РІВЕНЬ 1: Векторний стек дійсних чисел ---");
        var stack = new VectorStack<double>(5);
        
        stack.Push(15.5);
        stack.Push(42.0);
        stack.Push(8.75);
        Console.WriteLine($"Стек після додавання: {stack}");
        
        stack.Pop();
        Console.WriteLine($"Стек після видалення одного елемента: {stack}");
        
        Console.WriteLine("Тестування винятків стеку:");
        stack.Pop();
        stack.Pop();
        safeCall(() => stack.Pop()); // Має вивести повідомлення про помилку
    }
}