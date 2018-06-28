using System;
using System.Collections.Generic;

namespace TasksLibDay2
{
    /// <summary>
    /// Main static class for Day2's tasks solutions 
    /// Consist of two algorithms (#1 and #6 tasks) 
    /// </summary>
    public static class Tasks
    {
        /// Filter of an int array by existion of choosen digit
        /// <param name="initArray">Initial array of numbers </param>
        /// <param name="digit">Digit, that initial array's numbers must contain </param>
        /// <returns>Array of filtered numbers </returns>
        /// <exception cref="ArgumentNullException">Thrown when null comes as an array</exception>
        /// <exception cref="ArgumentException">Thrown when we get an empty array</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the sencond parametr is 
        /// not a digit (must be 0..9)</exception>
        public static int[] FilterDigit(int[] initArray, int digit)
        {
            if (initArray == null)
            {
                throw new ArgumentNullException();
            }

            if (initArray.Length == 0)
            {
                throw new ArgumentException();
            }

            if (digit < 0 || digit > 9)
            {
                throw new ArgumentOutOfRangeException();
            }

            // List of future founded numbers
            List<int> result = new List<int>();
            int curNum;
            for (int i = 0; i < initArray.Length; i++)
            {
                curNum = initArray[i];
                //// Algorithm of separating number on digits
                while (curNum != 0)
                {
                    if (Math.Abs(curNum % 10) == digit)
                    {
                        result.Add(initArray[i]);
                        break;
                    }
                    else
                    {
                        curNum /= 10;
                    }
                }
            }

            return result.ToArray();
        }

        /// <summary>
        /// This method works with bits. It inserts in source value's range of bits, 
        /// number of first bits from the second array.
        /// </summary>
        /// <param name="numberSource">Source number</param>
        /// <param name="numberIn">Number from which we will take range of bits </param>
        /// <param name="fromBitNum">Position to copy bits from</param>
        /// <param name="toBitNum">Position to copy bits to </param>
        /// <returns>Integer value after bits manipulation</returns>
        /// <exception cref="ArgumentException">Thrown when position from which ew want 
        /// to copy bits is higher when destination</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one of the arguments is
        /// outside the bits range (not in 0..31) </exception>
        public static int InsertNumber(int numberSource, int numberIn, int fromBitNum, int toBitNum)
        {
            if (toBitNum < fromBitNum)
            {
                throw new ArgumentException();
            }

            if ((toBitNum > 31 || toBitNum < 0) || (fromBitNum > 31 || fromBitNum < 0))
            {
                throw new ArgumentOutOfRangeException();
            }

            char[] bitsSource = ConvertTo32bits(numberSource);
            char[] bitsIn = ConvertTo32bits(numberIn);
            int curBitNum = 0;
            for (int i = fromBitNum; i <= toBitNum; i++, curBitNum++)
            {
                bitsSource[i] = bitsIn[curBitNum];
            }

            return ConvertToInt(bitsSource);
        }

        // Converts Int32 to bits and reverses it to "higher<-lower"
        // bits format
        private static char[] ConvertTo32bits(int number)
        {
            string snumber = Convert.ToString(number, 2);
            string temp = string.Empty;
            for (int i = snumber.Length - 1; i >= 0; i--)
            {
                temp += snumber[i];
            }

            for (int i = temp.Length; i < 32; i++)
            {
                temp += '0';
            }

            return temp.ToCharArray(0, temp.Length);
        }

        // Reverses bits in format to convert it in Int32
        private static int ConvertToInt(char[] number)
        {
            string temp = string.Empty;
            for (int i = number.Length - 1; i >= 0; i--)
            {
                temp += number[i];
            }

            string result = string.Empty;
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == '0')
                {
                    continue;
                }
                else
                {
                    result = temp.Substring(i, temp.Length - i);
                    break;
                }
            }

            return Convert.ToInt32(result, 2);
        }
    }
}
