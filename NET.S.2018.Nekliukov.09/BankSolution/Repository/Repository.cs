using System;
using System.Collections.Generic;
using BankAccountLib;

namespace BankRepository
{
    public class Repository: IRepository
    {
        /// <summary>
        /// List of accounts
        /// </summary>
        private static Lazy<List<BankAccount>> accounts = new Lazy<List<BankAccount>>();

        #region IRepository implementation

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <returns></returns>
        BankAccount IRepository.GetById(string accountId) => GetById(accountId);

        /// <summary>
        /// Creates the specified account.
        /// </summary>
        /// <param name="acc">The account.</param>
        void IRepository.Create(BankAccount acc) => Create(acc);

        /// <summary>
        /// Deletes the specified account.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        void IRepository.Delete(string accountId) => Delete(accountId);

        #endregion

        #region Public static API

        /// <summary>
        /// Add new account to accounts list
        /// </summary>
        public static void Create(BankAccount newAccount) => accounts.Value.Add(newAccount);

        //public void Update(BankAccount editedAccount)
        //{
        //    foreach (var acc in accounts)
        //    {
        //        if (acc.IdNumber == editedAccount.IdNumber)
        //        {
        //            acc.Balance = editedAccount.Balance;
        //        }
        //    }
        //}

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">
        /// Account database is not created yet or
        /// Null is was sent
        /// </exception>
        /// <exception cref="System.ArgumentException">Empty id was sent</exception>
        public static BankAccount GetById(string id)
        {
            if (accounts.Value.Count == 0)
            {
                throw new ArgumentException("Account database is empty");
            }

            if (id == string.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (id == string.Empty)
            {
                throw new ArgumentException("Empty id was sent");
            }

            foreach (var acc in accounts.Value)
            {
                if (acc.IdNumber == id)
                {
                    return acc;
                }
            }

            return null;
        }

        /// <summary>
        /// Removes the specified acc.
        /// </summary>
        /// <param name="id">The acc.</param>
        /// <exception cref="System.ArgumentNullException">Null account was sent</exception>
        public static void Delete(string id)
        {
            BankAccount account = GetById(id);
            foreach (var acc in accounts.Value)
            {
                if (account.IdNumber == acc.IdNumber)
                {
                    accounts.Value.Remove(account);
                    break;
                }
            }
        }

        /// <summary>
        /// Saves the specified acc.
        /// </summary>
        /// <param name="account">The acc.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Null account was sent
        /// or
        /// Account with such id is already exists, try another one
        /// </exception>
        public static void Save(BankAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            foreach (var acc in accounts.Value)
            {
                if (account.IdNumber == acc.IdNumber)
                {
                    throw new ArgumentException("Account with such id is already exists, try another one");
                }
            }

            accounts.Value.Add(account);
        }

        #endregion
    }
}
