using System;
using System.Collections.Generic;

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
        public static long[] GenerateNumbers(int numOfNumbers)
        {
            if (numOfNumbers <= 0)
            {
                throw new ArgumentException("Number of elements must be more than 0");
            }

            List<long> numbers = new List<long>(numOfNumbers);
            int firstNum = 0, secondNum = 1, nextNum;
            numbers.Add(firstNum); numbers.Add(secondNum);
            while (numbers.Count < numOfNumbers)
            {
                try
                {
                    nextNum = checked(firstNum + secondNum);
                }
                catch (OverflowException)
                {
                    throw new ArgumentException("Number value is too long. Max limit is " +
                        $"{numbers.Count - 1}");
                }
                numbers.Add(nextNum);
                firstNum = secondNum;
                secondNum = nextNum;
            }

            return (numOfNumbers < 2)?numbers.GetRange(0,1).ToArray():numbers.ToArray();
        }
    }
}
