using Bank.Library.Account;
using Bank.Library.AccountСapability;
using Bank.Library.Exceptions;
using Bank.Library.Helpers;
using System;

namespace Bank.Library.AccountTypes
{
    /// <summary>
    /// Class represents the common functionality for all types of bank account.
    /// </summary>
    public abstract class BankAccount : IBonusCalculator
    {
        public readonly int id;
        private int bonus;
        private int balance;

        /// <summary>
        /// Encapsulation of Bank account Account holder.
        /// </summary>
        public AccountHolder Person { get; internal set; }

        /// <summary>
        /// Encapsulation of Bank account status of account.
        /// </summary>
        public AccountStatus Status { get; internal set; }

        /// <summary>
        /// Encapsulation of Bank account type.
        /// </summary>
        public AccountType Type { get; internal set; }

        /// <summary>
        /// Encapsulation of Bank account balance with validation.
        /// </summary>
        public int Balance
        {
            get
            {
                return balance;
            }
            set
            {
                if (!Validator.SumIsValid(value))
                {
                    throw new NegativeSumException($"Balance can not be negative.");
                }
                balance = value;
            }
        }

        /// <summary>
        /// Encapsulation of Bank account given bonuses with validation.
        /// </summary>
        public int Bonus
        {
            get
            {
                return bonus;
            }
            set
            {
                if (value != 0)
                    Console.WriteLine("First given bonuses must be zero.");
                bonus = value;
            }
        }

        /// <summary>
        /// Parametrized constructor.
        /// </summary>
        /// <param name="id">Account given id.</param>
        /// <param name="person">Account holder.</param>
        /// <param name="status">Account status.</param>
        /// <param name="type">Account type.</param>
        /// <param name="sum">Account first balance.</param>
        /// <param name="bonus">Account first given bonuses.</param>
        protected BankAccount(int id, AccountHolder person, AccountStatus status, AccountType type, int sum, int bonus)
        {
            this.id = id;
            Person = person;
            Balance = sum;
            Status = status;
            Type = type;
            Bonus = bonus;
        }

        /// <summary>
        /// Put money to the appropriate bank account.
        /// </summary>
        /// <param name="sum">Sum to be put.</param>
        internal virtual void Put(int sum)
        {
            if (Validator.SumIsValid(sum))
            {
                Bonus += CalculateBonus(Type);
                Balance += sum;
            }
            else
                throw new NegativeSumException($"You can not put negative amount of money.");
        }

        /// <summary>
        /// Withdraw money from the appropriate bank account.
        /// </summary>
        /// <param name="sum">Sum to be withdrawed.</param>
        internal virtual void Withdraw(int sum)
        {
            if (Validator.WithdrawIsValid(sum))
            {
                if (BalanceIsPositive(balance - sum))
                {
                    Bonus -= CalculateBonus(Type);
                    Balance -= sum;
                }
                else
                    throw new InvalidWithdrawSumException($"You account balance is negative.");
            }
            else
                throw new NegativeSumException($"You can not withdraw negative amount of money and withdraw more than 10000.");
        }

        /// <summary>
        /// Calculation of bonuses depending on the type of account.
        /// </summary>
        /// <param name="type">Type of account.</param>
        /// <returns>Bonuses.</returns>
        public abstract int CalculateBonus(AccountType type);

        /// <summary>
        /// Account balance at which you can withdraw money depending on the type of account.
        /// </summary>
        /// <param name="totalAmount">Amount of money witch account have.</param>
        /// <returns>True if the operation is allowed.</returns>
        public abstract bool BalanceIsPositive(int totalAmount);

        /// <summary>
        /// Overrided representation of bank account.
        /// </summary>
        /// <returns>Account representation.</returns>
        public override string ToString()
        {
            return $"Account №{this.id}" +
                $"\nOwner: {this.Person.FirstName} {this.Person.LastName} " +
                $"\nAmount: {this.Balance}  Bonus:{this.Bonus}" +
                $"\nStatus: {this.Status}  Type: {this.Type}";            
        }
    }
}
