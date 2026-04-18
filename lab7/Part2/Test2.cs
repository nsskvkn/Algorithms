namespace Algorithms.lab7;

static class Test2 {
    static double f(double x) {
        return Math.Pow(2, x) + 2 * x * x - 3;
    }

    static double df(double x) {
        return Math.Pow(2, x) * Math.Log(2) + 4 * x;
    }

    static double bisection(double a, double b, double eps) {
        if (f(a) * f(b) > 0) throw new Exception("No solution on the segment");
        
        while ((b - a) / 2 > eps) {
            double mid = (a + b) / 2;
            if (f(mid) == 0) return mid;

            if (f(a) * f(mid) < 0) b = mid;
            else a = mid;
        }

        return (a + b) / 2;
    }

    static double tangent(double x0, double eps, int maxIter = 1000) {
        double x = x0;

        for (int i = 0; i < maxIter; i++) {
            double fx = f(x);
            double dfx = df(x);
            if (Math.Abs(dfx) < 1e-10) throw new Exception("Derivative equals 0, this method does not apply.");

            double x1 = x - fx / dfx;
            if (Math.Abs(x1 - x) < eps) return x1;
            x = x1;
        }

        throw new Exception("Exceeded maximum iterations");
    }

    static double secant(double a, double b, double eps, int maxIter = 1000) {
        double x0 = a;
        double x1 = b;

        for (int i = 0; i < maxIter; i++) {
            double f0 = f(x0);
            double f1 = f(x1);

            if (Math.Abs(f1 - f0) < 1e-10) throw new Exception("division by zero");
            double x2 = x1 - f1 * (x1 - x0) / (f1 - f0);
            if (Math.Abs(x2 - x1) < eps) return x2;
            x0 = x1;
            x1 = x2;
        }
        throw new Exception("Exceeded maximum iterations");
    }

    public static void Run() {
        Console.WriteLine("=== РІВЕНЬ 2: Знаходження коренів ===");

        Console.Write("Введіть початок інтервалу a: ");
        if (!double.TryParse(Console.ReadLine(), out double a)) a = 0d;

        Console.Write("Введіть кінець інтервалу b: ");
        if (!double.TryParse(Console.ReadLine(), out double b)) b = 2d;

        const double eps = 1e-6;

        try {
            double rootBisection = bisection(a, b, eps);
            // Для методу дотичних беремо кінець відрізка (b) як початкову точку x0
            double rootNewton = tangent(b, eps);
            double rootSecant = secant(a, b, eps);

            Console.WriteLine($"\nBisection: {rootBisection}");
            Console.WriteLine($"Newton:    {rootNewton}");
            Console.WriteLine($"Secant:    {rootSecant}");
        }
        catch (Exception ex) {
            Console.WriteLine($"\nПомилка: {ex.Message}");
        }
    }
}