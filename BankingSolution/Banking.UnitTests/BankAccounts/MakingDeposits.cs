
using Banking.Domain;
using System.Reflection.Metadata.Ecma335;

namespace Banking.UnitTests.BankAccounts;

public class MakingDeposits
{
    [Fact]
    public void DepositsIncreaseTheBalance()
    {
        // Given - arrange
        var account = new BankAccount(new Mock<ICanCalculateBonusesForBankAccountDeposits>().Object);
        var openingBalance = account.GetBalance();
        var amountToDeposit = 100.23M;

        // When - act
        account.Deposit(amountToDeposit);

        // Then - assert
        Assert.Equal(openingBalance + amountToDeposit, account.GetBalance());
    }
}
