using System;
using BankAccountLib;
using Holders;

namespace BankService
{
    internal interface IService
    {
        string OpenAccount(Core.IAccountNumberGenerator generator, AccountHolder holder, string accountType);
        void CloseAccount(string accountId);
        void Deposit(string accountId, decimal value);
        void Withdraw(string accountId, decimal value);
        string Status(string accountId);
    }
}
