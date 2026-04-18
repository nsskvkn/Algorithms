using System.Diagnostics;
using static Algorithms.lab6.Helper;

namespace Algorithms.lab6;

static class Test2 {
    public static void Run() {
        const int N = 100;
        int[] sizes = [ N, N * N, N * N * N ];
        const int iterations = 5; // Кількість запусків для усереднення

        using var writer = new StreamWriter("test2result.csv");
        writer.WriteLine("Size,BottomUp_Avg(ns),TopDown_Avg(ns)");

        Console.WriteLine("=== РІВЕНЬ 2: Порівняння Bottom-Up та Top-Down (Усереднено за 5 запусків) ===");

        foreach (int size in sizes) {
            double totalBottomUp = 0;
            double totalTopDown = 0;

            for (int i = 0; i < iterations; i++) {
                // Створюємо ОДИН базовий масив для чесного порівняння
                int[] originalArray = GetRandomArray(size);
                
                int[] arr1 = (int[])originalArray.Clone();
                var sw1 = Stopwatch.StartNew();
                BottomUpMergeSort(arr1);
                sw1.Stop();
                totalBottomUp += sw1.Elapsed.TotalNanoseconds;
                
                int[] arr2 = (int[])originalArray.Clone(); 
                var sw2 = Stopwatch.StartNew();
                TopDownMergeSort(arr2);
                sw2.Stop();
                totalTopDown += sw2.Elapsed.TotalNanoseconds;
            }

            double avgBottomUp = totalBottomUp / iterations;
            double avgTopDown = totalTopDown / iterations;

            Console.WriteLine($"Size: {size,-8} | Bottom-Up: {avgBottomUp:F0} ns | Top-Down: {avgTopDown:F0} ns");
            writer.WriteLine($"{size},{avgBottomUp:F0},{avgTopDown:F0}");
        }
    }
}