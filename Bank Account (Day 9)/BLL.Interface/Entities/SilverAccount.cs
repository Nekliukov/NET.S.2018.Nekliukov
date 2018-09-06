using System;
using BLL.Interface.Interfaces;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Silver account with inherited functionality from Base Account
    /// </summary>
    /// <seealso cref="BankAccountLib.BankAccount" />
    public sealed class SilverAccount : BankAccount
    {
        #region Constants
        const decimal MAX_LIMIT = 100000;
        const decimal MIN_LIMIT = -5000;
        const int MULTIPLIER = 5;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="SilverAccount"/> class.
        /// </summary>
        /// <param name="AccHolder">The acc holder.</param>
        /// <param name="idGenerator">The identifier generator.</param>
        public SilverAccount(AccountHolder AccHolder, IAccountNumberGenerator idGenerator)
            : base(AccHolder, idGenerator) { }

        #region Overridden methods
        protected override void CountBonusPoints(decimal value)
            =>
            bonusPoints = (balance < 0) ? 0 :
            (bonusPoints + ((value / 100 > 1) ? (int)(MULTIPLIER * value / 100) : MULTIPLIER));

        protected override void ValidateWithdraw(decimal value)
        {
            if (balance - value < MIN_LIMIT)
            {
                throw new ArgumentException($"The deposit {value} is too large, limit bottom balance value is {MIN_LIMIT}");
            }
        }

        protected override void ValidateDeposit(decimal value)
        {
            if (value + balance > MAX_LIMIT)
            {
                throw new ArgumentException($"The deposit {value} is too large, limit balance value is {MAX_LIMIT}");
            }
        }

        #endregion
    }
}
