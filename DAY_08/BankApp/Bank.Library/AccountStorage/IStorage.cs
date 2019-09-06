using Bank.Library.AccountTypes;
using System.Collections.Generic;

namespace Bank.Library.AccountStorage
{
    public interface IStorage
    {
        void AddAccount(BankAccount account);

        void RemoveAccount(BankAccount account);

        void PutMoneyInAccount(BankAccount account, int sum);

        void WithdrawMoneyFromAccount(BankAccount account, int sum);

        IEnumerable<BankAccount> ShowAllAccounts();
    }
}
