using System.Collections.Generic;
using System.Linq;

namespace JaggedArrayLibTest
{
    /// <summary>
    /// Class for comparing elements in array
    /// </summary>
    public class Comparers
    {
        #region Public classes for comparing
        /// <summary>
        /// Case of sorting elements by max value ascending
        /// </summary>
        /// <seealso cref="System.Collections.Generic.IComparer{System.Int32[]}" />
        public class CompareByMaxUp : IComparer<int[]>
        {
            public int Compare(int[] lhs, int[] rhs)
            {
                int preResult = CompareValidator.Check(lhs, rhs);
                return (preResult == CompareValidator.IsOK) ? lhs.Max() - rhs.Max() : preResult;
            }
        }

        /// <summary>
        /// Case of sorting elements by max value decreasing
        /// </summary>
        /// <seealso cref="System.Collections.Generic.IComparer{System.Int32[]}" />
        public class CompareByMaxDown : IComparer<int[]>
        {
            public int Compare(int[] lhs, int[] rhs)
            {
                int preResult = CompareValidator.Check(lhs, rhs);
                return (preResult == CompareValidator.IsOK) ? rhs.Max() - lhs.Max() : preResult;
            }
        }

        /// <summary>
        /// Case of sorting elements by min value ascending
        /// </summary>
        /// <seealso cref="System.Collections.Generic.IComparer{System.Int32[]}" />
        public class CompareByMinUp : IComparer<int[]>
        {
            public int Compare(int[] lhs, int[] rhs)
            {
                int preResult = CompareValidator.Check(lhs, rhs);
                return (preResult == CompareValidator.IsOK) ? lhs.Min() - rhs.Min() : preResult;
            }
        }

        /// <summary>
        /// Case of sorting elements by min value decreasing
        /// </summary>
        /// <seealso cref="System.Collections.Generic.IComparer{System.Int32[]}" />
        public class CompareByMinDown : IComparer<int[]>
        {
            public int Compare(int[] lhs, int[] rhs)
            {
                int preResult = CompareValidator.Check(lhs, rhs);
                return (preResult == CompareValidator.IsOK) ? rhs.Min() - lhs.Min() : preResult;
            }
        }

        /// <summary>
        /// Case of sorting elements by sum array's value ascending
        /// </summary>
        /// <seealso cref="System.Collections.Generic.IComparer{System.Int32[]}" />
        public class CompareBySumUp : IComparer<int[]>
        {
            public int Compare(int[] lhs, int[] rhs)
            {
                int preResult = CompareValidator.Check(lhs, rhs);
                return (preResult == CompareValidator.IsOK) ? lhs.Sum() - rhs.Sum() : preResult;
            }
        }

        /// <summary>
        /// Case of sorting elements by sum array's value decreasing
        /// </summary>
        /// <seealso cref="System.Collections.Generic.IComparer{System.Int32[]}" />
        public class CompareBySumDown : IComparer<int[]>
        {
            public int Compare(int[] lhs, int[] rhs)
            {
                int preResult = CompareValidator.Check(lhs, rhs);
                return (preResult == CompareValidator.IsOK) ? rhs.Sum() - lhs.Sum() : preResult;
            }
        }
        #endregion
    }

    #region Validator
    /// <summary>
    /// Class for primitive checks operands on null and refference equality
    /// </summary>
    internal static class CompareValidator
    {
        internal const int IsOK = 2;
        internal static int Check(int[] lhs, int[] rhs)
        {
            if (ReferenceEquals(rhs, lhs))
            {
                return 0;
            }

            if (lhs == null)
            {
                return 1;
            }

            if (rhs == null)
            {
                return -1;
            }
            return IsOK;
        }
    }
    #endregion
}
