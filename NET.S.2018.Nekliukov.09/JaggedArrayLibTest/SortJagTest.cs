using NUnit.Framework;
using JaggedArrayLib;
using System;

namespace JaggedArrayLibTest
{
    /// <summary>
    /// In one of not displayed test cases on value = int.MinValue in random subarray
    /// accures an non 100% situation. Should we throw an exception in case of overflow? Or it's
    /// should be a normal thing, that happens because of machine peculiar properties (fixed size of int)
    /// </summary>
    [TestFixture]
    public class SortJagTest
    {
        #region Input data
        private readonly int[][] testArray =
             {
                new int[] { 9, 11, 5},                    // Max = 11, Min = 5,     Sum = 25
                new int[] { 2, 4, 1, 3, -1000, 4, 2, 1 }, // Max = 4,  Min = -1000, Sum = -983
                new int[] { 3, 6, 4, 9, 4 },              // Max = 9,  Min = 3,     Sum = 26
            };

        private readonly int[][] wrongNullArray =
             {
                null,                 
                new int[] { 2, 4, 1, 3, -1000, 4, 2, 1 }, 
                new int[] { 3, 6, 4, 9, 4 },           
            };

        private readonly int[][] wrongEmptyArray ={ };
        #endregion

        #region Test Cases
        [Test]
        public void SortByMaxUp()
        {
            int[][] ExpectedResult = new int[][]{
                new int[] { 2, 4, 1, 3, -1000, 4, 2, 1 }, // Max = 4
                new int[] { 3, 6, 4, 9, 4 },              // Max = 9
                new int[] { 9, 11, 5 },                   // Max = 11
            };

            SortJag.BubbleSort(testArray, new Comparers.CompareByMaxUp());
            CollectionAssert.AreEqual(testArray, ExpectedResult);
            // Default sorting equals to sorting by max values of rows, also checks it here
            SortJag.BubbleSort(testArray);
            CollectionAssert.AreEqual(testArray, ExpectedResult);
        }

        [Test]
        public void SortByMaxDown()
        {
            int[][] ExpectedResult = new int[][]{
                new int[] { 9, 11, 5},                    // Max = 11
                new int[] { 3, 6, 4, 9, 4 },              // Max = 9
                new int[] { 2, 4, 1, 3, -1000, 4, 2, 1 }, // Max = 4
            };

            SortJag.BubbleSort(testArray, new Comparers.CompareByMaxDown());
            CollectionAssert.AreEqual(testArray, ExpectedResult);
        }

        [Test]
        public void SortByMinUp()
        {
            int[][] ExpectedResult = new int[][]{
                new int[] { 2, 4, 1, 3, -1000, 4, 2, 1 }, // Min = -1000
                new int[] { 3, 6, 4, 9, 4 },              // Min = 3
                new int[] { 9, 11, 5},                    // Min = 5
            };

            SortJag.BubbleSort(testArray, new Comparers.CompareByMinUp());
            CollectionAssert.AreEqual(testArray, ExpectedResult);
        }

        [Test]
        public void SortByMinDown()
        {
            int[][] ExpectedResult = new int[][]{
                new int[] { 9, 11, 5},                    // Min = 5
                new int[] { 3, 6, 4, 9, 4 },              // Min = 3
                new int[] { 2, 4, 1, 3, -1000, 4, 2, 1 }, // Min = -1000
            };

            SortJag.BubbleSort(testArray, new Comparers.CompareByMinDown());
            CollectionAssert.AreEqual(testArray, ExpectedResult);
        }

        [Test]
        public void SortBySumUp()
        {
            int[][] ExpectedResult = new int[][]{
                new int[] { 2, 4, 1, 3, -1000, 4, 2, 1 }, // Sum = -983
                new int[] { 9, 11, 5},                    // Sum = 25
                new int[] { 3, 6, 4, 9, 4 },              // Sum = 26
            };

            SortJag.BubbleSort(testArray, new Comparers.CompareBySumUp());
            CollectionAssert.AreEqual(testArray, ExpectedResult);
        }

        [Test]
        public void SortBySumDown()
        {
            int[][] ExpectedResult = new int[][]{
                new int[] { 3, 6, 4, 9, 4 },              // Max = 26
                new int[] { 9, 11, 5},                    // Max = 25
                new int[] { 2, 4, 1, 3, -1000, 4, 2, 1 }, // Max = -983
            };

            SortJag.BubbleSort(testArray, new Comparers.CompareBySumDown());
            CollectionAssert.AreEqual(testArray, ExpectedResult);
        }

        [Test]
        public void WrongArrayNullTest()
            => Assert.Throws<ArgumentNullException>(()=>SortJag.BubbleSort(wrongNullArray));

        [Test]
        public void WrongArrayEmptyTest()
            => Assert.Throws<ArgumentException>(() => SortJag.BubbleSort(wrongEmptyArray));
        #endregion
    }
}
