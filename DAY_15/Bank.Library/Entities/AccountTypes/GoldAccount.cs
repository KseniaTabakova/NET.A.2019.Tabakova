using Bank.Library.AccountTypes;
using System;

namespace Bank.Library.Account
{
    /// <summary>
    /// Class represents functionality for Gold Account type.
    /// </summary>
    public class GoldAccount : BaseAccount
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
        public GoldAccount(int id, AccountHolder person, AccountStatus status, AccountType type, int sum, int bonus) : base(id, person, status,type, sum, bonus)
        {
        }

        /// <summary>
        /// Calculation of bonuses depending on the type of account.
        /// </summary>
        /// <param name="type">Type of account.</param>
        /// <returns>Bonuses.</returns>
        public override int CalculateBonus(AccountType type = AccountType.Gold)
        {
            return Balance / 5000;
        }

        /// <summary>
        /// Account balance at which you can withdraw money depending on the type of account.
        /// </summary>
        /// <param name="totalAmount">Amount of money witch account have.</param>
        /// <returns>True if the operation is allowed.</returns>
        public override bool BalanceIsPositive(int totalAmount)
        {
            return totalAmount >= 100;
        }
    }
}
