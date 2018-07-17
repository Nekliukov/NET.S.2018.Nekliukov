using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    /// <summary>
    /// BIC standart class for account number generating
    /// </summary>
    public class BicStandart : IAccountNumberGenerator
    {
        #region Constants
        private const byte NUMBER_LENGTH = 32;
        private const string ALPHABET = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        #endregion

        /// <summary>
        /// Generates fake Bank Identifier Codes (BIC) account number, that
        /// consist of 32 random symbols of english alphabet and digits
        /// </summary>
        /// <returns></returns>
        #region Public API
        public string Generate()
        {
            string resultNumber = string.Empty;
            Random rand = new Random();
            for (int i = 0; i < NUMBER_LENGTH; i++)
            {
                resultNumber += ALPHABET[rand.Next(0, ALPHABET.Length - 1)].ToString();
            }

            return resultNumber;
        }
        #endregion
    }
}
