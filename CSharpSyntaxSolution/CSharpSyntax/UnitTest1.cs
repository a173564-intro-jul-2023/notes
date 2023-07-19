namespace CSharpSyntax
{
    public class UnitTest1
    {
        [Fact]
        public void CanAddTwoNumbers()
        {
            // Given
            int a = 10; 
            int b = 20;
            int answer;

            // When
            answer = a + b; // System under test

            // Then
            Assert.Equal(30, answer);
        }

        [Theory]
        [InlineData(10, 20, 30)]
        [InlineData(2,8, 10)]
        public void CanAddAnyTwoIntegers(int a, int b, int expected)
        {
            int answer = a + b;
            Assert.Equal(expected, answer);
        }

        [Theory]
        [InlineData("Han", "Solo", "Solo, Han")]
        [InlineData(" Becky ", "Melvin       ", "Melvin, Becky")]
        public void FormattingMyName(string first, string last, string expected)
        {
            string fullName = Utils.FormatName(first, last);
            Assert.Equal(expected, fullName);
        }
    }
}