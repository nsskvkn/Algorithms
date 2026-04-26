namespace Algorithms.lab2_2;

static class Program {
    static void Main(string[] args) {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        if (args.Length == 0) {
            Test1.Run();
            return;
        }

        switch (args[0].ToLower()) {
            case "test1":
                Test1.Run();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(args), "Invalid demo");
        }
    }
}