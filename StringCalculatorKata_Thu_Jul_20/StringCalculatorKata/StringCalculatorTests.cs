
namespace StringCalculatorKata
{
    public class StringCalculatorTests
    {
        [Fact]
        public void EmptyStringReturnsZero()
        {
            // Given
            var calculator = new StringCalculator();

            // When
            var result = calculator.Add("");

            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("9", 9)]
        [InlineData("32", 32)]
        public void OneNumber(string number, int expected)
        {
            // Given
            var calculator = new StringCalculator();

            // When
            var result = calculator.Add(number);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("9,21", 30)]
        [InlineData("108,0", 108)]
        public void TwoNumbers(string numbers, int expected)
        {
            // Given
            var calculator = new StringCalculator();

            // When
            var result = calculator.Add(numbers);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1,2,3", 6)]
        [InlineData("2,2,2,2", 8)]
        [InlineData("4,8,15,16,23,42", 108)]
        public void UnknownNumbers(string numbers, int expected)
        {
            // Given
            var calculator = new StringCalculator();

            // When
            var result = calculator.Add(numbers);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1\n2\n3", 6)]
        [InlineData("2,2\n2,2", 8)]
        [InlineData("4,8\n15,16,23\n42", 108)]
        public void SplitOnNewLine(string numbers, int expected)
        {
            // Given
            var calculator = new StringCalculator();

            // When
            var result = calculator.Add(numbers);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("//;\n1;2", 3)]
        [InlineData("//x\n2x2x2x2", 8)]
        [InlineData("//v\n4,8\n15v16,23\n42", 108)]
        public void SupportDifferentDeliminators(string numbers, int expected)
        {
            // Given
            var calculator = new StringCalculator();

            // When
            var result = calculator.Add(numbers);

            Assert.Equal(expected, result);
        }
    }
}
