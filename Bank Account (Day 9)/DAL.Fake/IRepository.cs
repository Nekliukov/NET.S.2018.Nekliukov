using BLL.Interface.Entities;

namespace DAL.Fake
{
    internal interface IRepository
    {
        BankAccount GetById(string id);
        void Create(BankAccount acc);
        //void Update(BankAccount acc);
        void Delete(string accountId);
    }
}
