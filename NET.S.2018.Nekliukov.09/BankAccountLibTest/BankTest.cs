using NUnit.Framework;
using BankAccountLib;
using System;

namespace BankAccountLibTest
{
    [TestFixture]
    public class BankTest
    {
        [TestCase("Gold", "Roman Nekliukov", "1234")]
        [TestCase("Silver", "Alexandr Shaduro", "0000")]
        [TestCase("Platinum", "Valera Chadovich", "1998")]
        public void BankTest_AccountCreating(string cardType, string userName, string userPin, decimal balance = 0)
        {
            CardHolder holder = new CardHolder(cardType, userName, userPin);
            BankOperations bo = new BankOperations();
            bo.MakeDeposit(holder, userPin, 100);
            bo.MakeDeposit(holder, userPin, 44);
            bo.MakeWithdraw(holder, userPin, 100);
            bo.MakeWithdraw(holder, userPin, 44);
            holder.ToString();
            bo.MakeDeposit(holder, userPin, 225);
            holder.ToString();
        }

        [TestCase("Gold", "Roma$n Nekliukov", "1234")]
        [TestCase("Gold", "Roma$n Nekliukov", "1a34")]
        [TestCase("Gold", "Roman Nekliukov", "12343")]
        [TestCase("Gold", "Roman Nekliukovvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv", "12343")]
        [TestCase("Wooden", "Roman Nekliukov", "1234")]
        [TestCase("Gold", "Roman Nekliukov", "")]
        [TestCase("Gold", "", "1234")]
        [TestCase("", "Roman Nekliukov", "1234")]
        public void BankTest_ArgumentExceptionCreating(string cardType, string userName, string userPin, decimal balance = 0)
        {
            Assert.Throws<ArgumentException>(() => new CardHolder(cardType, userName, userPin));
        }

        [TestCase(null, "Roman Nekliukov", "1234")]
        [TestCase("Gold", null, "1234")]
        [TestCase("Gold", "Roman Nekliukov", null)]      
        public void BankTest_ArgumentNullExceptionCreating(string cardType, string userName, string userPin, decimal balance = 0)
        {
            Assert.Throws<ArgumentNullException>(() => new CardHolder(cardType, userName, userPin));
        }

        [TestCase("Gold", "Roman Nekliukov", "1234")]
        public void BankTest_ArgumentExceptionOperations(string cardType, string userName, string userPin, decimal balance = 0)
        {
            CardHolder holder = new CardHolder(cardType, userName, userPin);
            BankOperations bo = new BankOperations();
            Assert.Throws<ArgumentException>(() => bo.MakeDeposit(holder, "1235", 100));
            Assert.Throws<ArgumentException>(() => bo.MakeDeposit(holder, "1234", -100));
            bo.MakeDeposit(holder, "1234", 200);
            Assert.Throws<ArgumentException>(() => bo.MakeWithdraw(holder, "1234", 400));
        }

        [TestCase("Gold", "Roman Nekliukov", "1234")]
        public void BankTest_ArgumentNullExceptionOperations(string cardType, string userName, string userPin, decimal balance = 0)
        {      
            CardHolder holder = new CardHolder(cardType, userName, userPin);
            BankOperations bo = new BankOperations();
            Assert.Throws<ArgumentNullException>(() => bo.MakeDeposit(null, "1234", 100));
            Assert.Throws<ArgumentNullException>(() => bo.MakeDeposit(holder, null, 100));
        }


    }
}
