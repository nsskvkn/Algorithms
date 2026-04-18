namespace Algorithms.lab7;

static class Test1 {
    static double f(double x) {
        return Math.Sin(Math.Sqrt(1 + x * x + x));
    }

    static double rectangleMethod(double a, double b, double step) {
        double sum = 0d;

        for (double x = a; x < b; x += step) {
            double mid = x + step / 2d;
            sum += f(mid);
        }

        return sum * step;
    }

    static double trapezoidalMethod(double a, double b, double step) {
        double sum = (f(a) + f(b)) / 2d;

        for (double x = a + step; x < b; x += step) {
            sum += f(x);
        }

        return sum * step;
    }

    static double simpsonMethod(double a, double b, double step) {
        int n = (int)((b - a) / step);
        // n must be even
        if (n % 2 != 0) n++;
        step = (b - a) / n;
        double sum = f(a) + f(b);

        for (int i = 1; i < n; i++) {
            double x = a + i * step;
            if (i % 2 == 0) sum += 2 * f(x);
            else sum += 4 * f(x);
        }

        return sum * step / 3d;
    }

    public static void Run() {
        Console.WriteLine("=== РІВЕНЬ 1: Інтегрування ===");
        
        Console.Write("Введіть початок інтервалу a: ");
        if (!double.TryParse(Console.ReadLine(), out double a)) a = 2d;

        Console.Write("Введіть кінець інтервалу b: ");
        if (!double.TryParse(Console.ReadLine(), out double b)) b = 5d;

        Console.Write("Введіть крок step: ");
        if (!double.TryParse(Console.ReadLine(), out double step)) step = 0.2;

        double rect = rectangleMethod(a, b, step);
        double trap = trapezoidalMethod(a, b, step);
        double simpson = simpsonMethod(a, b, step);

        Console.WriteLine($"\nRectangle method:   {rect}");
        Console.WriteLine($"Trapezoidal method: {trap}");
        Console.WriteLine($"Simpson method:     {simpson}");
    }
}