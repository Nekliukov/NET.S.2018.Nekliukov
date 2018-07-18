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
            BaseAccount @base = new BaseAccount(holder, new IbanStandart());
            SilverAccount @silver = new SilverAccount(holder, new BicStandart());
            @base.Deposit(100);
            @base.Deposit(130);
            @base.Withdraw(1000);
            @base.Deposit(1300);
            @silver.Deposit(1000);
            @silver.Deposit(1300);
            @silver.Withdraw(100000);
            @silver.Deposit(13000);
            Console.WriteLine("==============Account info===============");
            Console.Write($"Username = {@base.Holder.FirstName} {@base.Holder.SecondName}\n" +
                $"Email = {@base.Holder.Email}\nID = {@base.IdNumber}\n" +
                $"Balance = {@base.Balance}\nBonus point = {@base.BonusPoints}\n");

            Console.WriteLine("==============Account info===============");
            Console.Write($"Username = {@silver.Holder.FirstName} {@silver.Holder.SecondName}\n" +
                $"Email = {@silver.Holder.Email}\nID = {@silver.IdNumber}\n" +
                $"Balance = {@silver.Balance}\nBonus point = {@silver.BonusPoints}");
            Console.ReadLine();
        }
    }
}
