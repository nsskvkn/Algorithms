namespace Algorithms.lab2_2;

public static class Test1 {
    public static void Run() {
        Console.WriteLine("=== РІВЕНЬ 1: Регулярні вирази ===");
        
        string filePath = "words.txt";
        
        // Тестовий файл зі словами
        File.WriteAllLines(filePath, [
            "+123",      
            "+123ABC",   
            "+ABC",      
            "123",       
            "+12A3",     
            "+999Z"    
        ]);

        Console.WriteLine($"Регулярний вираз: {TextAnalyzer.Pattern}");
        Console.WriteLine($"Читання з файлу {filePath}...\n");
        Console.WriteLine("Знайдені слова, що відповідають виразу:");

        foreach (var line in File.ReadLines(filePath)) {
            if (TextAnalyzer.ValidateWithRegex(line)) {
                Console.WriteLine(line);
            }
        }
    }
}