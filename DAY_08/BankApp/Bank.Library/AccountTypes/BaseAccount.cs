using Bank.Library.Account;
using System;


namespace Bank.Library.AccountTypes
{
    /// <summary>
    /// Class represents functionality for Base Account type.
    /// </summary>
    public class BaseAccount : BankAccount
    {
        /// <summary>
        /// Parametrized constructor.
        /// </summary>
        /// <param name="id">Account given id.</param>
        /// <param name="person">Account holder.</param>
        /// <param name="status">Account status.</param>
        /// <param name="type">Account type.</param>
        /// <param name="sum">Account first balance.</param>
        /// <param name="bonus">Account first given bonuses.</param>
        public BaseAccount(int id, AccountHolder person, AccountStatus status, AccountType type, int sum, int bonus) : base( id, person, status, type, sum, bonus)
        {
        }

        /// <summary>
        /// Calculation of bonuses depending on the type of account.
        /// </summary>
        /// <param name="type">Type of account.</param>
        /// <returns>Bonuses.</returns>
        public override int CalculateBonus(AccountType type = AccountType.Base)
        {
            return Balance / 50000;
        }

        /// <summary>
        /// Account balance at which you can withdraw money depending on the type of account.
        /// </summary>
        /// <param name="totalAmount">Amount of money witch account have.</param>
        /// <returns>True if the operation is allowed.</returns>
        public override bool BalanceIsPositive(int totalAmount)
        {
            return totalAmount >= 0;
        }
    }
}
