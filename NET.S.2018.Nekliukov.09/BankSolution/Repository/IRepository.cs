using BankAccountLib;

namespace BankRepository
{
    internal interface IRepository
    {
        BankAccount GetById(string id);
        void Create(BankAccount acc);
        //void Update(BankAccount acc);
        void Delete(string accountId);
    }
}
