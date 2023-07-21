
using Banking.Domain;

namespace Banking.UnitTests.BankAccounts;

public class Overdrafts
{
    [Fact (Skip = "Undesired original behavior, was fixed")]
    public void BadCurrentBehavior()
    {
        var account = new BankAccount(new Mock<ICanCalculateBonusesForBankAccountDeposits>().Object);
        var openingBalance = account.GetBalance();
        var amountToWithdraw = openingBalance + 0.01M;

        account.Withdraw(amountToWithdraw);

        Assert.Equal(openingBalance - amountToWithdraw, account.GetBalance());
    }

    [Fact]
    public void DoesNotDecreaseTheBalanceAndThrowsException()
    {
        var account = new BankAccount(new Mock<ICanCalculateBonusesForBankAccountDeposits>().Object);
        var openingBalance = account.GetBalance();
        var amountToWithdraw = openingBalance + 0.01M;

        Assert.Throws<AccountOverdraftException>(() =>
        {
            account.Withdraw(amountToWithdraw);
        });
        Assert.Equal(openingBalance, account.GetBalance());
    }
}
