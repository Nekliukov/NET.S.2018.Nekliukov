using System;
using System.Collections.Generic;

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
        /// in array, using binary search or null if it was not found.
        /// Delegate realisation!
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
        /// or
        /// Type doesn't implement IComparable
        /// </exception>
        public static int? Binary(T[] values, T value, Comparison<T> compare = null)
        {
            if (values == null || value == null)
            {
                throw new ArgumentNullException("Null argument was sent. Check input data");
            }

            if (values.Length == 0)
            {
                throw new ArgumentException("Empty array was sent");
            }

            if (typeof(IComparable<T>).IsAssignableFrom(typeof(T)))
            {
                compare = Comparer<T>.Default.Compare;
            }
            else if(compare == null)
            {
                throw new ArgumentException($"Type {typeof(T)} isn't implements IComparable");
            }

            return BinaryAlgorithm(values, value, compare);
        }

        /// <summary>
        /// Return index of a value, according to existion of an element
        /// in array, using binary search or null if it was not found
        /// Interface reslisation!
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="value">The value.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns>Value index or null</returns>
        /// <exception cref="System.ArgumentNullException">Null argument was sent.
        /// Check input data</exception>
        /// <exception cref="System.ArgumentException">
        /// Array is not sorted. Unexpected result
        /// or
        /// Empty array was sent
        /// or
        /// Type doesn't implement IComparable
        /// </exception>
        public static int? Binary(T[] values, T value, IComparer<T> comparer)
            // It's impossible to create IComparer<T> as an unnecessary argument,
            // because there is will be 2 same methods with signatures
            // Binary(T[] values, T value). Compile error.
            => Binary(values, value, comparer.Compare);

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
