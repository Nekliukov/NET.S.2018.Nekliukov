using System;
using NUnit.Framework;

namespace StringExtLib.Test
{
    [TestFixture]
    public class StringExtensionTests
    {
        [TestCase("1111111111111111111111111111111", 2, ExpectedResult = int.MaxValue)]
        [TestCase("1111111111111111111111111111110", 2, ExpectedResult = int.MaxValue - 1)]
        [TestCase("0000000000000000000000000000000", 2, ExpectedResult = 0)]
        [TestCase("0110111101100001100001010111111", 2, ExpectedResult = 934331071)]
        [TestCase("01101111011001100001010111111", 2, ExpectedResult = 233620159)]
        [TestCase("11101101111011001100001010", 2, ExpectedResult = 62370570)]
        [TestCase("764241", 8, ExpectedResult = 256161)]
        [TestCase("122423", 10, ExpectedResult = 122423)]
        [TestCase("Abbc45", 16, ExpectedResult = 11254853)]
        [TestCase("7FFFFFFF", 16, ExpectedResult = Int32.MaxValue)]
        public int Convert(string number, byte numberBase) => number.ConvertToBase10(numberBase);

        [TestCase("101013", 2)]
        [TestCase("106", 5)]
        [TestCase("-556634", 7)]
        [TestCase("Abbc45", 7)]
        [TestCase("FFFG", 16)]
        [TestCase("1000101", 18)]
        [TestCase("1000101", 1)]
        public void Throw_ArgumentException(string number, byte numberBase) =>
            Assert.Throws<ArgumentException>(() =>number.ConvertToBase10(numberBase));

        [TestCase("11111111111111111111111111111111", 2)]
        [TestCase("8FFFFFFF", 16)]
        public void Throw_OverflowException(string number, byte numberBase) =>
            Assert.Throws<OverflowException>(() => number.ConvertToBase10(numberBase));
    }
}
