using System;

namespace Algorithms.lab1;

static class Test2 {
    public static void Run() {
        Console.WriteLine("--- РІВЕНЬ 2: Зв'язна черга вісімкових чисел ---");
        var queue = new LinkedQueue<string>();
        
        // 100(8) = 64(10), 400(8) = 256(10), 150(8) = 104(10), 350(8) = 232(10)
        queue.Enqueue("100");
        queue.Enqueue("400");
        queue.Enqueue("150");
        queue.Enqueue("350");
        
        Console.WriteLine($"Черга після ініціалізації: {queue}");
        queue.Dequeue(); // Видаляємо перший елемент ("100")
        Console.WriteLine($"Черга після видалення одного елемента: {queue}");

        Console.WriteLine("\n--- РІВЕНЬ 3: Переміщення з черги до стеку ---");
        var resultStack = new VectorStack<double>(10);
        Console.WriteLine($"Початковий стан черги перед переміщенням: {queue}");

        while (!queue.IsEmpty()) {
            string octalStr = queue.Dequeue();
            int decimalValue = Convert.ToInt32(octalStr, 8); 
            
            double finalValue = decimalValue > 200 
                ? decimalValue / 2.0 
                : decimalValue * 2.0;
                
            resultStack.Push(finalValue);
        }

        Console.WriteLine($"Стан черги після переміщення (має бути порожньою): {queue}");
        Console.WriteLine($"Результуючий стек дійсних чисел: {resultStack}");
    }
}