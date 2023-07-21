
namespace StringCalculatorKata;

public class StringCalculatorTests
{
    private readonly StringCalculator _calculator;

    public StringCalculatorTests()
    {
        _calculator = new StringCalculator(new Mock<ILogger>().Object, new Mock<IWebService>().Object);
    }

    [Fact]
    public void EmptyStringReturnsZero()
    {
        // Given

        // When
        var result = _calculator.Add("");

        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("1,2,3,4,5,6,7,8,9", 45)]
    public void CommaSeperatedNumbers(string numbers, int expected)
    {

        var result = _calculator.Add(numbers);

        Assert.Equal(expected, result);
    }
}
