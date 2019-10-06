using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class AccountMappers
    {
        public static AccountDto ToAccountDto(this Account account) =>
            new AccountDto()
            {
                AccountNumber = account.AccountNumber,
                AccountType = account.GetType().Name,
                Owner = account.Owner.ToAccountOwnerDto(),
                Balance = account.Balance,
                BonusPoints = account.BonusPoints,
                Status = account.Status.ToString()
            };

        public static Account ToAccount(this AccountDto accountDto, IAccountFactory accountFactory)
        {
            Account account = accountFactory.GetInstance(accountDto.AccountType);
            account.AccountNumber = accountDto.AccountNumber;
            account.Owner = accountDto.Owner.ToAccountOwner();
            account.Balance = accountDto.Balance;
            account.BonusPoints = accountDto.BonusPoints;
            Enum.TryParse<AccountStatus>(accountDto.Status, out AccountStatus status);
            account.Status = status;

            return account;
        }
    }
}
