using System;
using System.Collections.Generic;

namespace StringExtLib
{
    public static class StringExtension
    {
        #region Readonly fields
        private static readonly Dictionary<char, int> Digits
            = new Dictionary<char, int>
        { 
                { '0', 0 }, { '1', 1 }, { '2', 2 }, { '3', 3 }, { '4', 4 },
                { '5', 5 }, { '6', 6 }, { '7', 7 }, { '8', 8 }, { '9', 9 },
                { 'A', 10 }, { 'B', 11 }, { 'C', 12 }, { 'D', 13 }, { 'E', 14 }, { 'F', 15 },
        };
        #endregion

        #region Public API

        /// <summary>
        /// Converts all positive 32 bit numbers from 2..16 bases to 10 base. Extends System.String type.
        /// </summary>
        /// <param name="number">The number</param>
        /// <param name="numberBase">The number's base.</param>
        /// <returns>Number in 10th base</returns>
        /// <exception cref="ArgumentNullException">Number can't be equal to null</exception>
        /// <exception cref="ArgumentException">Empty string has been sent</exception>
        /// <exception cref="ArgumentException">Digit can't be higher than or equal to base</exception>
        /// <exception cref="ArgumentException">There are no digits equal to the value</exception>
        /// <exception cref="ArgumentException">Base must be in rage of 2 to 16</exception>
        /// <exception cref="OverflowException">Thrown, when you try to put in Int32 value, tha higher
        /// than 2^(31)-1</exception>
        public static int ConvertToBase10(this string number, byte numberBase)
        {
            number = number.ToUpper();

            if (number is null)
            {
                throw new ArgumentNullException("Number can't be equal to null");
            }

            if (number.Length == 0)
            {
                throw new ArgumentException("Empty string has been sent");
            }

            if (numberBase < 2 || numberBase > 16)
            {
                throw new ArgumentException("Base must be 2 <= base <= 16");
            }

            if (numberBase == 10)
            {
                return Convert.ToInt32(number);
            }

            CheckDigits(number, numberBase);

            int base10Result = 0;
            for (int i = number.Length - 1; i >= 0; i--)
            {
                    base10Result += checked(Digits[number[i]] *
                        (int)Math.Pow(numberBase, number.Length - i - 1));
            }

            return base10Result;
        }
        #endregion

        #region Private API
        private static bool CheckDigits(string number, byte numberBase)
        {
            for (int i = 0; i < number.Length; i++)
            {
                if (!Digits.ContainsKey(number[i]))
                {
                    throw new ArgumentException($"There are no digits equal to the value {number[i]}");
                }

                if (Digits[number[i]] >= numberBase)
                {
                    throw new ArgumentException($"Digit {number[i]} can't be higher than or equal to base");
                }
            }

            return true;
        }
        #endregion
    }
}
