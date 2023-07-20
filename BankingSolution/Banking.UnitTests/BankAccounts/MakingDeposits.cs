
using Banking.Domain;

namespace Banking.UnitTests.BankAccounts;

public class MakingDeposits
{
    [Fact]
    public void DepositsIncreaseTheBalance()
    {
        // Given - arrange
        var account = new BankAccount();
        var openingBalance = account.GetBalance();
        var amountToDeposit = 100.23M;

        // When - act
        account.Deposit(amountToDeposit);

        // Then - assert
        Assert.Equal(openingBalance + amountToDeposit, account.GetBalance());
    }
}
