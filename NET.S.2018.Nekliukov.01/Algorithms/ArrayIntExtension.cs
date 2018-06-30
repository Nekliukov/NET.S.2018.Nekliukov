using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public static class ArrayIntExtension
    {
        #region public sorting algorithms
        /// <summary>
        /// Merge sorting algorithm
        /// </summary>
        /// <param name="arr">An array, which you want to sort</param>
        /// <returns>Sorted array</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty</exception>
        public static int[] MergeSort(int[] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException(nameof(arr));
            }

            if (arr.Length <= 0)
            {
                throw new ArgumentException(nameof(arr));
            }

            if (arr.Length == 1)
            {
                return arr;
            }

            int middle = arr.Length / 2;
            int[] left = MergeSort(arr.Take(middle).ToArray());
            int[] right = MergeSort(arr.Skip(middle).ToArray());
            return Merge(left, right);
        }

        /// <summary>
        /// Quick Sorting algorithm
        /// </summary>
        /// <param name="arr">An array, which you want to sort</param>
        /// <returns>Sorted array</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty</exception>
        public static int[] QuickSort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 0)
            {
                throw new ArgumentException(nameof(array));
            }

            return QuickSort(array, 0, array.Length - 1);
        }
        #endregion

        #region Private methods
        // Main QuickSort method
        private static int[] QuickSort(int[] array, int start, int end)
        {
            if (start >= end)
            {
                return array;
            }

            int pivot = Partition(array, start, end);
            QuickSort(array, start, pivot - 1);
            QuickSort(array, pivot + 1, end);
            return array;
        }

        // Merging method
        private static int[] Merge(int[] left, int[] right)
        {
            List<int> result = new List<int>();
            int i = 0, j = 0; // left and right iterators
            for (int k = 0; k < left.Length + right.Length; k++)
            {
                if (i < left.Length && j < right.Length)
                {
                    if (left[i] <= right[j])
                    {
                        result.Add(left[i++]);
                    }
                    else
                    {
                        result.Add(right[j++]);
                    }
                }
                else
                {
                    if (j < right.Length)
                    {
                        result.Add(right[j++]);
                    }
                    else
                    {
                        result.Add(left[i++]);
                    }
                }           
            }

            return result.ToArray();
        }

        // QuickSort par
        private static int Partition(int[] array, int start, int end)
        {
            int temp; // swap helper
            int marker = start; // divides left and right subarrays
            for (int i = start; i <= end; i++)
            {
                if (array[i] < array[end])  // pivot
                {
                    temp = array[marker]; // swap
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }

            // put pivot(array[end]) between left and right subarrays
            temp = array[marker];
            array[marker] = array[end];
            array[end] = temp;
            return marker;
        }
        #endregion
    }
}