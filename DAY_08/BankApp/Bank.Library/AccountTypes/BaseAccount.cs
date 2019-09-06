using Bank.Library.Account;
using Bank.Library.AccountСapability;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Library.AccountTypes
{
    public class BaseAccount : BankAccount
    {
        public BaseAccount(int id, AccountHolder person, AccountStatus status, AccountType type, int sum, int bonus) : base( id, person, status, type, sum, bonus)
        {
           
        }

        public override int CalculateBonus(AccountType type = AccountType.Base)
        {
            return Balance / 10000;
        }

        protected override bool BalanceIsPositive(int value)
        {
            return value >= 0;
        }
    }
}
