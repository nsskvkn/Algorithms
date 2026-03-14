using System;

namespace Algorithms.lab2;

static class Test2 {
    public static void Run() {
        Console.WriteLine("--- РІВЕНЬ 2: Вставка з колізіями (Квадратичне зондування) ---");
        var hashTable = new SegmentHashTable(size: 5);

        // Створюємо відрізки з ОДНАКОВОЮ довжиною (ключем), щоб гарантовано викликати колізію
        var seg1 = new Segment(0, 0, 3, 4); // Довжина 5
        var seg2 = new Segment(1, 1, 4, 5); // Довжина 5
        var seg3 = new Segment(2, 2, 5, 6); // Довжина 5
        
        Console.WriteLine("Вставляємо перший відрізок (довжина 5)...");
        hashTable.Insert(seg1);
        
        Console.WriteLine("Вставляємо другий відрізок (довжина 5, колізія!)...");
        hashTable.Insert(seg2); // Зміститься через квадратичне зондування

        Console.WriteLine("Вставляємо третій відрізок (довжина 5, колізія!)...");
        hashTable.Insert(seg3); // Зміститься ще далі

        Console.WriteLine("\nВміст хеш-таблиці (зверни увагу на індекси):");
        Console.WriteLine(hashTable.GetFullContent());
    }
}