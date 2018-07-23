using System;
using System.Collections.Generic;
using System.Numerics;

namespace FibonacciLib
{
    /// <summary>
    /// Class for operation with Fibonacci numbers
    /// </summary>
    public static class Fibonacci
    {
        /// <summary>
        /// Generates the numbers.
        /// </summary>
        /// <param name="numOfNumbers">The number of numbers.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">
        /// Number of elements must be more than 0
        /// or
        /// Number value is too long."
        /// </exception>
        public static IEnumerable<BigInteger> GenerateNumbers(int numOfNumbers)
        {
            if (numOfNumbers <= 0)
            {
                throw new ArgumentException("Number of elements must be more than 0");
            }

            IEnumerable<BigInteger> Calculate()
            {
                BigInteger firstNum = 0, secondNum = 1, nextNum;
                while (numOfNumbers-- != 0)
                {
                    yield return firstNum;
                    nextNum = firstNum + secondNum;
                    firstNum = secondNum;
                    secondNum = nextNum;
                }
            }

            return Calculate();
        }
    }
}
