using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Test
{
    [TestClass]
    public class ArrayIntExtensionTest
    {
        [TestMethod]
        public void MergeSort_5PosNumbers_SortedExpected()
        {
            // arrange
            int[] testarr = { 4, 3, 2, 1, 0 };
            int[] expected = { 0, 1, 2, 3, 4 };

            // act
            int[] actual = Algorithms.ArrayIntExtension.MergeSort(testarr);

            // assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MergeSort_10000Numbers_SortedExpected()
        {
            Random rand = new Random();
            int[] testarr = new int[10000];
            for (int i = 0; i < testarr.Length; i++)
            {
                testarr[i] = rand.Next(int.MinValue, int.MaxValue);
            }

            int[] actual = Algorithms.ArrayIntExtension.MergeSort(testarr);
            Assert.IsTrue(IsSorted(actual));
        }      

        [TestMethod]
        public void MergeSort_2Numbers_SortedExpected()
        {
            // arrange
            int[] testarr  = { 11, -55 };
            int[] expected = { -55, 11 };

            // act
            int[] actual = Algorithms.ArrayIntExtension.MergeSort(testarr);

            // assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MergeSort_10PosAndNegNumbers_SortedExpected()
        {
            // arrange
            int[] testarr  = { 4, 2, 1, 5, 74, 23, 7, -7, 0, 1 };
            int[] expected = { -7, 0, 1, 1, 2, 4, 5, 7, 23, 74 };

            // act
            int[] actual = Algorithms.ArrayIntExtension.MergeSort(testarr);

            // assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void MergeSort_EmptyArray_ArgumentExceptionExpected()
        {
            // arrange
            int[] testarr = { };

            // act
            int[] actual = Algorithms.ArrayIntExtension.MergeSort(testarr);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void MergeSort_NullArrayArgument_ArgumentNullExceptionExpected()
        {
            // arrange
            int[] testarr = null;

            // act
            int[] actual = Algorithms.ArrayIntExtension.MergeSort(testarr);
        }

        [TestMethod]
        public void MergeSort_OneElementArray_ReturnedInitialArrayExpected()
        {
            // arrange
            int[] testarr = { 69 };
            int[] expected = { 69 };

            // act
            int[] actual = Algorithms.ArrayIntExtension.MergeSort(testarr);

            // assert
            CollectionAssert.Equals(expected, actual);
        }

        /////////////////// Quick Sort algorithm testing
        [TestMethod]
        public void QuickSort_5PosNumbers_SortedExpected()
        {
            // arrange
            int[] testarr = { 4, 3, 2, 1, 0 };
            int[] expected = { 0, 1, 2, 3, 4 };

            // act
            ArrayIntExtension.QuickSort(testarr);

            // assert
            CollectionAssert.AreEqual(expected, testarr);
        }

        [TestMethod]
        public void QuickSort_2Numbers_SortedExpected()
        {
            // arrange
            int[] testarr = { 11, -55 };
            int[] expected = { -55, 11 };

            // act
            Algorithms.ArrayIntExtension.QuickSort(testarr);

            // assert
            CollectionAssert.AreEqual(expected, testarr);
        }

        [TestMethod]
        public void QuickSort_10000Numbers_SortedExpected()
        {
            Random rand = new Random();
            int[] testarr = new int[10000];
            for (int i = 0; i < testarr.Length; i++)
            {
                testarr[i] = rand.Next(int.MinValue, int.MaxValue);
            }

            ArrayIntExtension.QuickSort(testarr);
            Assert.IsTrue(IsSorted(testarr));
        }

        [TestMethod]
        public void QuickSort_10PosAndNegNumbers_SortedExpected()
        {
            // arrange
            int[] testarr = { 74, 23, 7, -7, 0, 1, 8 };
            int[] expected = { -7, 0, 1, 7, 8, 23, 74 };

            ArrayIntExtension.QuickSort(testarr);

            // assert
            CollectionAssert.AreEqual(expected, testarr);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void QuickSort_NullArray_ArgumentNullExceptionExpected()
        {
            // arrange
            int[] testarr = null;

            ArrayIntExtension.QuickSort(testarr);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void QuickSort_EmptyArray_ArgumentExceptionExpected()
        {
            // arrange
            int[] testarr = { };

            ArrayIntExtension.QuickSort(testarr);
        }

        private bool IsSorted(int[] array)
        {
            bool sorted = true;
            for (int i = 0; i < array.Length - 2; i++)
            {
                if (array[i + 1] < array[i])
                {
                    sorted = false;
                    break;
                }
            }

            return sorted;
        }
    }
}
