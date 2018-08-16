using System;
using Core;
using Holders;

namespace BankAccountLib
{
    /// <summary>
    /// Base account for poor people that conatin the main functionality
    /// </summary>
    /// <seealso cref="BankAccountLib.BankAccount" />
    public sealed class BaseAccount : BankAccount
    {
        #region Constants
        const decimal MAX_LIMIT = 1000;
        const decimal MIN_LIMIT = -1000;
        const int MULTIPLIER = 3;
        #endregion

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseAccount"/> class.
        /// </summary>
        /// <param name="AccHolder">The account holder.</param>
        /// <param name="idGenerator">The identifier generator.</param>
        public BaseAccount(AccountHolder AccHolder, IAccountNumberGenerator idGenerator)
            : base(AccHolder, idGenerator){}
        #endregion

        #region Overridden methods
        protected override void CountBonusPoints(decimal value)
            => bonusPoints = (balance < 0) ? 0 :
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
