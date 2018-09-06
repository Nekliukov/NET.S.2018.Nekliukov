using System;
using BLL.Interface.Interfaces;
using BLL.Interface.Entities;
using DAL.Fake;

namespace BLL.ServiceImplementation
{
    public class Service: IService
    {
        #region IService Implementation
     
        void IService.CloseAccount(string accountId) => CloseAccount(accountId);

        void IService.Deposit(string accountId, decimal value) => Deposit(accountId, value);

        void IService.Withdraw(string accountId, decimal value) => Withdraw(accountId, value);

        string IService.OpenAccount(IAccountNumberGenerator generator, AccountHolder holder, string accountType)
            => OpenAccount(generator, holder, accountType);

        string IService.Status(string accountId) => Status(accountId);

        #endregion

        #region Public API

        /// <summary>
        /// Opens the account.
        /// </summary>
        /// <param name="generator">The generator.</param>
        /// <param name="holder">The holder.</param>
        /// <param name="accountType">Type of the account.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Null argument was sent</exception>
        /// <exception cref="System.ArgumentException">No such account type exists</exception>
        public static string OpenAccount(IAccountNumberGenerator generator, AccountHolder holder, string accountType)
        {
            if (generator == null || holder == null || accountType == null)
            {
                throw new ArgumentNullException("Null argument was sent");
            }

            BankAccount newAccount;
            switch (accountType.ToLower())
            {
                case "base":
                {
                    Repository.Create(newAccount = new BaseAccount(holder, generator));
                    break;
                }
                case "silver":
                {
                    Repository.Create(newAccount = new SilverAccount(holder, generator));
                    break;
                }
                case "gold":
                {
                    Repository.Create(newAccount = new GoldAccount(holder, generator));
                    break;
                }
                default:
                {
                    throw new ArgumentException(nameof(accountType) + " is not defined");
                }
            }

            return newAccount.IdNumber;
        }

        /// <summary>
        /// Closes the account.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <exception cref="System.ArgumentNullException">accountId</exception>
        /// <exception cref="System.ArgumentException">accountId</exception>
        public static void CloseAccount(string accountId)
        {
            if (accountId == null)
            {
                throw new ArgumentNullException(nameof(accountId));
            }

            if (accountId == string.Empty)
            {
                throw new ArgumentException(nameof(accountId));
            }

            Repository.Delete(accountId);
        }

        /// <summary>
        /// Deposits some money from the specidied account.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <param name="value">The value.</param>
        public static void Deposit(string accountId, decimal value) => Repository.GetById(accountId).Deposit(value);

        /// <summary>
        /// Withdraws some money from the specidied account.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <param name="value">The value.</param>
        public static void Withdraw(string accountId, decimal value) => Repository.GetById(accountId).Withdraw(value);

        /// <summary>
        /// Gets the information about account
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <returns>Info</returns>
        public static string Status(string accountId) => Repository.GetById(accountId).ToString();

        #endregion
    }
}
