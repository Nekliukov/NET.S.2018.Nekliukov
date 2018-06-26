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
            int[] testarr =  { 4, 3, 2, 1, 0 };
            int[] expected = { 0, 1, 2, 3, 4 };

            // act
            int[] actual = Algorithms.ArrayIntExtension.MergeSort(testarr);

            // assert
            CollectionAssert.AreEqual(expected, actual);
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
            int[] testarr  = {4, 2, 1, 5, 74, 23, 7, -7, 0, 1 };
            int[] expected = {-7, 0, 1, 1, 2, 4, 5, 7, 23, 74 };

            // act
            int[] actual = Algorithms.ArrayIntExtension.MergeSort(testarr);

            // assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void MergeSort_EmptyArray_ArgumentExceptionExpected()
        {
            // arrange
            int[] testarr = {};

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
            int[] testarr = {69};
            int[] expected = {69};

            // act
            int[] actual = Algorithms.ArrayIntExtension.MergeSort(testarr);

            //assert
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
            int[] actual = Algorithms.ArrayIntExtension.Quicksort(testarr, 0, testarr.Length - 1);

            // assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuickSort_2Numbers_SortedExpected()
        {
            // arrange
            int[] testarr = { 11, -55 };
            int[] expected = { -55, 11 };

            // act
            int[] actual = Algorithms.ArrayIntExtension.Quicksort(testarr, 0, testarr.Length - 1);

            // assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuickSort_10PosAndNegNumbers_SortedExpected()
        {
            // arrange
            int[] testarr = { 4, 2, 1, 5, 74, 23, 7, -7, 0, 1 };
            int[] expected = { -7, 0, 1, 1, 2, 4, 5, 7, 23, 74 };

            // act
            int[] actual = Algorithms.ArrayIntExtension.Quicksort(testarr, 0, testarr.Length - 1);

            // assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void QuickSort_NullArray_ArgumentNullExceptionExpected()
        {
            // arrange
            int[] testarr = null;

            // act
            int[] actual = Algorithms.ArrayIntExtension.Quicksort(testarr, 0, 5);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void QuickSort_EmptyArray_ArgumentExceptionExpected()
        {
            // arrange
            int[] testarr = { };

            // act
            int[] actual = Algorithms.ArrayIntExtension.Quicksort(testarr, 0, 5);
        }
    }
}
