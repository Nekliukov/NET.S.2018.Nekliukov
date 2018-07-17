using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccountLib;
using Core;

namespace BankTest
{
    class Program
    {
        static void Main(string[] args)
        {
            AccountHolder holder = new AccountHolder("Roman", "Nekliukov", "roman.nekliukov@gmail.com");
            BankAccount holderAccount = new BankAccount(holder, new IbanStandart());
            Console.WriteLine("==============Account info===============");
            Console.Write($"Username = {holderAccount.Holder.FirstName} {holderAccount.Holder.SecondName}\n" +
                $"Email = {holderAccount.Holder.Email}\nID = {holderAccount.IdNumber}\n" +
                $"Balance = {holderAccount.Balance}\nBonus point = {holderAccount.BonusPoints}");
            Console.ReadLine();
        }
    }
}
