using System;

namespace Algorithms.lab2;

static class Test1 {
    public static void Run() {
        Console.WriteLine("--- РІВЕНЬ 1: Вставка без колізій ---");
        var hashTable = new SegmentHashTable(size: 7);

        // Відрізки з різною довжиною, щоб уникнути колізій
        var seg1 = new Segment(0, 0, 3, 4);  // Довжина 5
        var seg2 = new Segment(0, 0, 6, 8);  // Довжина 10
        var seg3 = new Segment(0, 0, 5, 12); // Довжина 13
        var seg4 = new Segment(0, 0, 8, 15); // Довжина 17

        hashTable.Insert(seg1);
        hashTable.Insert(seg2);
        hashTable.Insert(seg3);
        bool result = hashTable.Insert(seg4);
        
        Console.WriteLine($"Результат вставки останнього відрізка: {result}");
        Console.WriteLine(hashTable.GetFullContent());

        Console.WriteLine($"\nОтримання елемента з ключем '10' -> {hashTable.GetSegment(10f)}");
        Console.WriteLine($"Отримання елемента з ключем '999' -> {hashTable.GetSegment(999f)}");
    }
}