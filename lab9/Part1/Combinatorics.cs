using System.Numerics;

namespace Algorithms.lab2_3;

public static class Combinatorics {
    // Обчислення факторіала (використовуємо BigInteger, оскільки факторіали ростуть дуже швидко)
    public static BigInteger Factorial(int n) {
        if (n < 0) return 0;
        BigInteger result = 1;
        for (int i = 2; i <= n; i++) {
            result *= i;
        }
        return result;
    }

    // Розв'язок задачі: (N - 1)! * 2!
    public static BigInteger SolveConferenceProblem(int totalReports) {
        if (totalReports < 2) return 0;
        return Factorial(totalReports - 1) * 2;
    }
}