using Bank.Library.Account;
using Bank.Library.AccountTypes;
using System.Collections.Generic;

namespace Bank.Library.Service
{
    /// <summary>
    /// nterface contains common functionality for bank service.
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Add account to the bank.
        /// </summary>
        /// <param name="account">Account holder.</param>
        /// <param name="type">Account type.</param>
        /// <param name="sum">Account first sum.</param>
        /// <param name="points">Account first bonus.</param>
        void CreateAccount(AccountHolder account, AccountType type, int sum, int points);

        /// <summary>
        /// Close account in the bank.
        /// </summary>
        /// <param name="id">Id of bank account witch will be closed.</param>
        void CloseAccount(int id);

        /// <summary>
        /// Put money to the appropriate bank account.
        /// </summary>
        /// <param name="id">Bank account id.</param>
        /// <param name="sum">Amount of money to be added.</param>
        void AddMoney(int id, int sum);

        /// <summary>
        /// Withdraw money from the appropriate bank account.
        /// </summary>
        /// <param name="id">Bank account id.</param>
        /// <param name="sum">Amount of money to be withdrawed.</param>
        void WithdrawMoney(int id, int sum);    

        /// <summary>
        /// Represents all available bank accounts in the bank.
        /// </summary>
        void GetAllAccounts();
    }
}
