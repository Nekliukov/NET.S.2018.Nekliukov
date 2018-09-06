using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    public interface IService
    {
        string OpenAccount(IAccountNumberGenerator generator, AccountHolder holder, string accountType);
        void CloseAccount(string accountId);
        void Deposit(string accountId, decimal value);
        void Withdraw(string accountId, decimal value);
        string Status(string accountId);
    }
}
