using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccountLib;
using Core;
using Repository;

namespace BankTest
{
    class Program
    {
        static void Main(string[] args)
        {
            AccountManager manager = new AccountManager();
            manager.Create();
 
            AccountHolder holder1 = new AccountHolder("Roman", "Nekliukov", "roman.nekliukov@gmail.com");
            BaseAccount acc1 = new BaseAccount(holder1, new IbanStandart());
            manager.Save(acc1);
            AccountHolder holder2 = new AccountHolder("Valera", "Nekliukov", "valera.nekliukov@gmail.com");
            SilverAccount acc2 = new SilverAccount(holder2, new BicStandart());
            manager.Save(acc2);
            AccountHolder holder3 = new AccountHolder("Tatsiana", "Nekliukova", "tannek@gmail.com");
            GoldAccount acc3 = new GoldAccount(holder3, new BicStandart());
            manager.Save(acc3);

            try
            {
                manager.Save(acc2);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Account with such id is already exists");
            }

            manager.Remove(manager.GetByID(acc2.IdNumber));
            if (manager.GetByID(acc2.IdNumber) == null)
            {         
                Console.WriteLine("There is no such accunt");
            }

            acc1.Deposit(600);
            acc1.Withdraw(300);
            Console.WriteLine("My current balance: " + manager.GetByID(acc1.IdNumber).Balance);

            Console.WriteLine("==============Account info===============");
            Console.Write($"Username = {acc1.Holder.FirstName} {acc1.Holder.SecondName}\n" +
                $"Email = {acc1.Holder.Email}\nID = {acc1.IdNumber}\n" +
                $"Balance = {acc1.Balance}\nBonus point = {acc1.BonusPoints}\n");

            Console.WriteLine("==============Account info===============");
            Console.Write($"Username = {acc3.Holder.FirstName} {acc3.Holder.SecondName}\n" +
                $"Email = {acc3.Holder.Email}\nID = {acc3.IdNumber}\n" +
                $"Balance = {acc3.Balance}\nBonus point = {acc3.BonusPoints}");
            Console.ReadLine();
        }
    }
}
