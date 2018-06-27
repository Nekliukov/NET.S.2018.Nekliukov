using System;
using System.Collections.Generic;

namespace TasksLibDay2 {
    /// <summary>
    /// Main static class for Day2's tasks solutions
    /// Consist of two algorithms (#1 and #6 tasks)
    /// </summary>
    public static class Tasks {
        /// Filter of an int array by existion of choosen digit
        /// <param name="initArray">Initial array of numbers</param>
        /// <param name="digit">Digit, that initial array's numbers must contain</param>
        /// <returns>Array of filtered numbers</returns>
        /// <exception cref="ArgumentNullException">Thrown when null comes as an array</exception>
        /// <exception cref="ArgumentException">Thrown when we get an empty array</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the sencond parametr is not a digit (must be 0..9)</exception>
        public static int[] FilterDigit(int[] initArray, int digit) {
            if (initArray == null)
                throw new ArgumentNullException();
            if (initArray.Length == 0)
                throw new ArgumentException();
            if (digit < 0 || digit > 9)
                throw new ArgumentOutOfRangeException();

            // List of future founded numbers
            List<int> result = new List<int>();
            int curNum;
            for (int i = 0; i < initArray.Length; i++) {
                curNum = initArray[i];
                //// Algorithm of separating number on digits
                while (curNum != 0) {
                    if (Math.Abs(curNum % 10) == digit) {
                        result.Add(initArray[i]);
                        break;
                    }
                    else
                        curNum /= 10;
                }
            }
            return result.ToArray();
        }

        public static void InsertNumber() {
            throw new NotImplementedException();
        }
    }
}
