using System;
using NUnit.Framework;
using CustomerLib;

namespace CustomerLibTest
{
    [TestFixture]
    public class CustomerTests
    {
        [TestCase("G", ExpectedResult = "Roman Nekliukov, 1000000, +375(44)532-60-52")]
        [TestCase("N", ExpectedResult = "Roman Nekliukov")]
        [TestCase("C", ExpectedResult = "+375(44)532-60-52")]
        [TestCase("NC", ExpectedResult = "Roman Nekliukov, +375(44)532-60-52")]
        [TestCase("NR", ExpectedResult = "Roman Nekliukov, 1000000")]
        [TestCase("", ExpectedResult = "Roman Nekliukov, 1000000, +375(44)532-60-52")]
        [TestCase(null, ExpectedResult = "Roman Nekliukov, 1000000, +375(44)532-60-52")]
        public string TestToStringCustomer(string format)
        {
            Customer cust = new Customer("Roman Nekliukov", 1000000, "+375(44)532-60-52");
            return cust.ToString(format, null);
        }

        [TestCase("", 1000000, "+375445326052")]
        [TestCase("Roman Nekliukov", 1000000, "@375(44)532 - 60 - 52")]
        [TestCase("Roman Nekliukov", 1000000, "one tow three")]
        [TestCase("Roman Nekliukov", -4, " + 375445326052")]
        public void ThrowArgumentException(string name, decimal revenue, string number)
        {
            Assert.Throws<ArgumentException>(()=> new Customer(name, revenue, number));
        }

        [TestCase(null, 1000000, "+375445326052")]
        [TestCase("Roman Nekliukov", 1000000, null)]
        public void ThrowArgumentNullException(string name, decimal revenue, string number)
        {
            Assert.Throws<ArgumentNullException>(() => new Customer(name, revenue, number));
        }
    }
}
