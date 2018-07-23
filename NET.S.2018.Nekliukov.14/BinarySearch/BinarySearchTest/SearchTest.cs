using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace BinarySearchTest
{
    [TestFixture]
    public class SearchTest
    {
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 2, ExpectedResult = 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 88, ExpectedResult = null)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, -9, ExpectedResult = null)]
        [TestCase(new int[] { int.MinValue, -2345, -124, 0, 222, 12445, 12445, int.MaxValue }, 222, ExpectedResult = 4)]
        [TestCase(new int[] { int.MinValue, -2345, -124, 0, 222, 12445, 12445, int.MaxValue }, -2345, ExpectedResult = 1)]
        [TestCase(new int[] { int.MinValue, -2345, -124, 0, 222, 12445, 12445, int.MaxValue }, int.MinValue, ExpectedResult = 0)]
        [TestCase(new int[] { int.MinValue, -2345, -124, 0, 222, 12445, 12445, int.MaxValue }, int.MaxValue, ExpectedResult = 7)]
        [TestCase(new int[] { int.MinValue, -2345, -124, 0, 222, 12445, 12445, int.MaxValue }, 12445, ExpectedResult = 6)]
        public int? TestSearchInt(int[] array, int value)
            => BinarySearchLib.Search<int>.Binary(array, value, Comparer<int>.Default.Compare);

        [TestCase(new double[] { 1.345, 2.12, 3.999, 4.5, 5.0, 6.1, 7.69 }, 2, ExpectedResult = null)]
        [TestCase(new double[] { 1.345, 2.12, 3.999, 4.5, 5.0, 6.1, 7.69 }, 2.12, ExpectedResult = 1)]
        public int? TestSearchDouble(double[] array, double value)
            => BinarySearchLib.Search<double>.Binary(array, value, Comparer<double>.Default.Compare);

        [TestCase(new bool[] { false, false, false, false }, true, ExpectedResult = null)]
        [TestCase(new bool[] { false, false, false, false, true }, true, ExpectedResult = 4)]
        public int? TestSearchBool(bool[] array, bool value)
            => BinarySearchLib.Search<bool>.Binary(array, value, Comparer<bool>.Default.Compare);

        [TestCase(new string[] { "Andrew", "Bart", "Bogdan", "Jeffrey", "John", "Roman", "Zane" }, "Roman", ExpectedResult = 5)]
        [TestCase(new string[] { "Andrew", "Bart", "Bogdan", "Jeffrey", "John", "Roman", "Zane" }, "Albahari", ExpectedResult = null)]
        public int? TestSearchBool(string[] array, string value)
            => BinarySearchLib.Search<string>.Binary(array, value, Comparer<string>.Default.Compare);

        [TestCase]
        public void TestSearchCustomClass()
        {
            TimerTest.Student[] students = new TimerTest.Student[] {
                new TimerTest.Student("Bart de Smet"),
                new TimerTest.Student("Herbert Schildt"),
                new TimerTest.Student("John Skeet"),              
                new TimerTest.Student("Roman Nekliukov")
            };

            TimerTest.Student value = new TimerTest.Student("Roman Nekliukov");
            int StudentsComparer(TimerTest.Student lhs, TimerTest.Student rhs)
            {
                return Comparer<string>.Default.Compare(lhs.Name, rhs.Name);
            }

            Assert.AreEqual(3, BinarySearchLib.Search<TimerTest.Student>.Binary(students, value, StudentsComparer));
        }

        [TestCase(new int[] {}, 2)]
        public void TestSearchIntArgException(int[] array, int value)
            => Assert.Throws<ArgumentException>(()=>
            BinarySearchLib.Search<int>.Binary(array, value, Comparer<int>.Default.Compare));

        [TestCase(new string[] { "Andrew", "Bart", "Bogdan", "Jeffrey", "John", "Roman", "Zane" }, null)]
        [TestCase(null, "Albahari")]
        public void TestSearchStringArgNullExcpetion(string[] array, string value)
            => Assert.Throws<ArgumentNullException>(() => 
            BinarySearchLib.Search<string>.Binary(array, value, Comparer<string>.Default.Compare));
    }     
}
