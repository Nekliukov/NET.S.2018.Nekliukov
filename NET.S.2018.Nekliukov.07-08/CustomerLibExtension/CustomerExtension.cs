using CustomerLib;
using System;
using System.Globalization;

namespace CustomerLibExtension
{
    public class AnotherFormatProvider : IFormatProvider, ICustomFormatter
    {
        IFormatProvider _parent;

        #region Public API
        public AnotherFormatProvider() : this(CultureInfo.CurrentCulture) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WordyFormatProvider"/> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public AnotherFormatProvider(IFormatProvider parent)
        {
            _parent = parent;
        }

        /// <summary>
        /// Returns an object that provides formatting services for the specified type.
        /// </summary>
        /// <param name="formatType">An object that specifies the type of format object to return.</param>
        /// <returns>
        /// An instance of the object specified by <paramref name="formatType" />, if the <see cref="T:System.IFormatProvider" /> implementation can supply that type of object; otherwise, null.
        /// </returns>
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter)) return this;
            return null;
        }

        /// <summary>
        /// Formats the specified format.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg">The argument.</param>
        /// <param name="prov">The prov.</param>
        /// <returns>Formatted string</returns>
        /// <exception cref="ArgumentNullException">Null argument was sent</exception>
        /// <exception cref="ArgumentException">Wrong argumnet type</exception>
        public string Format(string format, object arg, IFormatProvider prov)
        {
            if (arg == null)
            {
                throw new ArgumentNullException($"Null {nameof(arg)} was sent");
            }

            if (!(arg is Customer customer))
            {
                throw new ArgumentException($"{nameof(arg)} has wrong type!");
            }

            string resultString = string.Empty;
            format = format.ToUpper();

            switch (format)
            {
                case "NC" :
                    {
                        resultString = $"{customer.Name}, {customer.ContactPhone}";
                        break;
                    }
                case "NR":
                    {
                        resultString = $"{customer.Name}, {customer.Revenue}";
                        break;
                    }
                default:
                    {
                        // If it's not our format string, defer to the parent provider:
                        return string.Format(_parent, "{0:" + format + "}", arg);
                    }
            }

            return resultString;
        }
        #endregion
    }
}
