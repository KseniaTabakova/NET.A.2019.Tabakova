using Bank.Library.Account;
using Bank.Library.AccountTypes;
using Bank.Library.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Bank.Library.AccountStorage
{
    class BankStorage : IStorage, IEnumerable<BankAccount>
    {
        private readonly List<BankAccount> accounts;
        private readonly string filePath = AppDomain.CurrentDomain.BaseDirectory + "BankClients.dat";

        public BankStorage()
        {
            accounts = new List<BankAccount>();
            LoadAccountsFromFile();
        }

        public BankAccount FindAccount(int id)
        {
            return accounts.Find(a=>a.id ==id);
        }

        public void AddAccount(BankAccount account)
        {
            if (accounts.Contains(account))
            {
                throw new AccountAlreadyExistsException("Storage already contains such account.");
            }
            accounts.Add(account);
        }

        public void RemoveAccount(BankAccount account)
        {
            if (!accounts.Contains(account))
            {
                throw new AccountNotExistsException("Storage doesn't contain such account");
            }
            accounts.Remove(account);
        }


        public void PutMoneyInAccount(BankAccount account, int sum)
        {
            if (!accounts.Contains(account))
            {
                throw new AccountNotExistsException("Storage doesn't contain such account");
            }

            accounts.Find(s => s == account).Put(sum);          
        }


        public void WithdrawMoneyFromAccount(BankAccount account, int sum)
        {
            if (!accounts.Contains(account))
            {
                throw new AccountNotExistsException("Storage doesn't contain such account");
            }

           accounts.Find(s => s == account).Withdraw(sum);
        }


        public IEnumerable<BankAccount> ShowAllAccounts()
        {
            SaveAccounts(accounts);         
            return accounts;
        }

        public void LoadAccountsFromFile()
        {
            var newAccounts = new List<BankAccount>();

            using (var br = new BinaryReader(File.Open(filePath, FileMode.OpenOrCreate, FileAccess.Read)))
            {
                while (br.BaseStream.Position != br.BaseStream.Length)
                {
                    var id = br.ReadInt32();
                    var firstName = br.ReadString();
                    var lastName = br.ReadString();
                    var phone = br.ReadString();
                    var sum = br.ReadInt32();
                    var points = br.ReadInt32();
                    var status = (AccountStatus)Enum.Parse(typeof(AccountStatus), br.ReadString());
                    var type = (AccountType)Enum.Parse(typeof(AccountType), br.ReadString());

                    BankAccount account = this.DefineAccount(id, firstName, lastName, phone,status,type, sum, points);
                    newAccounts.Add(account);
                }

            }
            foreach (var account in newAccounts)
            {
                accounts.Add(account);
            }
        }
        
        public void SaveAccounts(List<BankAccount> accounts)
        {
            using (var writer = new BinaryWriter(File.Open(filePath, FileMode.OpenOrCreate, FileAccess.Write)))
            {
                foreach (var account in accounts)
                {
                    writer.Write(account.id);
                    writer.Write(account.Status.ToString());
                    writer.Write(account.Type.ToString());
                    writer.Write(account.Person.FirstName);
                    writer.Write(account.Person.LastName);
                    writer.Write(account.Person.Phone);
                    writer.Write(account.Balance);
                    writer.Write(account.Bonus);
                }
            }
        }

        public BankAccount DefineAccount(int _id, string FirstName, string LastName, string phone, AccountStatus status, AccountType type, int sum, int points)
        {
            BankAccount account = null;
            switch (type)
            {
                case AccountType.Base: account = new BaseAccount(_id, new AccountHolder(FirstName, LastName, phone), status, type, sum, points); break;
                case AccountType.Gold: account = new GoldAccount(_id, new AccountHolder(FirstName, LastName, phone), status, type, sum, points); break;
                case AccountType.Premium: account = new PlatinumAccount(_id, new AccountHolder(FirstName, LastName, phone), status, type, sum, points); break;
            }
            return account;
        }

        public IEnumerator<BankAccount> GetEnumerator()
        {
            return accounts.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}






