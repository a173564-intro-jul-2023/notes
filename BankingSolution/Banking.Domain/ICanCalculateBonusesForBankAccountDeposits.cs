namespace Banking.Domain;

public interface ICanCalculateBonusesForBankAccountDeposits
{
    decimal CalculateBonusForDeposit(decimal balance, decimal amountToDeposit);
}