using System;
using System.Collections.Generic;

namespace StringExtLib
{
    /// <summary>
    /// Class that extends System.String, giving an ability to
    /// convert number from 2..16 base to 10 base
    /// </summary>
    public static class StringExtension
    {
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

            string digits = GenerateAlphabet(numberBase);
            CheckDigits(number, numberBase, digits);

            int base10Result = 0;
            base10Result += digits.IndexOf(number[number.Length - 1]) * 1;
            double multiplier = numberBase;
            for (int i = number.Length - 2; i >= 0; i--)
            {
                base10Result += checked((int)(digits.IndexOf(number[i]) * multiplier));
                multiplier *= numberBase;
            }

            return base10Result;
        }
        #endregion

        #region Private API
        private static bool CheckDigits(string number, byte numberBase, string alphabet)
        {
            
            for (int i = 0; i < number.Length; i++)
            {
                if (alphabet.IndexOf(number[i]) == -1)
                {
                    throw new ArgumentException($"There are no digits equal to the value {number[i]}");
                }

                if (alphabet.IndexOf(number[i]) >= numberBase)
                {
                    throw new ArgumentException($"Digit {number[i]} can't be higher than or equal to base");
                }
            }

            return true;
        }

        private static string GenerateAlphabet(byte numberBase)
        {
            string resultAlphabet = string.Empty;
            const int SHIFT_TO_ALPH = 55;
            for(int i = 0; i < numberBase; i++)
            {
                if (i >= 10)
                {
                    resultAlphabet += char.ConvertFromUtf32(SHIFT_TO_ALPH + i);
                }
                else
                {
                    resultAlphabet += i.ToString();
                }
            }
            return resultAlphabet;
        }
        #endregion
    }
}
