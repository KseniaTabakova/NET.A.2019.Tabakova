using Bank.Library.Account;
using Bank.Library.AccountStorage;
using Bank.Library.AccountTypes;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Bank.Library.Service
{
    /// <summary>
    /// Class provides accounts service.
    /// </summary>
    public class AccountService : IAccountService, IEnumerable<BankAccount>
    {
        private readonly BankStorage accountStorage;
        private BankAccount newAccount;
        private static int _id;

        /// <summary>
        /// Incapsulation of account Id.
        /// </summary>
        public static int Id
        {
            get { return _id; }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public AccountService()
        {
            accountStorage = new BankStorage();
        }

        /// <summary>
        /// Put money to the appropriate bank account.
        /// </summary>
        /// <param name="id">Bank account id.</param>
        /// <param name="sum">Amount of money to be added.</param>
        public void AddMoney(int id, int sum)
        {
            var account = FindAccount(id);
            if (account.Status == AccountStatus.Close)
                Console.WriteLine("Impossible operation: account is closed.");
            account.Put(sum);
        }

        /// <summary>
        /// Withdraw money from the appropriate bank account.
        /// </summary>
        /// <param name="id">Bank account id.</param>
        /// <param name="sum">Amount of money to be withdrawed.</param>
        public void WithdrawMoney(int id, int sum)
        {
            var account = FindAccount(id);
            if (account.Status == AccountStatus.Close)
                Console.WriteLine("Impossible operation: account is closed.");
            account.Withdraw(sum);
        }

        /// <summary>
        /// Add account to the bank.
        /// </summary>
        /// <param name="account">Account holder.</param>
        /// <param name="type">Account type.</param>
        /// <param name="sum">Account first sum.</param>
        /// <param name="points">Account first bonus.</param>
        public void CreateAccount(AccountHolder account, AccountType type, int sum, int points = 0)
        {
            int lastId = accountStorage.Count();
            _id= lastId+1;
            newAccount = accountStorage.DefineAccount(_id, account.FirstName, account.LastName, account.Phone, AccountStatus.Active,
                type, sum, points);
            accountStorage.AddAccount(newAccount);
        }

        /// <summary>
        /// Close account in the bank.
        /// </summary>
        /// <param name="id">Id of bank account witch will be closed.</param>
        public void CloseAccount(int id)
        {
            var account = FindAccount(id);
            account.Status = AccountStatus.Close;
        }

        /// <summary>
        /// Returns instance of bank account.
        /// </summary>
        /// <param name="id">Bank account Id.</param>
        /// <returns>Bank account instance.</returns>
        private BankAccount FindAccount(int id)
        {
            return accountStorage.FindAccount(id);
        }

        public void GetAllAccounts()
        {
           accountStorage.ShowAllAccounts();
           foreach (BankAccount ba in accountStorage)
                Console.WriteLine(ba.ToString()+"\n");
        }

        public IEnumerator<BankAccount> GetEnumerator()
        {
            return accountStorage.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
