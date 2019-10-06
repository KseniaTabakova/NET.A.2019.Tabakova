using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    public interface IAccountService
    {
        void WithdrawAccount(string accountNumber, decimal value);

        void DepositAccount(string accountNumber, decimal value);

        void Transfer(string sourceAccountNumber, string destinationAccountNumber, decimal value);

        void OpenAccount(string ownerName, string accountType, IAccountNumberCreateService numberCreator);

        void CloseAccount(string accountNumber);

        IEnumerable<Account> GetAllAccounts();
    }
}
