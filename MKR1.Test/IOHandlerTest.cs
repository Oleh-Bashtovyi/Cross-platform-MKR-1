using MKR_1;

namespace Test;

public class IOHandlerTest
{
    [Theory]
    [InlineData("test_orders_count_out_of_range_max.txt")]
    [InlineData("test_orders_count_out_of_range_min.txt")]
    public void ReadOrders_OrdersNumberOutOfRange_ThrowsArgumentOutOfRangeException(string fileName)
    {
        var filePath = Path.Combine("TestData", fileName);

        Assert.Throws<InvalidOperationException>(() => IOHandler.ReadOrders(filePath));
    }



    [Fact]
    public void ReadOrders_ValidFile_ReturnsExpectedOrders()
    {
        var expectedResult = new Order[]
        {
            new(2, 25),
            new(3, 45)
        };

        var filePath = Path.Combine("TestData", "test_reading.txt");
        var actualResult = IOHandler.ReadOrders(filePath);

        Assert.Equal(expectedResult, actualResult);
    }
}
