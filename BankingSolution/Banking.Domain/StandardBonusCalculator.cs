using System.Runtime.InteropServices;

namespace Banking.Domain;

public class StandardBonusCalculator : ICanCalculateBonusesForBankAccountDeposits
{
    private readonly IProvideTheBusinessClock _businessClock;

    public StandardBonusCalculator(IProvideTheBusinessClock businessClock)
    {
        _businessClock = businessClock;
    }

    public decimal CalculateBonusForDeposit(decimal balanceOnAccount, decimal amountOfDeposit)
    {
        decimal bonusMultiplier = _businessClock.IsDuringBusinessHours() ? .10M : .05M;
        return balanceOnAccount >= 5000 ? amountOfDeposit * bonusMultiplier : 0;
    }
}