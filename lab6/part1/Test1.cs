using System.Diagnostics;
using static Algorithms.lab6.Helper;

namespace Algorithms.lab6;

static class Test1 {
    public static void Run() {
        const int N = 100;
        int[] sizes = [ N, N * N, N * N * N ];
        const int iterations = 5; // Кількість запусків для усереднення
        
        using var writer = new StreamWriter("test1result.csv");
        writer.WriteLine("Size,AverageTime(ns)");
        
        Console.WriteLine("=== РІВЕНЬ 1: Bottom-Up Merge Sort (Усереднено за 5 запусків) ===");
        
        foreach (int size in sizes) {
            double totalNanoseconds = 0;

            for (int i = 0; i < iterations; i++) {
                int[] array = GetRandomArray(size);
                var stopwatch = Stopwatch.StartNew();
                BottomUpMergeSort(array);
                stopwatch.Stop();
                totalNanoseconds += stopwatch.Elapsed.TotalNanoseconds;
            }

            double averageTime = totalNanoseconds / iterations;
            Console.WriteLine($"Size: {size,-8} | Average time: {averageTime:F0} ns");
            writer.WriteLine($"{size},{averageTime:F0}");
        }
    }
}