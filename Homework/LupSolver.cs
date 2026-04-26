using System;

namespace Algorithms.Homework;

static class LupSolver
{
    static int n;

    static int[] LUPDecompose(double[,] A) {
        int[] pi = new int[n];
        for (int i = 0; i < n; i++) pi[i] = i;

        for (int k = 0; k < n; k++) {
            // Шукаємо найбільший елемент у стовпці k для вибору головного елемента
            double maxVal = 0;
            int kPrime = k;
            for (int i = k; i < n; i++) {
                if (Math.Abs(A[i, k]) > maxVal) {
                    maxVal = Math.Abs(A[i, k]);
                    kPrime = i;
                }
            }

            if (maxVal == 0) throw new Exception("Матриця вироджена (det(A) = 0). Неможливо розв'язати систему.");

            // Перестановка рядків
            (pi[k], pi[kPrime]) = (pi[kPrime], pi[k]);
            for (int i = 0; i < n; i++)
                (A[k, i], A[kPrime, i]) = (A[kPrime, i], A[k, i]);

            // Прямий хід методу Гауса
            for (int i = k + 1; i < n; i++) {
                A[i, k] /= A[k, k];
                for (int j = k + 1; j < n; j++)
                    A[i, j] -= A[i, k] * A[k, j];
            }
        }

        return pi;
    }

    static double[] LUPSolve(double[,] LU, int[] pi, double[] b) {
        double[] x = new double[n];
        double[] y = new double[n];

        // Пряма підстановка (Ly = Pb)
        for (int i = 0; i < n; i++) {
            y[i] = b[pi[i]];
            for (int j = 0; j < i; j++)
                y[i] -= LU[i, j] * y[j];
        }

        // Зворотна підстановка (Ux = y)
        for (int i = n - 1; i >= 0; i--) {
            x[i] = y[i];
            for (int j = i + 1; j < n; j++)
                x[i] -= LU[i, j] * x[j];
            x[i] /= LU[i, i];
        }

        return x;
    }

    static void PrintSystem(double[,] A, double[] b) {
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                Console.Write($"{A[i, j],6:F0}*x{j+1} ");
                if (j < n - 1) Console.Write("+ ");
            }
            Console.WriteLine($"= {b[i]}");
        }
    }

    static void PrintLU(double[,] LU) {
        Console.WriteLine("\n=== Матриця L (Нижня трикутна) ===");
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                double val = (j < i) ? LU[i, j] : (i == j ? 1.0 : 0.0);
                Console.Write($"{val,10:F4}");
            }
            Console.WriteLine();
        }

        Console.WriteLine("\n=== Матриця U (Верхня трикутна) ===");
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                double val = (j >= i) ? LU[i, j] : 0.0;
                Console.Write($"{val,10:F4}");
            }
            Console.WriteLine();
        }
    }

    static void Verify(double[,] A_orig, double[] x, double[] b)
    {
        Console.WriteLine("\n=== Перевірка (A * x = b) ===");
        double maxError = 0;
        for (int i = 0; i < n; i++) {
            double sum = 0;
            for (int j = 0; j < n; j++)
                sum += A_orig[i, j] * x[j];
            double error = Math.Abs(sum - b[i]);
            if (error > maxError) maxError = error;
            Console.WriteLine($"Рядок {i + 1}: {sum,10:F6}  (очікувалося {b[i],10:F6})  похибка = {error:E2}");
        }
        Console.WriteLine($"\nМаксимальна абсолютна похибка: {maxError:E4}");
    }

    public static void Run() {
        Console.WriteLine("=== ДОМАШНЯ РОБОТА (РІВЕНЬ 1: LUP-розкладання) ===");
        Console.WriteLine("Варіант 25\n");
        
        n = 4;

        double[,] A_orig = {
            { -5, -1,  4,  8 },
            {  0,  6,-10, -6 },
            {  9,  7,  8, -1 },
            { -6,  3, -9,  0 }
        };

        // Вектор вільних членів b з вашого 25-го варіанта
        double[] b = { 59, -70, -90, 0 };

        Console.WriteLine("Задана система рівнянь:");
        PrintSystem(A_orig, b);

        // Копіюємо матрицю, оскільки алгоритм перезаписує її під час роботи
        double[,] A = (double[,])A_orig.Clone();

        Console.WriteLine("\n=== Крок 1: LUP-розкладання ===");
        int[] pi = LUPDecompose(A);

        Console.Write("Вектор перестановок P = [ ");
        foreach (int p in pi) Console.Write($"{p + 1} ");
        Console.WriteLine("]");

        PrintLU(A);

        Console.WriteLine("\n=== Крок 2: Розв'язання системи ===");
        double[] x = LUPSolve(A, pi, b);

        for (int i = 0; i < n; i++)
            Console.WriteLine($"x{i + 1} = {x[i],12:F6}");

        Verify(A_orig, x, b);
    }
}