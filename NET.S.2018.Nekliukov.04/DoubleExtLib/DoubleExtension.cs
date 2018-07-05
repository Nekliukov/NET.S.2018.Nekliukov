using System.Runtime.InteropServices;

namespace DoubleExtLib
{
    public static class DoubleExtension
    {
        #region Constsant values
        private const int BitsInByte  = 8;
        private const int BitsInInt64 = 64;
        #endregion

        #region Public API
        /// <summary>
        /// Method for converting System.Double type into IEEE 754. The IEEE Standard
        /// for Floating-Point Arithmetic is a technical standard for floating-point
        /// computation. This method extends System.Double.
        /// </summary>
        /// <param name="number">User's System.Double number</param>
        /// <returns>IEEE 754 format as a string</returns>
        public static string ConvertToIEEE754(this double number)
        {
            var bits = new Converter64Bit(number);
            return bits.ToInt64().ConvertToBinary();
        }
        #endregion

        #region Private API
        private static string ConvertToBinary(this long bits)
        {
            string binResult = string.Empty;
            string nextBit;
            for (int i = 0; i < BitsInInt64; i++)
            {
                nextBit = ((bits & 1) == 0) ? "0" : "1";
                binResult = string.Concat(nextBit, binResult);
                bits >>= 1;
            }

            return binResult;
        }

        /// <summary>
        /// Structure that lets us control the physical layout of the data fields.
        /// Helps to see the representation of 64 binary bit number in long type the same as in double
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        private struct Converter64Bit
        {
            [FieldOffset(0)]
            private readonly long int64;

            [FieldOffset(0)]
            private readonly double double64;

            /// <summary>
            /// Structure's constructor for field(s) initializing 
            /// </summary>
            /// <param name="value">Value that we will convert</param>
            public Converter64Bit(double value) : this()
            {
                double64 = value;
            }

            /// <summary>
            /// Short and fast method for returning the int64 representation of double
            /// </summary>
            /// <returns>Int64 represenatation of double</returns>
            public long ToInt64() => int64;
        }
        #endregion
    }
}
