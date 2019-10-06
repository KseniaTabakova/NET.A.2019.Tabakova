using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Reprersents an account type that is base for other account types.
    /// </summary>
    public abstract class Account
    {
        private const int minBonusPointsCount = 0;

        /// <summary>
        /// Min allowed balance
        /// </summary>
        protected decimal minBalance = 0m;

        /// <summary>
        /// Gets or sets an account number.
        /// </summary>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets an account owner.
        /// </summary>
        public AccountOwner Owner { get; set; }

        /// <summary>
        /// Gets or sets an account balance.
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Gets or sets an account bonus points.
        /// </summary>
        public int BonusPoints { get; set; }

        /// <summary>
        /// Gets or sets account status.
        /// </summary>
        public AccountStatus Status { get; set; }

        public void Deposit(decimal value)
        {
            AssertThatAccountIsNotClosed();

            AssertThatValueIsPositive(value);

            AddToBalance(value);

            AddBonusPoints(CalculateAddedBonusPoints(value));
        }

        public void Withdraw(decimal value)
        {
            AssertThatAccountIsNotClosed();

            AssertThatValueIsPositive(value);

            RemoveFromBalance(value);

            RemoveBonusPoints(CalculateRemovedBonusPoints(value));
        }

        public override string ToString()
        {
            return $"Account number: {AccountNumber}; Owner: {Owner.FirstName} {Owner.LastName}; Balance: {Balance}; Bonus points: {BonusPoints}";
        }

        protected virtual int CalculateAddedBonusPoints(decimal depositValue)
        {
            return 0;
        }

        protected virtual int CalculateRemovedBonusPoints(decimal withdrawValue)
        {
            return 0;
        }

        private void AssertThatAccountIsNotClosed()
        {
            if (Status == AccountStatus.Closed)
            {
                throw new InvalidOperationException("Account is closed.");
            }
        }

        private void AssertThatValueIsPositive(decimal value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("Argument must be positive.", nameof(value));
            }
        }

        private void AddToBalance(decimal value)
        {
            Balance += value;
        }

        private void RemoveFromBalance(decimal value)
        {
            decimal resultBalance = Balance - value;

            if (resultBalance < minBalance)
            {
                throw new InvalidOperationException($"Balance cannot be less than {minBalance}");
            }

            Balance = resultBalance;
        }

        private void AddBonusPoints(int bonusPointsToAdd)
        {
            BonusPoints += bonusPointsToAdd;
        }

        private void RemoveBonusPoints(int bonusPointsToRemove)
        {
            int resultBonusPoints = BonusPoints - bonusPointsToRemove;

            BonusPoints = resultBonusPoints > minBonusPointsCount ? resultBonusPoints : minBonusPointsCount;
        }
    }
}
