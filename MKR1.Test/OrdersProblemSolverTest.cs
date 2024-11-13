using MKR_1;
using Xunit.Abstractions;

namespace Test;

public class OrdersProblemSolverTest(ITestOutputHelper output)
{
    private readonly ITestOutputHelper _output = output;

    [Fact]
    public void Solve_ExampleTestCase_1_ToBeSuccessful()
    {
        //Arrange
        var orders = new Order[]
        {
            new(1, 10),
            new(2, 12),
        };
        var expectedResult = 22;

        //Act
        var actualResult = OrdersProblemSolver.Solve(orders);

        //Assert
        Assert.Equal(expectedResult, actualResult);
        _output.WriteLine($"Example test case 1 solved: " +
                          $"{orders[0]}, {orders[1]}, " +
                          $"max reward = {expectedResult}");
    }


    [Fact]
    public void Solve_ExampleTestCase_2_ToBeSuccessful()
    {
        //Arrange
        var orders = new Order[]
        {
            new(1, 10),
            new(1, 20),
            new(3, 24),
        };
        var expectedResult = 44;

        //Act
        var actualResult = OrdersProblemSolver.Solve(orders);

        //Assert
        Assert.Equal(expectedResult, actualResult);
        _output.WriteLine($"Example test case 2 solved: " +
                          $"{orders[0]}, {orders[1]}, {orders[2]}; " +
                          $"max reward = {expectedResult}");
    }



    [Theory]
    [InlineData(650, new int[] { 2, 100, 1, 50, 2, 150, 3, 200, 2, 300 })]
    [InlineData(200_000, new int[] { 5, 100_000, 5, 50_000, 5, 30_000, 5, 20_000 })]
    [InlineData(330, new int[] {3, 20, 4, 50, 3, 50, 2, 60, 1, 30, 4, 120, 3, 100})]
    public void Solve_SimpleCases_ToBeSuccessful(int expectedResult, int[] data)
    {
        //Arrange
        var orders = new List<Order>();

        for (int i = 0; i < data.Length; i += 2)
        {
            var order = new Order(data[i], data[i + 1]);
            orders.Add(order);
        }

        //Act
        var actualResult = OrdersProblemSolver.Solve(orders);

        //Assert
        Assert.Equal(expectedResult, actualResult);
        _output.WriteLine($"Simple case: {string.Join(", ", orders)};");
        _output.WriteLine($"Expected: {expectedResult};");
        _output.WriteLine($"Actual: {actualResult};");
    }


    [Fact]
    public void Solve_MaxNumberOfOrdersWithMaxRewards_ToBeSuccessful()
    {
        var maxNumberOfOrders = 1000;
        var maxReward = 100_000;
        var maxDeadline = 100_000;

        var orders = new List<Order>();

        for(int i = 0; i < maxNumberOfOrders; i++)
        {
            var order = new Order(maxDeadline, maxReward);
            orders.Add(order);
        }

        var expectedResult = 100_000_000;

        var actualResult = OrdersProblemSolver.Solve(orders);

        Assert.Equal(expectedResult, actualResult);
        _output.WriteLine($"Max number of orders with max deadline and rewards test case;");
        _output.WriteLine($"Number of orders: {maxNumberOfOrders};");
        _output.WriteLine($"Max deadline: {maxNumberOfOrders};");
        _output.WriteLine($"Max reward: {maxReward};");
        _output.WriteLine($"Expected: {expectedResult};");
        _output.WriteLine($"Actual: {actualResult};");
    }
}