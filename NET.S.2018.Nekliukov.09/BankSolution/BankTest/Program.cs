using System;
using Core;
using BankService;
using Holders;

namespace BankTest
{
    class Program
    {
        static void Main(string[] args)
        {
            AccountHolder romanHolder = new AccountHolder("Roman", "Nekliukov", "nekroman36@gmail.com");
            string romanId = Service.OpenAccount(new IbanStandart(), romanHolder, "Gold");
            Service.Deposit(romanId, 600);
            Service.Deposit(romanId, 700);
            Service.Withdraw(romanId, 10000);
            Console.WriteLine(Service.Status(romanId));           
        }
    }
}
