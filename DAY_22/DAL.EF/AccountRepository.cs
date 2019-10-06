using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF.Mappers;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using ORM;

namespace DAL.EF
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DbContext context;

        public AccountRepository(DbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(AccountDto entity)
        {
            var account = entity.ToAccount();
            account.AccountType = context.Set<AccountType>().Single(at => at.Name == entity.AccountType);
            context.Set<Account>().Add(account);
            context.SaveChanges();
        }

        public void Delete(string key)
        {
            throw new NotImplementedException();
        }

        public AccountDto Get(string key) =>
            context.Set<Account>().Single(account => account.Number == key).ToAccountDto();

        public IEnumerable<AccountDto> GetAll() =>
            context.Set<Account>()
            .AsEnumerable()
            .Select(account => account.ToAccountDto());

        public void Update(AccountDto entity)
        {
            var account = context.Set<Account>().Find(entity.AccountNumber)
                ?? throw new InvalidOperationException("There is no entity to update.");
            account.UpdateFromAccountDto(entity);
            context.Entry(account).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void UpdateMany(IEnumerable<AccountDto> accounts)
        {
            throw new NotImplementedException();
        }
    }
}
