using Core;
using System;
using Holders;

namespace BankAccountLib
{
    /// <summary>
    /// Gold account with inherited functionality from Base Account
    /// </summary>
    /// <seealso cref="BankAccountLib.BankAccount" />
    public sealed class GoldAccount : BankAccount
    {
        #region Constants
        const decimal MAX_LIMIT = 5000000;
        const decimal MIN_LIMIT = -10000;
        const int MULTIPLIER = 10;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="GoldAccount"/> class.
        /// </summary>
        /// <param name="AccHolder">The acc holder.</param>
        /// <param name="idGenerator">The identifier generator.</param>
        public GoldAccount(AccountHolder AccHolder, IAccountNumberGenerator idGenerator) : base(AccHolder, idGenerator) { }

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
