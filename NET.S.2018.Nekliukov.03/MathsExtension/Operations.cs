using System;
using System.Diagnostics;

namespace MathsExtension
{
    public class Operations
    {
        #region public API
        /// <summary>
        /// Method for evaluating of the fractional numbers Nth degree root
        /// </summary>
        /// <param name="number">Number under root</param>
        /// <param name="degree">Root's degree</param>
        /// <param name="precision">Eps of the evaluation</param>
        /// <returns>Nth degree root</returns>
        /// <exception cref="ArgumentException">Thrown when degree is lower than 2</exception>
        /// <exception cref="ArgumentException">Thrown when precision is lower
        /// than or equal to 0</exception>
        /// <exception cref="ArgumentException">Thrown when you try to take odd
        /// degree root of negative number</exception>
        public static double FindNthRoot(double number, int degree, double precision)
        {
            if (degree < 2)
            {
                throw new ArgumentException("Degree must be positive!");
            }

            if (precision <= 0)
            {
                throw new ArgumentException("Precision must be grater than 0");
            }

            if (number < 0 && degree % 2 == 0)
            {
                throw new ArgumentException("It's impossible to take odd degree" +
                    " root of negative number ");
            }

            double res = number / 2;
            double prev = 0;
            while (Math.Abs(prev - res) >= precision)
            {
                prev = res;
                //// iteration rule of the Newton's method
                res = (1.0 / degree) * ((degree - 1) * res + number /
                    Math.Pow(res, degree - 1));
            }

            return res;
        }
        #endregion 

        /// <summary>
        /// Method for finding next positive bigeer number, that consist of the same digits
        /// </summary>
        /// <param name="number">User's number</param>
        /// <returns>Next same digits number</returns>
        /// <exception cref="ArgumentException">Thrown when number is negative</exception>
        public static int FindNextBiggerNumber(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException($"Number {nameof(number)} must be positive!");
            }

            if (number < 12)
            {
                return -1;
            }

            int[] numArray = IntToArray(number);
            int startIndex = FindStartIndex(numArray);

            //// ArrayToInt(numArray) < 0 <-- case, when integer value was oveflowed
            if (startIndex == -1 || ArrayToInt(numArray) < 0)
            {
                return -1;
            }
            else
            {
                Array.Sort(numArray, startIndex, numArray.Length - startIndex);
                return ArrayToInt(numArray);
            }           
        }

        /// <summary>
        /// Overloaded method for finding next positive bigeer number, that
        /// consist of the same digits and saving of the elapsed time
        /// </summary>
        /// <param name="number">User's number</param>
        /// <param name="watch">Object for time measuring</param>
        /// <returns>Next same digits number + elapsed time</returns>
        public static int FindNextBiggerNumber(int number, out Stopwatch watch)
        {
            watch = Stopwatch.StartNew();
            int result = FindNextBiggerNumber(number);
            watch.Stop();
            return result;
        }

        #region private API
        /// <summary>
        /// Method which helps us find the nearest possible digit position
        /// to increase the number value
        /// </summary>
        /// <param name="digits">Array of digits (number)</param>
        /// <returns>Index of digit</returns>
        private static int FindStartIndex(int[] digits)
        {
            for (int i = digits.Length - 1; i > 0; i--)
            {
                if (digits[i - 1] < digits[i])
                {
                    Swap(ref digits[i], ref digits[i - 1]);
                    return i;
                }                   
            }

            return -1;
        }

        /// <summary>
        /// Method converts integer type into array of digits
        /// </summary>
        /// <param name="number">User's number</param>
        /// <returns>Array of digits</returns>
        private static int[] IntToArray(int number)
        {
            int[] resultArr = new int[10]; // 10 - max number of digits in Int32
            int pos = 0;
            while (number != 0)
            {
                resultArr[pos++] = number % 10;
                number /= 10;
            }

            Array.Resize(ref resultArr, pos);
            Array.Reverse(resultArr);
            return resultArr;
        }

        /// <summary>
        /// Method converts array of digits into integer number
        /// </summary>
        /// <param name="numbers">User's array of digits</param>
        /// <returns>Integer value</returns>
        private static int ArrayToInt(int[] numbers)
        {
            int result = 0;
            int multipler = 1;
            for (int i = numbers.Length - 1; i >= 0; i--, multipler *= 10)
            {
                result += multipler * numbers[i];
            }

            return result;
        }
     
        /// <summary>
        /// Simple method for swapping chose value type by references
        /// </summary>
        /// <param name="a">First value</param>
        /// <param name="b">Second value</param>
        private static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
        #endregion
    }
}
