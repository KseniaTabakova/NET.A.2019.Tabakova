using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Interfaces;
using DAL.Interface.Interfaces;
using DAL.Interface.DTO;
using BLL.Interface.Entities;
using BLL.Mappers;
using BLL.Exceptions;
using Logging;

namespace BLL.ServiceImplementation
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository repository;
        private readonly IAccountFactory accountFactory;

        public AccountService(IAccountRepository repository, IAccountFactory accountFactory)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.accountFactory = accountFactory ?? throw new ArgumentNullException(nameof(accountFactory));
        }

        public void OpenAccount(string ownerName, string accountType, IAccountNumberCreateService numberCreator)
        {
            if (string.IsNullOrEmpty(ownerName))
            {
                throw new ArgumentException("Argument is null or empty", nameof(ownerName));
            }

            if (numberCreator is null)
            {
                throw new ArgumentNullException(nameof(numberCreator));
            }

            var account = accountFactory.GetInstance(accountType);
            account.AccountNumber = numberCreator.GetNextNumber();
            account.Owner = new AccountOwner() { FirstName = ownerName };
            account.Status = AccountStatus.Active;

            repository.Create(account.ToAccountDto());
        }

        public void CloseAccount(string accountNumber)
        {
            var account = GetAccount(accountNumber);

            account.Status = AccountStatus.Closed;

            repository.Update(account.ToAccountDto());
        }

        public void DepositAccount(string accountNumber, decimal value)
        {
            var account = GetAccount(accountNumber);

            if (account.Status == AccountStatus.Active)
            {
                account.Deposit(value);
            }

            repository.Update(account.ToAccountDto());
        }

        public void WithdrawAccount(string accountNumber, decimal value)
        {
            var account = GetAccount(accountNumber);

            if (account.Status == AccountStatus.Active)
            {
                account.Withdraw(value);
            }

            repository.Update(account.ToAccountDto());
        }

        public void Transfer(string sourceAccountNumber, string destinationAccountNumber, decimal value)
        {
            var sourceAccount = GetAccount(sourceAccountNumber);
            var destinationAccount = GetAccount(destinationAccountNumber);

            sourceAccount.Withdraw(value);
            destinationAccount.Deposit(value);

            repository.UpdateMany(new[] { sourceAccount.ToAccountDto(), destinationAccount.ToAccountDto() });
        }

        public IEnumerable<Account> GetAllAccounts() =>
            repository.GetAll().Select(accountDto => accountDto.ToAccount(accountFactory)).Where(account => account.Status == AccountStatus.Active);

        #region Private methods

        private Account GetAccount(string accountNumber)
        {
            var accountDto = repository.Get(accountNumber) ?? throw new AccountNotFoundException(nameof(accountNumber));
            return accountDto.ToAccount(accountFactory);
        }

        #endregion
    }
}
