using System;
using System.Collections.Generic;
using BankAccountLib;

namespace Repository
{
    public class AccountManager: IRepository<BankAccount>
    {
        /// <summary>
        /// List of accounts
        /// </summary>
        private List<BankAccount> accounts;

        #region Public API

        /// <summary>
        /// Creates list of accounts.
        /// </summary>
        public void Create()
        {
            accounts = new List<BankAccount>();
        }

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
        public BankAccount GetByID(string id)
        {
            if (accounts == null)
            {
                throw new ArgumentNullException("Account database is not created yet");
            }

            if (id == string.Empty)
            {
                throw new ArgumentNullException("Null id was sent");
            }

            if (id == string.Empty)
            {
                throw new ArgumentException("Empty id was sent");
            }

            foreach (var acc in accounts)
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
        /// <param name="acc">The acc.</param>
        /// <exception cref="System.ArgumentNullException">Null account was sent</exception>
        public void Remove(BankAccount acc)
        {
            if (acc == null)
            {
                throw new ArgumentNullException("Null account was sent");
            }

            foreach (var account in accounts)
            {
                if (acc.IdNumber == account.IdNumber)
                {
                    accounts.Remove(account);
                    break;
                }
            }
        }

        /// <summary>
        /// Saves the specified acc.
        /// </summary>
        /// <param name="acc">The acc.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Null account was sent
        /// or
        /// Account with such id is already exists, try another one
        /// </exception>
        public void Save(BankAccount acc)
        {
            if (acc == null)
            {
                throw new ArgumentNullException("Null account was sent");
            }

            foreach (var account in accounts)
            {
                if (acc.IdNumber == account.IdNumber)
                {
                    throw new ArgumentException("Account with such id is already exists, try another one");
                }
            }

            accounts.Add(acc);
        }
        #endregion
    }
}
