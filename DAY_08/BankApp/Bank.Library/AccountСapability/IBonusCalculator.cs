using Bank.Library.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Library.AccountСapability
{
    public interface IBonusCalculator
    {
        int CalculateBonus(AccountType accountType);
    }
}
