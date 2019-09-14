using Bank.Library.Account;
using System;

namespace Bank.Library.AccountСapability
{
    /// <summary>
    /// Interface contains functionality for bonus calculation.
    /// </summary>
    public interface IBonusCalculator
    {
        int CalculateBonus(AccountType accountType);
    }
}
