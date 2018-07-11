using System;
using System.Globalization;

namespace CustomerLib
{
    /// <summary>
    /// Class that creates customer's instances
    /// </summary>
    /// <seealso cref="System.IFormattable" />
    public class Customer: IFormattable
    {
        #region Private fields
        private string name;
        private string contactPhone;
        private decimal revenue;
        #endregion

        #region Properties

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        /// <exception cref="ArgumentNullException">Null argument has been sent</exception>
        /// <exception cref="ArgumentException">Empty string has been sent</exception>
        public string Name
        {
            get => name;
            private set
            {
                CheckInputString(value);
                name = value;
            }
        }

        /// <summary>
        /// Gets the revenue.
        /// </summary>
        /// <value>
        /// The revenue.
        /// </value>
        /// <exception cref="ArgumentException">Revenue value can't be lower than 0</exception>
        /// <exception cref="ArgumentNullException">Null argument has been sent</exception>
        /// <exception cref="ArgumentException">Empty string has been sent</exception>
        public decimal Revenue
        {
            get => revenue;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Revenue {value} can't be lower than 0");
                }

                revenue = value;
            }
        }

        /// <summary>
        /// Gets the contact phone.
        /// </summary>
        /// <value>
        /// The contact phone.
        /// </value>
        /// <exception cref="ArgumentException">Wrong telephone number fromat</exception>
        public string ContactPhone
        {
            get => contactPhone;
            private set
            {
                CheckInputString(value);
                if (!IsPhoneNumber(value))
                {
                    throw new ArgumentException("Wrong telephone number fromat");
                }
                contactPhone = value;
            }
        }
        #endregion

        #region Constructor(s)        
        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        /// <param name="customerName">Name of the customer.</param>
        /// <param name="customerRevenue">The customer revenue.</param>
        /// <param name="customerCP">The customer contact phone.</param>
        public Customer(string customerName, decimal customerRevenue, string customerCP)
        {
            Name = customerName;
            Revenue = customerRevenue;
            ContactPhone = customerCP;
        }
        #endregion

        #region IFormattable interface realisation        
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        /// <exception cref="FormatException">Invalid format string</exception>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (String.IsNullOrEmpty(format)) format = "G";
            if (formatProvider == null) formatProvider = CultureInfo.CurrentCulture;

            switch (format)
            {
                case "G":
                    {
                        return $"{name}, {Revenue}, {contactPhone}";
                    }
                case "N":
                    {
                        return name.ToString();
                    }
                case "C":
                    {
                        return contactPhone.ToString();
                    }
                case "NR":
                    {
                        return $"{name}, {Revenue}";
                    }
                case "NC":
                    {
                        return $"{name}, {contactPhone}";
                    }
                default:
                    {
                        throw new FormatException(string.Format("Invalid format string: '{0}'.", format));
                    }
            }

        }
        #endregion

        #region Public API        
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => this.ToString("G", CultureInfo.CurrentCulture);
        #endregion

        #region Private API        
        /// <summary>
        /// Checks the input string on null or empty.
        /// </summary>
        /// <param name="inputString">The input string.</param>
        /// <exception cref="ArgumentNullException">Null argument has been sent</exception>
        /// <exception cref="ArgumentException">Empty string has been sent</exception>
        private void CheckInputString(string inputString)
        {
            if (inputString == null)
            {
                throw new ArgumentNullException("Null argument has been sent");
            }

            if (inputString == string.Empty)
            {
                throw new ArgumentException("Empty string has been sent");
            }
        }

        /// <summary>
        /// Determines whether [is phone number] [the specified phone number].
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <returns>
        ///   <c>true</c> if [is phone number] [the specified phone number]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsPhoneNumber(string phoneNumber)
        {
            string allowableSymbols = "0123456789-()+. ";
            string resultNumber = string.Empty;
            for (int i = 0; i < phoneNumber.Length; i++)
            {
                if (!allowableSymbols.Contains(phoneNumber[i].ToString()))
                {
                    return false;
                }
                
                if (Char.IsDigit(phoneNumber[i]))
                {
                    resultNumber += phoneNumber[i];
                }
            }
            
            if (resultNumber.Length > 15 || resultNumber.Length == 0)
            {
                return false;
            }

            return true;
        }
        #endregion
    }
}
