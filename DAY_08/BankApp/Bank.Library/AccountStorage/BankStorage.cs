using Bank.Library.Account;
using Bank.Library.AccountTypes;
using Bank.Library.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Bank.Library.AccountStorage
{
    /// <summary>
    /// Class represents a storage for bank accounts.
    /// </summary>
    class BankStorage : IStorage, IEnumerable<BankAccount>
    {
        /// <summary>
        /// Storage for bank accounts.
        /// </summary>
        private List<BankAccount> accounts;

        /// <summary>
        /// Path to the binary file in the local PC.
        /// </summary>
        private readonly string filePath = AppDomain.CurrentDomain.BaseDirectory + "BankClients.dat";

        /// <summary>
        /// Constructor of the bank storage wich automatically downloads available accounts to the App.
        /// </summary>
        public BankStorage()
        {
            accounts = new List<BankAccount>();
            if (File.Exists(filePath))
            {
                LoadAccountsFromFile();
            }
        }

        /// <summary>
        /// Returns instance of bank account.
        /// </summary>
        /// <param name="id">Bank account Id.</param>
        /// <returns>bank account instance.</returns>
        public BankAccount FindAccount(int id)
        {
            if (File.Exists(filePath))
            {
                accounts.Clear();
                LoadAccountsFromFile();
            }
            if (accounts.Find(a => a.id == id) is null)
                throw new AccountNotExistsException($"Storage has't got account with id = {id}.");
            return accounts.Find(a => a.id == id);
        }

        /// <summary>
        /// Add bank account to the storage.
        /// </summary>
        /// <param name="account">Bank account which should be added to the storage.</param>
        public void AddAccount(BankAccount account)
        {
            //ID should not go into check!
            if (accounts.Contains(account))
            {
                throw new AccountAlreadyExistsException("Storage already contains such account.");
            }
            accounts.Add(account);
        }

        /// <summary>
        /// Remove bank account from the storage.
        /// </summary>
        /// <param name="account">Bank account which should be removed from the storage.</param>
        public void RemoveAccount(BankAccount account)
        {
            if (!accounts.Contains(account))
            {
                throw new AccountNotExistsException("Storage doesn't contain such account");
            }
            accounts.Remove(account);
        }

        /// <summary>
        /// Put money to the appropriate bank account.
        /// </summary>
        /// <param name="account">Bank account to which account money should be added.</param>
        /// <param name="sum">Amount of money to be added.</param>
        public void PutMoneyInAccount(BankAccount account, int sum)
        {
            if (!accounts.Contains(account))
            {
                throw new AccountNotExistsException("Storage doesn't contain such account");
            }
            accounts.Find(s => s == account).Put(sum);
        }

        /// <summary>
        /// Withdraw money from the appropriate bank account.
        /// </summary>
        /// <param name="account">Bank account from which account money should be withdrawed.</param>
        /// <param name="sum">Amount of money to be withdrawed.</param>
        public void WithdrawMoneyFromAccount(BankAccount account, int sum)
        {
            if (!accounts.Contains(account))
            {
                throw new AccountNotExistsException("Storage doesn't contain such account");
            }
            accounts.Find(s => s == account).Withdraw(sum);
        }

        /// <summary>
        /// Represents all available bank accounts in the storage by automatically saving to a local file and loading into the App.
        /// </summary>
        /// <returns>Available accounts.</returns>
        public IEnumerable<BankAccount> ShowAllAccounts()
        {
            SaveAccounts(accounts);
            return accounts;
        }

        /// <summary>
        /// Load bank accounts from the local file to the storage.
        /// </summary>
        public void LoadAccountsFromFile()
        {
            var newAccounts = new List<BankAccount>();
            using (var br = new BinaryReader(File.Open(filePath, FileMode.Open, FileAccess.Read)))
            {
                while (br.BaseStream.Position != br.BaseStream.Length)
                {
                    var id = br.ReadInt32();
                    var firstName = br.ReadString();
                    var lastName = br.ReadString();
                    var phone = br.ReadString();
                    var status = (AccountStatus)Enum.Parse(typeof(AccountStatus), br.ReadString());
                    var type = (AccountType)Enum.Parse(typeof(AccountType), br.ReadString());
                    var sum = br.ReadInt32();
                    var points = br.ReadInt32();

                    BankAccount account = this.DefineAccount(id, firstName, lastName, phone, status, type, sum, points);
                    newAccounts.Add(account);
                }
            }
            foreach (var account in newAccounts)
            {
                accounts.Add(account);
            }
        }

        /// <summary>
        /// Save bank accounts to the local file from the storage.
        /// </summary>
        /// <param name="accounts"></param>
        public void SaveAccounts(List<BankAccount> accounts)
        {
            using (var writer = new BinaryWriter(File.Open(filePath, FileMode.Create, FileAccess.Write)))
            {
                foreach (var account in accounts)
                {
                    writer.Write(account.id);
                    writer.Write(account.Person.FirstName);
                    writer.Write(account.Person.LastName);
                    writer.Write(account.Person.Phone);
                    writer.Write(account.Status.ToString());
                    writer.Write(account.Type.ToString());
                    writer.Write(account.Balance);
                    writer.Write(account.Bonus);
                }
            }
        }

        /// <summary>
        /// Determines the type of account for its creation.
        /// </summary>
        /// <param name="_id">Bank account's id.</param>
        /// <param name="firstName">Bank account's first name.</param>
        /// <param name="lastName">Bank account's last name.</param>
        /// <param name="phone">Bank account's phone number.</param>
        /// <param name="status">Bank account's status.</param>
        /// <param name="type">Bank account's type.</param>
        /// <param name="sum">Bank account's first added sum.</param>
        /// <param name="points">Bank account's first added points.</param>
        /// <returns>Bank account instance.</returns>
        internal BankAccount DefineAccount(int _id, string firstName, string lastName, string phone, AccountStatus status, AccountType type, int sum, int points)
        {
            BankAccount account = null;
            switch (type)
            {
                case AccountType.Base: account = new BaseAccount(_id, new AccountHolder(firstName, lastName, phone), status, type, sum, points); break;
                case AccountType.Gold: account = new GoldAccount(_id, new AccountHolder(firstName, lastName, phone), status, type, sum, points); break;
                case AccountType.Premium: account = new PlatinumAccount(_id, new AccountHolder(firstName, lastName, phone), status, type, sum, points); break;
            }
            return account;
        }

        /// <summary>
        /// Count amount of accounts in storage.
        /// </summary>
        /// <returns>Amount of accounts.</returns>
        public int Count()
        {
            return accounts.Count();
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






