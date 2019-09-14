using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Library.Interfaces
{
    public interface IAccountNumberGenerator
    {
        string GenerateAccountNumber(string key);
    }
}
