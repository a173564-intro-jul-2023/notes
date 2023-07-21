
using Banking.Domain;

namespace Banking.UnitTests.BankAccounts;


public class NewAccounts
{
    [Fact]
    public void NewAccountsHaveCorrectOpeningBalance()
    {
        // Creates new instance of the BankAccount class
        var account = new BankAccount(new Mock<ICanCalculateBonusesForBankAccountDeposits>().Object);

        // Calls GetBalance method from BankAccount object
        decimal balance = account.GetBalance();

        Assert.Equal(5000, balance);
    }
}
