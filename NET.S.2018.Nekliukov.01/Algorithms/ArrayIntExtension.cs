namespace Algorithms {
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class ArrayIntExtension {
        //Main sorting method
        public static int[] MergeSort(int[] arr) {
            if (arr == null)
                throw new ArgumentNullException(nameof(arr));
            if (arr.Length <= 0)
                throw new ArgumentException(nameof(arr));
            if (arr.Length == 1)
                return arr;
            int middle = arr.Length / 2;
            int[] left = MergeSort(arr.Take(middle).ToArray());
            int[] right = MergeSort(arr.Skip(middle).ToArray());
            return Merge(left, right);
        }

        //Merging method
        private static int[] Merge(int[] left, int[] right) {
            List<int> result = new List<int>();
            int i = 0, j = 0; //left and right iterators
            for (int k = 0; k < left.Length + right.Length; k++) {
                if (i < left.Length && j < right.Length) {
                    if (left[i] <= right[j])
                        result.Add(left[i++]);
                    else
                        result.Add(right[j++]);
                }
                else {
                    if (j < right.Length)
                        result.Add(right[j++]);
                    else
                        result.Add(left[i++]);
                }
            }
            return result.ToArray();
        }

        //Main QuickSort method
        private static int Partition(int[] array, int start, int end)
        {
            int temp;//swap helper
            int marker = start;//divides left and right subarrays
            for (int i = start; i <= end; i++)
            {
                if (array[i] < array[end]) //array[end] is pivot
                {
                    temp = array[marker]; // swap
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }
            //put pivot(array[end]) between left and right subarrays
            temp = array[marker];
            array[marker] = array[end];
            array[end] = temp;
            return marker;
        }

        public static int[] Quicksort(int[] array, int start, int end)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (array.Length == 0)
                throw new ArgumentException(nameof(array));
            if (start >= end)
                return array;

            int pivot = Partition(array, start, end);
            Quicksort(array, start, pivot - 1);
            Quicksort(array, pivot + 1, end);
            return array;
        }
    }
}