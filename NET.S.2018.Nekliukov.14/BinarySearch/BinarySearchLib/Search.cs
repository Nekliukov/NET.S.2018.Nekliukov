using System;

namespace BinarySearchLib
{
    /// <summary>
    /// Genric class for searching elements
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class Search<T>
    {
        #region Public API
        /// <summary>
        /// Return index of a value, according to existion of an element
        /// in array, using binary search or null if it was not found
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="value">The value.</param>
        /// <param name="compare">The comparer.</param>
        /// <returns>Value index or null</returns>
        /// <exception cref="System.ArgumentNullException">Null argument was sent.
        /// Check input data</exception>
        /// <exception cref="System.ArgumentException">
        /// Array is not sorted. Unexpected result
        /// or
        /// Empty array was sent
        /// </exception>
        public static int? Binary(T[] values, T value, Comparison<T> compare)
        {
            if (values == null || value == null)
            {
                throw new ArgumentNullException("Null argument was sent. Check input data");
            }

            if (values.Length == 0)
            {
                throw new ArgumentException("Empty array was sent");
            }

            if (compare(value, values[0]) < 0 ||
               (compare(value, values[values.Length - 1]) > 0))
            {
                return null;
            }

            return BinaryAlgorithm(values, value, compare);
        }
        #endregion 

        #region Private methods
        /// <summary>
        /// The main algorithm for binary searching
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="value">The value.</param>
        /// <param name="compare">The compare.</param>
        /// <returns>Index of a value or null</returns>
        private static int? BinaryAlgorithm(T[] values, T value, Comparison<T> compare)
        {
            int first = 0, last = values.Length, middle;

            while (first < last)
            {
                middle = first + (last - first) / 2;

                if (compare(value, values[middle]) < 0)
                {
                    last = middle;
                }
                else if (compare(value, values[middle]) == 0)
                {
                    return middle;
                }
                else
                {
                    first = middle + 1;
                }                    
            }

            return null;
        }
        #endregion
    }
}
