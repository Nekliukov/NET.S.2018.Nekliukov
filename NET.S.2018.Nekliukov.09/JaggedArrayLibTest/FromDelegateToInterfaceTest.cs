using NUnit.Framework;
using JaggedArrayLib;
using System.Linq;
using System;

namespace JaggedArrayLibTest
{
    /// <summary>
    /// In one of not displayed test cases on value = int.MinValue in random subarray
    /// accures an non 100% situation. Should we throw an exception in case of overflow? Or it's
    /// should be a normal thing, that happens because of machine peculiar properties (fixed size of int)
    /// </summary>
    [TestFixture]
    public class FromDelegateToInterfaceTest
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

        private readonly int[][] wrongEmptyArray = { };
        #endregion

        #region Test Cases
        [Test]
        public void FromDelegateToInterface_SortByMaxUp()
        {
            int[][] ExpectedResult = new int[][]{
                new int[] { 2, 4, 1, 3, -1000, 4, 2, 1 }, // Max = 4
                new int[] { 3, 6, 4, 9, 4 },              // Max = 9
                new int[] { 9, 11, 5 },                   // Max = 11
            };

            Comparers.CompareByMaxUp maxUpComp = new Comparers.CompareByMaxUp();
            FromDelegateToInterface.BubbleSort(testArray, maxUpComp.Compare);
            CollectionAssert.AreEqual(testArray, ExpectedResult);

            FromDelegateToInterface.BubbleSort(testArray, new Comparers.CompareByMaxUp());
            CollectionAssert.AreEqual(testArray, ExpectedResult);
        }

        [Test]
        public void FromDelegateToInterface_SortByMaxDown()
        {
            int[][] ExpectedResult = new int[][]{
                new int[] { 9, 11, 5},                    // Max = 11
                new int[] { 3, 6, 4, 9, 4 },              // Max = 9
                new int[] { 2, 4, 1, 3, -1000, 4, 2, 1 }, // Max = 4
            };

            Comparers.CompareByMaxDown maxDownComp = new Comparers.CompareByMaxDown();
            FromDelegateToInterface.BubbleSort(testArray, maxDownComp.Compare);
            CollectionAssert.AreEqual(testArray, ExpectedResult);

            FromDelegateToInterface.BubbleSort(testArray, new Comparers.CompareByMaxDown());
            CollectionAssert.AreEqual(testArray, ExpectedResult);
        }

        [Test]
        public void FromDelegateToInterface_SortByMinUp()
        {
            int[][] ExpectedResult = new int[][]{
                new int[] { 2, 4, 1, 3, -1000, 4, 2, 1 }, // Min = -1000
                new int[] { 3, 6, 4, 9, 4 },              // Min = 3
                new int[] { 9, 11, 5},                    // Min = 5
            };

            Comparers.CompareByMinUp minUpComp = new Comparers.CompareByMinUp();
            FromDelegateToInterface.BubbleSort(testArray, minUpComp.Compare);
            CollectionAssert.AreEqual(testArray, ExpectedResult);

            FromDelegateToInterface.BubbleSort(testArray, new Comparers.CompareByMinUp());
            CollectionAssert.AreEqual(testArray, ExpectedResult);
        }

        [Test]
        public void FromDelegateToInterface_SortByMinDown()
        {
            int[][] ExpectedResult = new int[][]{
                new int[] { 9, 11, 5},                    // Min = 5
                new int[] { 3, 6, 4, 9, 4 },              // Min = 3
                new int[] { 2, 4, 1, 3, -1000, 4, 2, 1 }, // Min = -1000
            };

            Comparers.CompareByMinDown minDownComp = new Comparers.CompareByMinDown();
            FromDelegateToInterface.BubbleSort(testArray, minDownComp.Compare);
            CollectionAssert.AreEqual(testArray, ExpectedResult);

            FromDelegateToInterface.BubbleSort(testArray, new Comparers.CompareByMinDown());
            CollectionAssert.AreEqual(testArray, ExpectedResult);
        }

        [Test]
        public void FromDelegateToInterface_SortBySumUp()
        {
            int[][] ExpectedResult = new int[][]{
                new int[] { 2, 4, 1, 3, -1000, 4, 2, 1 }, // Sum = -983
                new int[] { 9, 11, 5},                    // Sum = 25
                new int[] { 3, 6, 4, 9, 4 },              // Sum = 26
            };

            Comparers.CompareBySumUp sumUpComp = new Comparers.CompareBySumUp();
            FromDelegateToInterface.BubbleSort(testArray, sumUpComp.Compare);
            CollectionAssert.AreEqual(testArray, ExpectedResult);

            FromDelegateToInterface.BubbleSort(testArray, new Comparers.CompareBySumUp());
            CollectionAssert.AreEqual(testArray, ExpectedResult);
        }

        [Test]
        public void FromDelegateToInterface_SortBySumDown()
        {
            int[][] ExpectedResult = new int[][]{
                new int[] { 3, 6, 4, 9, 4 },              // Max = 26
                new int[] { 9, 11, 5},                    // Max = 25
                new int[] { 2, 4, 1, 3, -1000, 4, 2, 1 }, // Max = -983
            };

            Comparers.CompareBySumDown sumDownComp = new Comparers.CompareBySumDown();
            FromDelegateToInterface.BubbleSort(testArray, sumDownComp.Compare);
            CollectionAssert.AreEqual(testArray, ExpectedResult);

            FromDelegateToInterface.BubbleSort(testArray, new Comparers.CompareBySumDown());
            CollectionAssert.AreEqual(testArray, ExpectedResult);
        }

        [Test]
        public void FromDelegateToInterface_WrongArrayNullTest()
            => Assert.Throws<ArgumentNullException>(()
                => FromDelegateToInterface.BubbleSort(wrongNullArray,
                    (int[] a, int[] b) => a.Sum() - b.Sum()));

        [Test]
        public void FromDelegateToInterface_WrongArrayEmptyTest()
            => Assert.Throws<ArgumentException>(()
                => FromDelegateToInterface.BubbleSort(wrongEmptyArray,
                    (int[] a, int[] b) => a.Sum() - b.Sum()));
    }
    #endregion
}
