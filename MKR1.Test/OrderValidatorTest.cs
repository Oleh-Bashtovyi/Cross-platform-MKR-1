using MKR_1;
using Xunit.Abstractions;

namespace Test;

public class OrderValidatorTest
{
    private readonly OrderValidator _validator;
    private readonly ITestOutputHelper _output;

    public OrderValidatorTest(ITestOutputHelper output)
    {
        int minReward = 0;
        int maxReward = 100_000;
        int minDeadline = 1;
        int maxDeadline = 100_000;
        _validator = new OrderValidator(minDeadline, maxDeadline, minReward, maxReward);
        _output = output;
    }

    [Theory]
    [InlineData(5, -1)]
    [InlineData(5, 100_001)]
    [InlineData(100_001, 54)]
    [InlineData(0, 54)]
    public void Validate_InvalidOrder_ThrowsArgumentOutOfRangeException(int deadline, int reward)
    {
        var order = new Order(deadline, reward);
        var orders = new Order[1] { order };

        var error = Assert.Throws<ArgumentOutOfRangeException>(() => _validator.Validate(orders));
        _output.WriteLine(error.Message);
    }
}
