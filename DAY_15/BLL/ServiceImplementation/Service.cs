using DAL.Fake;
using System;
using NLog;
using DAL.Interface.Interfaces;
using Bank.Library.Service;
using Bank.Library.AccountTypes;
using Bank.Library.Interfaces;
using Bank.Library.Account;

namespace BLL.ServiceImplementation
{
     public class Service : IAccountService
    {
        private IRepository<BankAccount> fakeRepository;
        //private IRepository<AccountHolder> fakeRepositoryHolders;

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initializes a new instance of the <see cref="Service"/> class.
        /// </summary>
        public Service()
        {
            fakeRepository = new FakeRepository();
            //fakeRepositoryHolders = new FakeRepositoryHolders();
       }
     
        public void OpenAccount(IAccountNumberGenerator gen, AccountHolder person, AccountType priveledge, AccountStatus status, int sum, int bonus, out string id)
        {
            BankAccount bankAccount;
            id = gen.GenerateAccountNumber(person + " " + priveledge);

            switch ((int)priveledge)
            {
                case 1:
                    {
                        bankAccount = new BaseAccount(int.Parse(id), person, status, priveledge, sum, bonus);break;
                    }             
                case 2:
                    {
                        bankAccount = new GoldAccount(int.Parse(id), person, status, priveledge, sum, bonus);break;
                    }
                case 3:
                    {
                        bankAccount = new PlatinumAccount(int.Parse(id), person, status, priveledge, sum, bonus);break;
                    }
                default:
                    {
                        bankAccount = new BaseAccount(int.Parse(id), person, status, priveledge, sum, bonus);break;
                    }
            }

            bankAccount.Status = AccountStatus.Active;
            fakeRepository.Create(bankAccount);
        }

        public void CloseAccount(int id)
        {
            BankAccount bankAccount = fakeRepository.GetBy(id);
            if (bankAccount.Status == AccountStatus.Close)
            {
                throw new ArgumentException("This account has already been closed. ", nameof(id));
            }

            bankAccount.Status = AccountStatus.Close;
            fakeRepository.Update(bankAccount);
        }

        public void AddMoney(int id, int value)
        {
            BankAccount bankAccount = fakeRepository.GetBy(id);
            try
            {
                bankAccount.Put(value);
            }
            catch (ArgumentException e)
            {
                logger.Warn(e.Message, e.ParamName);
            }

            fakeRepository.Update(bankAccount);
        }

        public void WithdrawMoney(int id, int value)
        {
            BankAccount bankAccount = fakeRepository.GetBy(id);
            try
            {
                bankAccount.Withdraw(value);
            }
            catch (ArgumentException e)
            {
                logger.Warn(e.Message, e.ParamName);
            }
            catch (InvalidOperationException e)
            {
                logger.Warn(e.Message);
            }

            fakeRepository.Update(bankAccount);
        }

        /// <summary>
        /// Gets the information about account by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public string GetInfo(int id)
        {
            BankAccount bankAccount = fakeRepository.GetBy(id);
            return bankAccount.ToString();
        }

        public void GetAllAccounts()
        {
            throw new NotImplementedException();
        }
        public void CreateAccount(AccountHolder account, AccountType type, int sum, int points)
        {
            throw new NotImplementedException();
        }
    }
}
