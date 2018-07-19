using System;
using System.Diagnostics;

namespace MathsExtension
{
    public class Operations
    {
        #region Public API

        #region Nth Root
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
            if (degree < 1)
            {
                throw new ArgumentException("Degree must higher than 0!");
            }

            if (precision <= 0 || precision >= 1)
            {
                throw new ArgumentException("Precision must be in range of 0..1");
            }

            if (number < 0 && degree % 2 == 0)
            {
                throw new ArgumentException("It's impossible to take odd degree" +
                    " root of negative number ");
            }

            double currStep = number / 2;
            double prevStep = 0;
            while (Math.Abs(prevStep - currStep) >= precision)
            {
                prevStep = currStep;
                currStep = (1.0 / degree) * ((degree - 1) * currStep + number /
                    Math.Pow(currStep, degree - 1));
            }

            return currStep;
        }
        #endregion

        #region Next bigger number
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
        public static long FindNextBiggerNumber(int number, out Stopwatch watch)
        {
            watch = Stopwatch.StartNew();
            int result = FindNextBiggerNumber(number);
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
        #endregion

        #region Euclid GCD algorithm
        /// <summary>
        /// Method for evaluating of greatest common divisior of two numbers
        /// using Euclid algorithm
        /// </summary>
        /// <param name="firstNum">First integer number</param>
        /// <param name="secondNum">Second integer number</param>
        /// <returns>GCD of two numbers</returns>
        public static int FindGCDEuclid(int firstNum, int secondNum)
            => FindGCD(Euclid, firstNum, secondNum);

        /// <summary>
        /// Overloaded method for evaluating of greatest common divisior of
        /// 3 numbers using Euclid algorithm
        /// </summary>
        /// <param name="firstNum">First integer number</param>
        /// <param name="secondNum">Second integer number</param>
        /// <param name="nums">Third integer number</param>
        /// <returns>GCD of 3 numbers</returns>
        public static int FindGCDEuclid(int firstNum, int secondNum, int thirdNum)
            => FindGCD(Euclid, firstNum, secondNum, thirdNum);

        /// <summary>
        /// Overloaded method for evaluating of greatest common divisior of
        /// 4+ numbers using Euclid algorithm
        /// </summary>
        /// <param name="nums">Array of numbers</param>
        /// <returns>GCD of 4+ numbers</returns>
        /// <exception cref="ArgumentException">Thrown when number of elements lower than 2</exception>
        public static int FindGCDEuclid(params int[] nums)
            => FindGCD(Euclid, nums);

        #region Euclid GCD time counter
        /// <summary>
        /// Returns GCD of 2 numbers and time in milliseconds
        /// </summary>
        /// <param name="firstNum">First integer number</param>
        /// <param name="secondNum">Second integer number</param>
        /// <param name="time">Elapsed time</param>
        /// <returns>GCD</returns>
        public static int FindGCDEuclid(int firstNum, int secondNum, out long time)
        {
            Stopwatch sw = Stopwatch.StartNew();
            int result = Euclid(firstNum, secondNum);
            time = sw.ElapsedMilliseconds;
            return result;
        }

        /// <summary>
        /// Returns GCD of 3 numbers and time in milliseconds
        /// </summary>
        /// <param name="firstNum">First integer number</param>
        /// <param name="secondNum">Second integer number</param>
        /// <param name="thirdNum">Third integer number</param>
        /// <param name="time">Elapsed time</param>
        /// <returns>GCD</returns>
        public static int FindGCDEuclid(int firstNum, int secondNum,
            int thirdNum, out long time)
        {
            Stopwatch sw = Stopwatch.StartNew();
            int result = Euclid(firstNum, Euclid(secondNum, thirdNum));
            time = sw.ElapsedMilliseconds;
            return result;
        }

        /// <summary>
        /// Returns GCD of 4+ numbers and time in milliseconds
        /// </summary>
        /// <param name="nums">The numbers</param>
        /// <param name="time">Elapsed time</param>
        /// <returns>GCD</returns>
        public static int FindGCDEuclid(out long time, params int[] nums)
        {
            Stopwatch sw = Stopwatch.StartNew();
            int result = FindGCDEuclid(nums);
            time = sw.ElapsedMilliseconds;
            return result;
        }
        #endregion


        #endregion

        #region Binary GCD algorithm
        /// <summary>
        /// Method for evaluating of greatest common divisior of two numbers
        /// using Binary algorithm
        /// </summary>
        /// <param name="firstNum">First integer number</param>
        /// <param name="secondNum">Second integer number</param>
        /// <returns>GCD of more than 2 numbers</returns>
        public static int FindGCDBinary(int firstNum, int secondNum)
            => FindGCD(BinaryGCD, firstNum, secondNum);        

        /// <summary>
        /// Method for evaluating of greatest common divisior of 3 numbers
        /// using Binary algorithm
        /// </summary>
        /// <param name="firstNum">First integer number</param>
        /// <param name="secondNum">Second integer number</param>
        /// <param name="thirdNum">Third integer number</param>
        /// <returns>GCD of 3 numbers</returns>
        public static int FindGCDBinary(int firstNum, int secondNum, int thirdNum)
            => FindGCD(BinaryGCD, firstNum, secondNum, thirdNum);

        /// <summary>
        /// Overloaded method for evaluating of greatest common divisior of
        /// 4+ numbers using Binary algorithm
        /// </summary>
        /// <param name="firstNum">Array of integer numers</param>
        /// <exception cref="ArgumentException">Thrown when number of elements lower than 2</exception>
        /// <returns>GCD of 4+ elements</returns>
        public static int FindGCDBinary(params int[] nums)
            => FindGCD(BinaryGCD, nums);

        #region Binary GCD time counter
        /// <summary>
        /// Returns GCD of 2 numbers and time in milliseconds
        /// </summary>
        /// <param name="firstNum">First integer number</param>
        /// <param name="secondNum">Second integer number</param>
        /// <param name="time">Elapsed time</param>
        /// <returns>GCD</returns>
        public static int FindGCDBinary(int firstNum, int secondNum, out long time)
        {
            Stopwatch sw = Stopwatch.StartNew();
            int result = Euclid(firstNum, secondNum);
            time = sw.ElapsedMilliseconds;
            return result;
        }

        /// <summary>
        /// Returns GCD of 3 numbers and time in milliseconds
        /// </summary>
        /// <param name="firstNum">First integer number</param>
        /// <param name="secondNum">Second integer number</param>
        /// <param name="thirdNum">Third integer number</param>
        /// <param name="time">Elapsed time</param>
        /// <returns>GCD</returns>
        public static int FindGCDBinary(int firstNum, int secondNum,
            int thirdNum, out long time)
        {
            Stopwatch sw = Stopwatch.StartNew();
            int result = Euclid(firstNum, Euclid(secondNum, thirdNum));
            time = sw.ElapsedMilliseconds;
            return result;
        }

        /// <summary>
        /// Returns GCD of 4+ numbers and time in milliseconds
        /// </summary>
        /// <param name="nums">The numbers</param>
        /// <param name="time">Elapsed time</param>
        /// <returns>GCD</returns>
        public static int FindGCDBinary(out long time, params int[] nums)
        {
            Stopwatch sw = Stopwatch.StartNew();
            int result = FindGCDEuclid(nums);
            time = sw.ElapsedMilliseconds;
            return result;
        }
        #endregion
        #endregion

        #region Delegates realistaion
        /// <summary>
        /// Finds the GCD using delegates
        /// </summary>
        /// <param name="GcdAlgorithm">The GCD algorithm.</param>
        /// <param name="firstNum">The first number.</param>
        /// <param name="secondNum">The second number.</param>
        /// <returns>GCD</returns>
        private static int FindGCD(Func<int, int, int> GcdAlgorithm, int firstNum, int secondNum)
            => GcdAlgorithm(firstNum, secondNum);

        /// <summary>
        /// Finds the GCD using delegate.
        /// </summary>
        /// <param name="GcdAlgorithm">The GCD algorithm.</param>
        /// <param name="firstNum">The first number.</param>
        /// <param name="secondNum">The second number.</param>
        /// <param name="thirdNum">The third number.</param>
        /// <returns>GCD</returns>
        private static int FindGCD(Func<int, int, int> GcdAlgorithm,
            int firstNum, int secondNum, int thirdNum)
            => GcdAlgorithm(GcdAlgorithm(firstNum, secondNum), thirdNum);

        /// <summary>
        /// Finds the GCD using delegate
        /// </summary>
        /// <param name="GcdAlgorithm">The GCD algorithm.</param>
        /// <param name="numbers">The numbers.</param>
        /// <returns>GCD</returns>
        private static int FindGCD(Func<int, int, int> GcdAlgorithm, params int[] nums)
        {
            if (nums.Length < 2)
            {
                throw new ArgumentException("Minimum number of elements to find GCD must be 2 or more");
            }

            int currGCD = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                currGCD = GcdAlgorithm(currGCD, nums[i]);
            }

            return currGCD;
        }

        #endregion

        #endregion

        #region Private methods

        private static int Euclid(int firstNum, int secondNum)
        {
            firstNum = Math.Abs(firstNum);
            secondNum = Math.Abs(secondNum);

            while (firstNum != 0 && secondNum != 0)
            {
                if (firstNum > secondNum)
                {
                    firstNum %= secondNum;
                }
                else
                {
                    secondNum %= firstNum;
                }
            }

            return (firstNum == 0) ? secondNum : firstNum;
        }

        private static int Binary(int firstNum, int secondNum)
        {
            firstNum = Math.Abs(firstNum);
            secondNum = Math.Abs(secondNum);

            while (firstNum != 0 && secondNum != 0)
            {
                if (firstNum > secondNum)
                {
                    firstNum %= secondNum;
                }
                else
                {
                    secondNum %= firstNum;
                }
            }

            return (firstNum == 0) ? secondNum : firstNum;
        }

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
        /// Main part of Binary recoursive algorithm
        /// </summary>
        /// <param name="firstNum">First integer numebr</param>
        /// <param name="secondNum">Second integer number</param>
        /// <returns>GCD of 2 numbers</returns>
        private static int BinaryGCD(int firstNum, int secondNum)
        {
            firstNum = Math.Abs(firstNum);
            secondNum = Math.Abs(secondNum);

            int caseOut = ChecksOnBinaryGCD(firstNum, secondNum);

            if (caseOut != -1)
            {
                return caseOut;
            }

            if ((~firstNum & 1) != 0)
            {
                if ((secondNum & 1) != 0)
                {
                    return FindGCDBinary(firstNum >> 1, secondNum);
                }
                else
                {
                    return FindGCDBinary(firstNum >> 1, secondNum >> 1) << 1;
                }
            }

            if ((~secondNum & 1) != 0)
            {
                return BinaryGCD(firstNum, secondNum >> 1);
            }

            if (firstNum > secondNum)
            {
                return BinaryGCD((firstNum - secondNum) >> 1, secondNum);
            }

            return BinaryGCD((secondNum - firstNum) >> 1, firstNum);
        }

        /// <summary>
        /// Private method for BinaryGCD that contains checks on
        /// situations to get out of recoursion
        /// </summary>
        /// <param name="firstNum">First integer number</param>
        /// <param name="secondNum">Second integer number</param>
        /// <returns>One of the params or -1 in case of to continue recoursion</returns>
        private static int ChecksOnBinaryGCD(int firstNum, int secondNum)
        {
            if (firstNum == secondNum)
            {
                return firstNum;
            }

            if (firstNum == 0)
            {
                return secondNum;
            }

            if (secondNum == 0)
            {
                return firstNum;
            }

            return -1;
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
