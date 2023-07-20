
using Banking.Domain;

namespace Banking.UnitTests.BankAccounts;

public class MakingWithdrawals
{
    [Fact]
    public void MakingAWithdrawalDecreasesTheBalance()
    {
        var account = new BankAccount();
        var openingBalance = account.GetBalance();
        var amountToWithdraw = 1.01M;

        account.Withdraw(amountToWithdraw);

        Assert.Equal(openingBalance - amountToWithdraw, account.GetBalance());
    }

    [Fact]
    public void CanTakeEntireBalance()
    {
        var account = new BankAccount();

        account.Withdraw(account.GetBalance());

        Assert.Equal(0, account.GetBalance());
    }

    [Theory]
    [InlineData(-0.1)]
    [InlineData(0)]
    public void InvalidAmountsAreNotAllowed(decimal amount)
    {
        var account = new BankAccount();
        var openingBalance = account.GetBalance();

        Assert.Throws<InvalidBankAccountTransactionAmount>(() =>
        {
            account.Withdraw(amount);
        });
        Assert.Equal(openingBalance, account.GetBalance());
        
    }
}
