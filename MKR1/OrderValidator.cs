namespace MKR_1;

public class OrderValidator
{
    public readonly int MinDeadline;
    public readonly int MaxDeadline;
    public readonly int MinReward;
    public readonly int MaxReward;

    public OrderValidator(int minDeadline, int maxDeadline, int minReward, int maxReward)
    {
        MinDeadline = minDeadline;
        MaxDeadline = maxDeadline;
        MinReward = minReward;
        MaxReward = maxReward;
    }


    public void Validate(IEnumerable<Order> orders)
    {
        foreach (var order in orders)
        {
            Validate(order);
        }
    }

    public void Validate(Order order)
    {
        if (order.Reward < MinReward || order.Reward > MaxReward)
        {
            throw new ArgumentOutOfRangeException(
                nameof(order),
                $"Reward should be between {MinReward} and {MaxReward}." + Environment.NewLine +
                $"Actual reward: {order.Reward}, order: {order}");
        }
        if (order.Deadline < MinDeadline || order.Deadline > MaxDeadline)
        {
            throw new ArgumentOutOfRangeException(
                nameof(order),
                $"Deadline should be between {MinDeadline} and {MaxDeadline}." + Environment.NewLine +
                $"Actual deadline: {order.Deadline}, order: {order}");
        }
    }
}
