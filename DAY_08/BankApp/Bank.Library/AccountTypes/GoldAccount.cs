using Bank.Library.AccountTypes;
using System;
using Bank.Library.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Library.Account
{
    class GoldAccount : BaseAccount
    {
        public GoldAccount(int id, AccountHolder person, AccountStatus status, AccountType type, int sum, int bonus) : base(id, person, status,type, sum, bonus)
        {

        }

        public override int CalculateBonus(AccountType type = AccountType.Gold)
        {
            return Balance / 1000;
        }

        protected override bool BalanceIsPositive(int value)
        {
            return value >= 100;
        }
    }
}
