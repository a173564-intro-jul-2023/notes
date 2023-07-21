
using Banking.Domain;

namespace Banking.UnitTests.BonusCalculation;

public class BonusCalculatorTests
{
    [Theory]
    [InlineData(100, 10)]
    [InlineData(200, 20)]
    public void HasSufficientBalance(decimal amountOfDeposit, decimal expectedBonus)
    {
        var duringBusinessHoursClock = new Mock<IProvideTheBusinessClock>();
        duringBusinessHoursClock.Setup(c => c.IsDuringBusinessHours()).Returns(true);

        var bonusCalculator = new StandardBonusCalculator(duringBusinessHoursClock.Object);
        var balanceOnAccount = 5000M;

        decimal bonus = bonusCalculator.CalculateBonusForDeposit(balanceOnAccount, amountOfDeposit);

        Assert.Equal(expectedBonus, bonus);
    }

    [Theory]
    [InlineData(100, 0)]
    [InlineData(200, 0)]
    public void HasInsufficientBalance(decimal amountOfDeposit, decimal expectedBonus)
    {
        var duringBusinessHoursClock = new Mock<IProvideTheBusinessClock>();
        duringBusinessHoursClock.Setup(c => c.IsDuringBusinessHours()).Returns(true);

        var bonusCalculator = new StandardBonusCalculator(duringBusinessHoursClock.Object);
        var balanceOnAccount = 4999.99M;

        decimal bonus = bonusCalculator.CalculateBonusForDeposit(balanceOnAccount, amountOfDeposit);

        Assert.Equal(expectedBonus, bonus);
    }

    [Fact]
    public void BonusIsHalfOutsideBusinessHours()
    {
        var duringBusinessHoursClock = new Mock<IProvideTheBusinessClock>();
        duringBusinessHoursClock.Setup(c => c.IsDuringBusinessHours()).Returns(false);

        var bonusCalculator = new StandardBonusCalculator(duringBusinessHoursClock.Object);

        var bonus = bonusCalculator.CalculateBonusForDeposit(6000, 100);

        Assert.Equal(5M, bonus);
    }
}
