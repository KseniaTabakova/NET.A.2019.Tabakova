using Bank.Library.Account;
using Bank.Library.AccountStorage;
using Bank.Library.AccountTypes;
using System;
using System.Collections.Generic;

namespace Bank.Library.Service
{
    public class AccountService : IAccountService
    {
        private readonly BankStorage accountStorage;
        BankAccount newAccount;
        private static int _id;

        public static int Id
        {
            get { return _id; }
        }
        public AccountService()
        {
            accountStorage = new BankStorage();
        }

        public void AddMoney(int id, int sum)
        {
            var account = FindAccount(id);
            if (account.Status == AccountStatus.Close)
                Console.WriteLine("Account is closed.");
            account.Put(sum);
        }

        public void WithdrawMoney(int id, int sum)
        {
            var account = FindAccount(id);
            if (account.Status == AccountStatus.Close)
                Console.WriteLine("Account is closed.");
            account.Withdraw(sum);
        }

        public void CreateAccount(AccountHolder account, AccountType type, int sum, int points = 0)
        {
            ++_id;
            newAccount = accountStorage.DefineAccount(_id, account.FirstName, account.LastName, account.Phone, AccountStatus.Active,
                type, sum, points);
            accountStorage.AddAccount(newAccount);

        }

        public void CloseAccount(int id)
        {
            var account = FindAccount(id);
            account.Status = AccountStatus.Close;
        }

        private BankAccount FindAccount(int id)
        {
            accountStorage.LoadAccountsFromFile();
            return accountStorage.FindAccount(id);
        }

        public IEnumerable<BankAccount> GetAllAccounts()
        {
            return accountStorage.ShowAllAccounts();
        }



    }

}
