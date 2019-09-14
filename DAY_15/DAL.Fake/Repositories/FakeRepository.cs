using Bank.Library.AccountTypes;
using DAL.Interface.Interfaces;
using System.Collections.Generic;

namespace DAL.Fake
{
    public class FakeRepository : IRepository<BankAccount>
    {
        private readonly List<BankAccount> fakeRepository;

        public FakeRepository()
        {
            fakeRepository = new List<BankAccount>();
        }

        public void Update(BankAccount account)
        {
            int index = fakeRepository.FindIndex(x => x.Id == account.Id);
            fakeRepository.RemoveAt(index);
            fakeRepository.Insert(index, account);
        }

        public BankAccount GetBy(int id)
        {
            int index = fakeRepository.FindIndex(x => x.Id == id);
            return fakeRepository[index];
        }

        public void Create(BankAccount account)
        {
            fakeRepository.Add(account);
        }
    }
}
