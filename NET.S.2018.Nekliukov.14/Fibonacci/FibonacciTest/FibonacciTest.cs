using System;
using NUnit.Framework;
using FibonacciLib;

namespace FibonacciLibTest
{
    [TestFixture]
    public class FibonacciTest
    {
        [TestCase(1, ExpectedResult = new long[] { 0 })]
        [TestCase(2, ExpectedResult = new long[] { 0, 1 })]
        [TestCase(5, ExpectedResult = new long[] { 0, 1, 1, 2, 3 })]
        [TestCase(23, ExpectedResult = new long[] { 0, 1, 1, 2, 3, 5, 8, 13, 21,
            34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711})]
        [TestCase(47, ExpectedResult = new long[] { 0,1,1,2,3,5,8,13,21,34,55,89,144,
            233,377,610,987,1597,2584,4181,6765,10946,17711,28657,46368,75025,121393,196418,317811,
            514229,832040,1346269,2178309,3524578,5702887,9227465,14930352,24157817,39088169,
            63245986,102334155,165580141,267914296,433494437,701408733,1134903170, 1836311903 })]
        public long[] NumbersGeneratingTest(int num) => Fibonacci.GenerateNumbers(num);

        [TestCase(-2)]
        [TestCase(0)]
        [TestCase(48)]
        public void NumbersGeneratingArgumentException(int num)
            => Assert.Throws<ArgumentException>(() => Fibonacci.GenerateNumbers(num));
    }


}
