using System;
using BLL.IdGenStandarts;
using BLL.Interface.Entities;
using BLL.ServiceImplementation;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AccountHolder romanHolder = new AccountHolder("Roman", "Nekliukov", "nekroman36@gmail.com");
            string romanId = Service.OpenAccount(new IbanStandart(), romanHolder, "Gold");
            Service.Deposit(romanId, 600);
            Service.Deposit(romanId, 10000);
            Service.Withdraw(romanId, 9000);
            Console.WriteLine(Service.Status(romanId));
        }
    }
}
