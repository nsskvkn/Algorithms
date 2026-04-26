using System.Text.RegularExpressions;

namespace Algorithms.lab2_2;

public static class TextAnalyzer {
    // Патерн для 5 варіанта
    public static readonly string Pattern = @"^\+\d+[A-Z]*$";

    public static bool ValidateWithRegex(string input) {
        return Regex.IsMatch(input, Pattern);
    }
}