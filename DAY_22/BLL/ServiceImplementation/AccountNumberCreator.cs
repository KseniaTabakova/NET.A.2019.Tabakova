using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Interfaces;
using DAL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    public class AccountNumberCreator : IAccountNumberCreateService
    {
        private const string initialNumber = "0000000000000000";

        private readonly IAccountRepository repository;

        public AccountNumberCreator(IAccountRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public string GetNextNumber()
        {
            string lastAccountNumber = GetLastAccountNumber() ?? initialNumber;
            return CalculateNext(lastAccountNumber);
        }

        private string GetLastAccountNumber() => repository
            .GetAll()
            .Select(a => a.AccountNumber)
            .OrderBy(s => s)
            .LastOrDefault();

        private string CalculateNext(string lastAccountNumber) =>
            string.Format("{0:0000000000000000}", long.Parse(lastAccountNumber) + 1);
    }
}
