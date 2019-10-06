using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using ORM;

namespace DAL.EF.Mappers
{
    public static class AccountMappers
    {
        public static AccountDto ToAccountDto(this Account account) =>
            new AccountDto()
            {
                AccountNumber = account.Number,
                AccountType = account.AccountType.Name,
                Owner = account.AccountOwner.ToAccountOwnerDto(),
                Balance = account.Balance,
                BonusPoints = account.BonusPoints,
                Status = account.Status
            };

        public static Account ToAccount(this AccountDto accountDto)
        {
            return new Account()
            {
                Number = accountDto.AccountNumber,
                AccountOwner = accountDto.Owner.ToAccountOwner(),
                Balance = accountDto.Balance,
                BonusPoints = accountDto.BonusPoints,
                Status = accountDto.Status,
                AccountType = new AccountType() { Name = accountDto.AccountType }
            };
        }

        public static void UpdateFromAccountDto(this Account account, AccountDto accountDto)
        {
            account.Balance = accountDto.Balance;
            account.BonusPoints = accountDto.BonusPoints;
            account.Status = accountDto.Status;
        }
    }
}
