namespace MKR_1;

public static class OrdersProblemSolver
{
    public const int MIN_REWARD = 0;
    public const int MAX_REWARD = 100_000;
    public const int MIN_DEADLINE = 1;
    public const int MAX_DEADLINE = 100_000;

    /// <summary>
    /// Calculate the maximum reward that can be obtained by fulfilling the orders.
    /// </summary>
    /// <param name="orders"></param>
    /// <returns>maximum reward</returns>
    public static int Solve(IEnumerable<Order> orders)
    {
        if (!orders.Any())
        {
            return 0;
        }

        var validator = new OrderValidator(MIN_DEADLINE, MAX_DEADLINE, MIN_REWARD, MAX_REWARD);

        validator.Validate(orders);

        var sortedOrders = orders.OrderByDescending(x => x.Reward).ToList();
        var maxDeadline = orders.Max(x => x.Deadline);

        var occupied = new bool[maxDeadline + 1];

        var totalReward = 0;

        foreach(var order in sortedOrders)
        {
            // find the nearest free day before the deadline
            for (int day = order.Deadline; day > 0; day--)
            {
                if (!occupied[day])
                {
                    occupied[day] = true; 
                    totalReward += order.Reward;
                    break;
                }
            }
        }

        return totalReward;
    }
}
