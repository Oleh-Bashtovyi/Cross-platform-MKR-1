namespace MKR_1;

public class Order
{
    public int Deadline {  get; set; }
    public int Reward {  get; set; }

    public Order() { }

    public Order(int deadline, int reward)
    {
        Deadline = deadline;
        Reward = reward;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Order other)
        {
            return Deadline == other.Deadline && Reward == other.Reward;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return $"[{Deadline}, {Reward}]";
    }
}
