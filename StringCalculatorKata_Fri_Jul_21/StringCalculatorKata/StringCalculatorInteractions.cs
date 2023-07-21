
using Castle.Core.Logging;

namespace StringCalculatorKata;

public class StringCalculatorInteractions
{
    [Theory]
    [InlineData("15", "15")]
    [InlineData("1,2", "3")]
    public void ResultsAreLogged(string numbers, string expected)
    {
        var loggerMock = new Mock<ILogger>();
        var mockedWebService = new Mock<IWebService>();
        var calculator = new StringCalculator(loggerMock.Object, mockedWebService.Object);

        calculator.Add(numbers);

        loggerMock.Verify(logger => logger.Log(expected));
        mockedWebService.Verify(ws => ws.NotifyOfLoggerFailure(It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public void WebServiceIsCalledOnLoggerFailure()
    {
        var loggerStub = new Mock<ILogger>();
        var mockedWebService = new Mock<IWebService>();
        var calculator = new StringCalculator(loggerStub.Object, mockedWebService.Object);
        loggerStub.Setup(m => m.Log(It.IsAny<string>()))
            .Throws<CalculatorLoggerException>();

        calculator.Add("1");

        mockedWebService.Verify(m => m.NotifyOfLoggerFailure("Blammo!"));
    }
}
