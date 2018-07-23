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
        public static int[] MergeSort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} cannot references to null");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException($"{nameof(array)} cannot be empty");
            }

            if (array.Length == 1)
            {
                return array;
            }

            int middle = array.Length / 2;
            int[] left = MergeSort(array.Take(middle).ToArray());
            int[] right = MergeSort(array.Skip(middle).ToArray());
            return Merge(left, right);
        }

        /// <summary>
        /// Quick Sorting algorithm
        /// </summary>
        /// <param name="arr">An array, which you want to sort</param>
        /// <returns>Sorted array</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty</exception>
        public static void QuickSort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} cannot references to null");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException($"{nameof(array)} cannot be empty");
            }

            QuickSort(array, 0, array.Length - 1);
        }
        #endregion

        #region Private methods
        // Main QuickSort method
        static void QuickSort(int[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int num = array[start];

            int i = start, j = end;

            while (i < j)
            {
                while (i < j && array[j] > num)
                {
                    j--;
                }

                array[i] = array[j];

                while (i < j && array[i] < num)
                {
                    i++;
                }

                array[j] = array[i];
            }

            array[i] = num;
            QuickSort(array, start, i - 1);
            QuickSort(array, i + 1, end);
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

        private static void Swap(ref int a, ref int b){
            int temp = a;
            a = b;
            b = temp;
        }
        #endregion
    }
}