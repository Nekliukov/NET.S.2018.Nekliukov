using System;
using System.Collections.Generic;

namespace JaggedArrayLib
{
    /// <summary>
    /// Class for sorting jagged arrays rows in different ways
    /// </summary>
    public static class FromInterfaceToDelegate
    {
        #region Public API
        /// <summary>
        /// Bubble sort rows sorting with choosing of sorting way. Interface realisation
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="comparer">The comparer.</param>
        /// <exception cref="ArgumentException">Empty array was sent</exception>
        /// <exception cref="ArgumentNullException">Null array was sent</exception>
        public static void BubbleSort(int[][] array, IComparer<int[]> comparer)
        {
            CheckIsNullOrEmpty(array);
            for (var i = 0; i < array.Length; i++)
            {
                for (var j = 0; j < array.Length - i - 1; j++)
                {
                    if (comparer.Compare(array[j], array[j + 1]) > 0)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }

        /// <summary>
        /// Bubble sort rows sorting with choosing of sorting way. Delegate realisation
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="comparer">The comparer.</param>
        /// <exception cref="ArgumentException">Empty array was sent</exception>
        /// <exception cref="ArgumentNullException">Null array was sent</exception>
        public static void BubbleSort(int[][] array, Comparison<int[]> comparison)
            => BubbleSort(array, Comparer<int[]>.Create(comparison));

        #endregion

        private static void CheckIsNullOrEmpty(int[][] jagArray)
        {
            if (jagArray == null)
            {
                throw new ArgumentNullException("Null array was sent");
            }

            if (jagArray.Length == 0)
            {
                throw new ArgumentException("Empty array was sent");
            }
        }

        private static void Swap(ref int[] left, ref int[] right)
        {
            int[] temp = left;
            left = right;
            right = temp;
        }
    }
}
