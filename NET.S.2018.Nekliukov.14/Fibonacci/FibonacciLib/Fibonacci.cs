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
            List<BigInteger> numbers = new List<BigInteger>(numOfNumbers);
            BigInteger firstNum = 0, secondNum = 1, nextNum;
            numbers.Add(firstNum); numbers.Add(secondNum);
            while (numbers.Count < numOfNumbers)
            {
                nextNum = firstNum + secondNum;
                numbers.Add(nextNum);
                firstNum = secondNum;
                secondNum = nextNum;
            }

            return (numOfNumbers < 2)?numbers.GetRange(0,1):numbers;
        }
    }
}
