using System;
using Core;

namespace BankAccountLib
{
    /// <summary>
    /// Base account for poor people that conatin the main functionality
    /// </summary>
    /// <seealso cref="BankAccountLib.BankAccount" />
    public class BaseAccount : BankAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseAccount"/> class.
        /// </summary>
        /// <param name="AccHolder">The account holder.</param>
        /// <param name="idGenerator">The identifier generator.</param>
        public BaseAccount(AccountHolder AccHolder, IAccountNumberGenerator idGenerator) : base(AccHolder, idGenerator)
        {
            Holder = AccHolder;
            idNumber = idGenerator.Generate();
            maxLimit = 1000;
            minLimit = -1000;
            bonusMultiplier = 3;
        }

        #region Public API

        /// <summary>
        /// Deposits some value from an account, calls the overriden template method
        /// </summary>
        /// <param name="deposit">The deposit.</param>
        public void Deposit(decimal deposit) => PerformDeposit(deposit);

        /// <summary>
        /// Withdraw some value from an account, calls the overriden template method
        /// </summary>
        /// <param name="deposit">The deposit.</param>
        public void Withdraw(decimal withdraw) => PerformWithdraw(withdraw);

        #endregion

        #region Overridden methods

        /// <summary>
        /// Performs the deposit.
        /// </summary>
        /// <param name="deposit">The deposit.</param>
        /// <exception cref="System.ArgumentException">Wrong value
        /// </exception>
        /// <exception cref="System.ArgumentException">Out of the limit
        /// </exception>
        protected override void PerformDeposit(decimal deposit)
        {
            if (deposit <= 0)
            {
                throw new ArgumentException($"Bank cannot perform your depoist with value {deposit}");
            }

            if (deposit + balance > maxLimit)
            {
                throw new ArgumentException($"The deposit {deposit} is too large, limit balance value is {maxLimit}");
            }

            balance += deposit;
            bonusPoints += (deposit / 100 > 1)?(int)(bonusMultiplier * deposit / 100):bonusMultiplier;
        }

        /// <summary>
        /// Performs the deposit.
        /// </summary>
        /// <param name="deposit">The deposit.</param>
        /// <exception cref="System.ArgumentException">Wrong value
        /// </exception>
        /// <exception cref="System.ArgumentException">Out of the limit
        /// </exception>
        protected override void PerformWithdraw(decimal withdraw)
        {
            if (withdraw <= 0)
            {
                throw new ArgumentException($"Bank cannot perform your depoist with value {withdraw}");
            }

            if (balance - withdraw < minLimit)
            {
                throw new ArgumentException($"The deposit {withdraw} is too large, limit bottom balance value is {minLimit}");
            }

            balance -= withdraw;
            bonusPoints = (balance < 0) ? 0: bonusPoints;
        }

        #endregion
    }
}
