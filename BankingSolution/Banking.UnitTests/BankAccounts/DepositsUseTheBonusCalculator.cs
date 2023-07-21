
namespace Banking.UnitTests.BankAccounts;

public class DepositsUseTheBonusCalculator
{
    [Fact]
    public void BonusCalculatorIsUsedAndBonusAppliedToBalance()
    {
        var stubbedBonusCalculator = new Mock<ICanCalculateBonusesForBankAccountDeposits>();
        var account = new BankAccount(stubbedBonusCalculator.Object);

        var openingBalance = account.GetBalance();
        var amountToDeposit = 112.23M;
        var amountOfBonusToReturn = 69.23M;

        // Set up mock BonusCalculator return
        stubbedBonusCalculator.Setup(b => b.CalculateBonusForDeposit(
            openingBalance, amountToDeposit
            )
        ).Returns(amountOfBonusToReturn);

        account.Deposit(amountToDeposit);

        Assert.Equal(openingBalance + amountOfBonusToReturn + amountToDeposit, account.GetBalance());
    }
}
