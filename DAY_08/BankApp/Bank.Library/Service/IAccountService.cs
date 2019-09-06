using Bank.Library.Account;
using Bank.Library.AccountTypes;
using System;
using System.Collections.Generic;

namespace Bank.Library.Service
{
    interface IAccountService
    {
        IEnumerable<BankAccount> GetAllAccounts();
        void AddMoney(int id, int amount);
        void WithdrawMoney(int id, int amount);
        void CloseAccount(int id);
        void CreateAccount(AccountHolder account, AccountType type, int sum, int points);
    }
}
