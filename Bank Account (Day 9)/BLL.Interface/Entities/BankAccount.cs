using System;
using BLL.Interface.Interfaces;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Class for creating bank accounts.
    /// </summary>
    public abstract class BankAccount
    {
        #region Protected fields

        protected AccountHolder holder;
        protected string idNumber;
        protected decimal balance;
        protected int bonusPoints;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccount"/> class.
        /// </summary>
        /// <param name="AccHolder">The account holder.</param>
        /// <param name="idGenerator">The identifier generator.</param>
        protected BankAccount(AccountHolder AccHolder, IAccountNumberGenerator idGenerator)
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

        #region Public API methods

        /// <summary>
        /// Performs the deposit.
        /// </summary>
        /// <param name="deposit">The deposit.</param>
        /// <exception cref="System.ArgumentException">Wrong value
        /// </exception>
        /// <exception cref="System.ArgumentException">Out of the limit
        /// </exception>
        public void Deposit(decimal deposit)
        {
            if (deposit <= 0)
            {
                throw new ArgumentException($"Bank can't perform withdraw operration with value {deposit}." +
                    $" Must be grater then 0.");
            }
            ValidateDeposit(deposit);
            balance += deposit;
            CountBonusPoints(deposit);
        }

        /// <summary>
        /// Performs the withdraw.
        /// </summary>
        /// <param name="withdraw">The withdraw.</param>
        /// <exception cref="System.ArgumentException">Wrong value
        /// </exception>
        /// <exception cref="System.ArgumentException">Out of the limit
        /// </exception>
        public void Withdraw(decimal withdraw)
        {
            if (withdraw <= 0)
            {
                throw new ArgumentException($"Bank can't perform withdraw operration with value {withdraw}." +
                    $" Must be grater then 0.");
            }

            ValidateWithdraw(withdraw);
            balance -= withdraw;
            CountBonusPoints(withdraw);
        }

        public override string ToString()
            => $"==============Account info ({this.GetType()})===============\n" +
               $"Username = {this.Holder.FirstName} {this.Holder.SecondName}\n" +
               $"Email = {this.Holder.Email}\nID = {this.IdNumber}\n" +
               $"Balance = {this.Balance}\nBonus point = {this.BonusPoints}\n";

        #endregion

        #region Template methods

        protected abstract void ValidateDeposit(decimal value);
        protected abstract void ValidateWithdraw(decimal value);
        protected abstract void CountBonusPoints(decimal value);

        #endregion
    }
}
