using Bank.Library.AccountTypes;
using System.Collections.Generic;

namespace Bank.Library.AccountStorage
{
    /// <summary>
    /// Interface contains common functionality for bank accounts storage.
    /// </summary>
    public interface IStorage
    {
        /// <summary>
        /// Add bank account to the storage.
        /// </summary>
        /// <param name="account">Bank account which should be added to the storage.</param>
        void AddAccount(BankAccount account);

        /// <summary>
        /// Remove bank account from the storage.
        /// </summary>
        /// <param name="account">Bank account which should be removed from the storage.</param>
        void RemoveAccount(BankAccount account);

        /// <summary>
        /// Put money to the appropriate bank account.
        /// </summary>
        /// <param name="account">Bank account to which account money should be added.</param>
        /// <param name="sum">Amount of money to be added.</param>
        void PutMoneyInAccount(BankAccount account, int sum);

        /// <summary>
        /// Withdraw money from the appropriate bank account.
        /// </summary>
        /// <param name="account">Bank account from which account money should be withdrawed.</param>
        /// <param name="sum">Amount of money to be withdrawed.</param>
        void WithdrawMoneyFromAccount(BankAccount account, int sum);

        /// <summary>
        /// Represents all available bank accounts in the storage.
        /// </summary>
        /// <returns>Available accounts.</returns>
        IEnumerable<BankAccount> ShowAllAccounts();
    }
}
