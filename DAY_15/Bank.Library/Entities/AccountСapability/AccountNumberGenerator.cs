using Bank.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Library.Entities.AccountСapability
{
    public class AccountNumberGenerator : IAccountNumberGenerator
    {
        /// <summary>
        /// Generates the account number by the key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public string GenerateAccountNumber(string key)
        {
            return Math.Abs(key.GetHashCode()).ToString();
        }
    }
}
