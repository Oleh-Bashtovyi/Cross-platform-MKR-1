namespace MKR_1;

public static class IOHandler
{

    public const int MIN_ORDER_COUNT = 1;
    public const int MAX_ORDER_COUNT = 1000;


    public static List<Order> ReadOrders(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("Input file not found.");
        }

        var lines = File.ReadAllLines(filePath)
              .Where(static line => !string.IsNullOrWhiteSpace(line))
              .ToList();

        if (lines.Count == 0)
        {
            throw new FormatException("File is empty");
        }


        if (!int.TryParse(lines[0], out int numberOfOrders))
        {
            throw new FormatException(
                $"Unable to parse first line (number of orders): {lines[0]}.");
        }

        if(numberOfOrders < MIN_ORDER_COUNT || numberOfOrders > MAX_ORDER_COUNT)
        {
            throw new InvalidOperationException(
                $"Number of orders (first line) should be between {MIN_ORDER_COUNT} and {MAX_ORDER_COUNT}{Environment.NewLine}" +
                $"Actual value: {numberOfOrders}");
        }

        if (numberOfOrders >= lines.Count)
        {
            throw new FormatException(
                $"File dont have specified number of orders.{Environment.NewLine}" +
                $"Expected: {numberOfOrders}, Actual: {lines.Count - 1}");
        }

        var orders = new List<Order>();

        for (int i = 1; i <= numberOfOrders; i++)
        {
            var parts = lines[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 2)
            {
                throw new FormatException($"Row {i + 1}: must be exact 2 numbers \"deadline reward\"");
            }

            if (!int.TryParse(parts[0], out int deadline))
            {
                throw new FormatException($"Row {i + 1}: unable to convert deadline: {parts[0]} ");
            }

            if (!int.TryParse(parts[1], out int reward))
            {
                throw new FormatException($"Row {i + 1}: unable to convert reward: {parts[1]} ");
            }

            orders.Add(new(deadline, reward));
        }

        return orders;
    }



/*    public static List<Order> ReadOrders(StreamReader stream)
    {

    }*/



    public static List<Order> ReadOrders(IEnumerable<string> strings)
    {
        var orders = new List<Order>();
        var row = 1;

        foreach (string line in strings)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                throw new ArgumentException($"Row {row}: string must not be null or empty");
            }

            var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 2)
            {
                throw new ArgumentException($"Row {row}: must be exact 2 numbers \"deadline reward\"");
            }

            if (!int.TryParse(parts[0], out int deadline))
            {
                throw new ArgumentException($"Row {row}: unable to convert deadline: {parts[0]} ");
            }

            if (!int.TryParse(parts[1], out int reward))
            {
                throw new ArgumentException($"Row {row}: unable to convert reward: {parts[1]} ");
            }

            orders.Add(new(deadline, reward));
            row++;
        }

        return orders;
    }



    public static void WriteResult(int result, string filePath)
    {
        File.WriteAllText(filePath, result.ToString());
    }
}
