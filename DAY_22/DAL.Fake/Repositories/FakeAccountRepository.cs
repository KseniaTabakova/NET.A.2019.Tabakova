using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Interfaces;
using DAL.Interface.DTO;

namespace DAL.Fake.Repositories
{
    public class FakeAccountRepository : IAccountRepository
    {
        public void Create(AccountDto entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (!FakeStorage.Items.Contains(entity))
            {
                FakeStorage.Items.Add(entity);
            }
        }

        public void Delete(string key)
        {
            if(FakeStorage.Items.Any(a => a.AccountNumber == key))
            {
                FakeStorage.Items.Remove(FakeStorage.Items.Single(a => a.AccountNumber == key));
            }
        }

        public AccountDto Get(string key)
        {
            if (FakeStorage.Items.Any(a => a.AccountNumber == key))
            {
                return FakeStorage.Items.Single(a => a.AccountNumber == key);
            }

            return null;
        }

        public IEnumerable<AccountDto> GetAll()
        {
            return FakeStorage.Items;
        }

        public void Update(AccountDto entity)
        {
            AccountDto account = Get(entity.AccountNumber);
            account.AccountNumber = entity.AccountNumber;
            account.AccountType = entity.AccountType;
            account.Balance = entity.Balance;
            account.BonusPoints = entity.BonusPoints;
            account.Owner = entity.Owner;
            account.Status = entity.Status;
        }

        public void UpdateMany(IEnumerable<AccountDto> accounts)
        {
            foreach (var account in accounts)
            {
                Update(account);
            }
        }
    }
}
