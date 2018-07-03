using System;
using System.Diagnostics;

namespace MathsExtension
{
    public class Operations
    {
        #region Public API
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

        /// <summary>
        /// Method for evaluating of greatest common divisior of two numbers
        /// using Euclid algorithm
        /// </summary>
        /// <param name="firstNum">First integer number</param>
        /// <param name="secondNum">Second integer number</param>
        /// <returns>GCD of two numbers</returns>
        public static int FindGCDEuclid(int firstNum, int secondNum)
        {
            ConvertToAbsolute(ref firstNum, ref secondNum);

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
        /// Overloaded method for finding next positive bigeer number, that
        /// consist of the same digits and saving of the elapsed time
        /// </summary>
        /// <param name="number">User's number</param>
        /// <param name="watch">Object for time measuring</param>
        /// <returns>Next same digits number + elapsed time</returns>
        public static int FindGCDEuclid(int number, out Stopwatch watch)
        {
            watch = Stopwatch.StartNew();
            int result = FindNextBiggerNumber(number);
            watch.Stop();
            return result;
        }

        /// <summary>
        /// Overloaded method for evaluating of greatest common divisior of
        /// 2+ numbers using Euclid algorithm
        /// </summary>
        /// <param name="firstNum">First integer number</param>
        /// <param name="secondNum">Second integer number</param>
        /// <param name="nums">List of other numbers</param>
        /// <returns>GCD of more than 2 numbers</returns>
        public static int FindGCDEuclid(int firstNum, int secondNum, params int[] nums)
        {         
            Array.Resize(ref nums, nums.Length + 2);
            int arrLen = nums.Length;
            nums[arrLen - 1] = firstNum;
            nums[arrLen - 2] = secondNum;

            int currGCD = 0;
            for (int i = 0; i < arrLen; i++)
            {
                currGCD = FindGCDEuclid(currGCD, nums[i]);
            }

            return currGCD;
        }

        /// <summary>
        /// Method for evaluating of greatest common divisior of two numbers
        /// using Binary algorithm
        /// </summary>
        /// <param name="firstNum">First integer number</param>
        /// <param name="secondNum">Second integer number</param>
        /// <returns>GCD of more than 2 numbers</returns>
        public static int FindGCDBinary(int firstNum, int secondNum)
        {
            ConvertToAbsolute(ref firstNum, ref secondNum);
            return BinaryGCD(firstNum, secondNum);        
        }

        /// <summary>
        /// Overloaded method for evaluating of greatest common divisior of
        /// 2+ numbers using Binary algorithm
        /// </summary>
        /// <param name="firstNum">First integer number</param>
        /// <param name="secondNum">Second integer number</param>
        /// <param name="nums">List of other numbers</param>
        /// <returns>GCD of more than 2 numbers</returns>
        public static int FindGCDBinary(int firstNum, int secondNum, params int[] nums)
        {
            Array.Resize(ref nums, nums.Length + 2);
            int arrLen = nums.Length;
            nums[arrLen - 1] = firstNum;
            nums[arrLen - 2] = secondNum;

            int currGCD = 0;
            for (int i = 0; i < arrLen; i++)
            {
                currGCD = FindGCDBinary(currGCD, nums[i]);
            }

            return currGCD;
        }

        #region Testing methods
        /// <summary>
        /// Method for testing execution time of GCD methods with 2 args
        /// </summary>
        /// <param name="GCD">Choosen method</param>
        /// <param name="firstNumber">First integer value</param>
        /// <param name="secondNumber">Second integer value</param>
        /// <returns>Structure with information about the execution time</returns>
        public static Stopwatch GetGCDExecutionTime(Func<int, int, int> GCD, int firstNumber,
            int secondNumber)
        {
            Stopwatch watch = Stopwatch.StartNew();
            int result = GCD(firstNumber, secondNumber);
            watch.Stop();
            return watch;
        }

        /// <summary>
        /// Method for testing execution time of GCD methods with more than 2 args
        /// </summary>
        /// <param name="GCD">Choosen method</param>
        /// <param name="firstNumber">First integer value</param>
        /// <param name="secondNumber">Second integer value</param>
        /// <param name="nums">List of other nums</param>
        /// <returns>Structure with information about the execution time</returns>
        public static Stopwatch GetGCDExecutionTime(Func<int, int, int[], int> GCD, int firstNumber,
            int secondNumber, params int[] nums)
        {
            Stopwatch watch = Stopwatch.StartNew();
            int result = GCD(firstNumber, secondNumber, nums);
            watch.Stop();
            return watch;
        }

        /// <summary>
        /// Method for testing execution time of finding Nth root of double value
        /// </summary>
        /// <param name="NthRoot">Choosen method</param>
        /// <param name="number">User's number</param>
        /// <param name="degree">User;s degree</param>
        /// <param name="precision">Setted precision</param>
        /// <returns>Structure with information about the execution time</returns>
        public static Stopwatch GetNthRootExecutionTime(Func<double, int, double, double> NthRoot,
            double number, int degree, double precision)
        {
            Stopwatch watch = Stopwatch.StartNew();
            double result = NthRoot(number, degree, precision);
            watch.Stop();
            return watch;
        }
        #endregion
        #endregion

        #region Private API
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
        /// Checks existion of negative elements and makes them positive
        /// </summary>
        /// <param name="firstNum">First argument</param>
        /// <param name="secondNum">Second argument</param>
        private static void ConvertToAbsolute(ref int firstNum, ref int secondNum)
        {
            if (firstNum < 0)
            {
                firstNum *= -1;
            }

            if (secondNum < 0)
            {
                secondNum *= -1;
            }
        }

        /// <summary>
        /// Main part of Binary recoursive algorithm
        /// </summary>
        /// <param name="firstNum">First integer numebr</param>
        /// <param name="secondNum">Second integer number</param>
        /// <returns>GCD of 2 numbers</returns>
        private static int BinaryGCD(int firstNum, int secondNum)
        {
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
