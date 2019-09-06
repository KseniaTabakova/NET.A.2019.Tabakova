using Bank.Library.Account;
using Bank.Library.AccountСapability;
using Bank.Library.Exceptions;
using Bank.Library.Helpers;
using Bank.Library.Service;
using System;

namespace Bank.Library.AccountTypes
{
    public abstract class BankAccount : IBonusCalculator
    {
       
        internal int id;
        private int bonus;
        private int balance;

               public AccountHolder Person { get; protected set; }
        public int Bonus { get; protected set; } = 0;
        public AccountStatus Status { get; internal set; }
        public AccountType Type { get; protected set; }
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

        protected BankAccount(int id, AccountHolder person, AccountStatus status, AccountType type, int sum, int bonus)
        {
            this.id = id;
            Person = person;
            Balance = sum;
            Status = status;
            Type = type;
            Bonus = bonus;
        }


        public abstract int CalculateBonus(AccountType type);
        protected abstract bool BalanceIsPositive(int value);

        internal virtual void Put(int value)
        {
            if (Validator.SumIsValid(value))
            {
                bonus += CalculateBonus(Type);
                balance += value;
            }
        }

        internal virtual void Withdraw(int value)
        {
            if (Validator.WithdrawIsValid(value, balance))
            {
                if (balance >= bonus)
                    bonus -= CalculateBonus(Type);
                balance -= value;
            }
        }

        
    }
}
