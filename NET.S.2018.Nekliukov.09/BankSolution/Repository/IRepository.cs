using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccountLib;

namespace Repository
{
    interface IRepository<T> where T: BankAccount
    {
        T GetByID(string id);
        void Create();
        void Save(T acc);
        void Remove(T acc);
    }
}
