using System;
using System.Globalization;
using BLL.Interface.Interfaces;

namespace BLL.IdGenStandarts
{
    /// <summary>
    /// IBAN standart class for account number generating
    /// </summary>
    public class IbanStandart: IAccountNumberGenerator
    {
        #region Constants
        private const byte NUMBER_LENGTH = 16;
        private const byte MIN_DIGIT = 0;
        private const byte MAX_DIGIT = 9;
        #endregion

        #region Public API
        /// <summary>
        /// Generates fake International Bank Account Number (IBAN), that consist
        /// of 16 symbols, including user region and random 14 digits
        /// </summary>
        /// <returns>Account number</returns>
        public string Generate()
        {
            string resultNumber = string.Empty;
            resultNumber += CultureInfo.CurrentCulture.EnglishName.
                Substring(0, 2).ToUpper();
            Random rand = new Random();
            int startLen = resultNumber.Length;
            for (int i = 0; i < NUMBER_LENGTH - startLen; i++)
            {
                resultNumber += rand.Next(MIN_DIGIT, MAX_DIGIT).ToString();
            }

            return resultNumber;
        }
        #endregion
    }
}
