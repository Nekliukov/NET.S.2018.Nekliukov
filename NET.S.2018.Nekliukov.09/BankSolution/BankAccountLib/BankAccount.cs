using System;
using Core;

namespace BankAccountLib
{
    /// <summary>
    /// Class for creating bank accounts. Should be abstract in the future !
    /// </summary>
    public abstract class BankAccount
    {
        #region Protected fields

        protected AccountHolder holder;
        protected string idNumber;
        protected decimal balance;
        protected int bonusPoints;

        /// <summary>
        /// The bonus multiplier
        /// </summary>
        protected int bonusMultiplier;

        /// <summary>
        /// The bottom limit of balance
        /// </summary>
        protected decimal minLimit;

        /// <summary>
        /// The maximum value of money on account
        /// </summary>
        protected decimal maxLimit;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccount"/> class.
        /// </summary>
        /// <param name="AccHolder">The account holder.</param>
        /// <param name="idGenerator">The identifier generator.</param>
        public BankAccount(AccountHolder AccHolder, IAccountNumberGenerator idGenerator)
        {
            Holder = AccHolder;
            idNumber = idGenerator.Generate();
        }

        #endregion

        #region Properties        
        /// <summary>
        /// Gets the holder.
        /// </summary>
        /// <value>
        /// The holder.
        /// </value>
        /// <exception cref="System.ArgumentNullException">Null value was sent</exception>
        public AccountHolder Holder
        {
            get => holder;
            protected set => holder = value ??
                throw new ArgumentNullException($"Null {nameof(value)} value was sent");
        }

        /// <summary>
        /// Gets unique id number.
        /// </summary>
        /// <value>
        /// The id number.
        /// </value>
        /// <exception cref="System.ArgumentNullException">Null value was sent</exception>
        public string IdNumber
        {
            get => idNumber;
            protected set => idNumber = value ??
                throw new ArgumentNullException($"Null {nameof(value)} value was sent");
        }

        /// <summary>
        /// Gets the balance.
        /// </summary>
        /// <value>
        /// The balance.
        /// </value>
        public decimal Balance { get => balance; }

        /// <summary>
        /// Gets the bonus points.
        /// </summary>
        /// <value>
        /// The bonus points.
        /// </value>
        public int BonusPoints { get => bonusPoints; }

        #endregion

        #region Protected methods



        #endregion

        #region Template methods

        protected abstract void PerformDeposit(decimal deposit);
        protected abstract void PerformWithdraw(decimal withdraw);

        #endregion
    }
}
