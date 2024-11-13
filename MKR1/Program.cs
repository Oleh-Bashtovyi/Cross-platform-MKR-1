namespace MKR_1;

internal static class Program
{
    public const string INPUT_FILENAME = "INPUT.TXT";
    public const string OUTPUT_FILENAME = "OUTPUT.TXT";

    private static void Main() 
    {
        var prevConsoleColor = Console.ForegroundColor;
        try
        {
            var inputFile = !Path.IsPathRooted(INPUT_FILENAME) ? Path.Combine(Directory.GetCurrentDirectory(), INPUT_FILENAME) : INPUT_FILENAME;

            Console.WriteLine("Input file: " + inputFile);

            var orders = IOHandler.ReadOrders(INPUT_FILENAME);

            var result = OrdersProblemSolver.Solve(orders);

            IOHandler.WriteResult(result, OUTPUT_FILENAME);

            var outputFile = !Path.IsPathRooted(OUTPUT_FILENAME) ? Path.Combine(Directory.GetCurrentDirectory(), OUTPUT_FILENAME) : OUTPUT_FILENAME;

            Console.WriteLine("Result successfuly written to: " + outputFile);


        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.ForegroundColor = prevConsoleColor;
        }
        Console.WriteLine("Program finished!");
    }
}
