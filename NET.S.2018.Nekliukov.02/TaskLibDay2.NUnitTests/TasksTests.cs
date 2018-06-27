using System;
using NUnit.Framework;
using TasksLibDay2;

namespace TaskLibDay2.NUnitTests
{
    [TestFixture]
    public class TasksTests {

        [Test]
        public void FilterDigits_7RandomNumbers_FilteredArrayReturned() {
            int[] init = { 45, 12, 53, 23, 55, 12, 5 };
            int[] expected = { 45, 53, 55, 5 };
            int[] actual = Tasks.FilterDigit(init, 5);
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void FilterDigits_7RandomNumbers_EmptyReturnedExpected() {
            int[] init = { 45, 12, 53, 23, 55, 12, 5 };
            int[] expected = { };
            int[] actual = Tasks.FilterDigit(init, 9);
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void FilterDigits_WithNull_ThrowArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => Tasks.FilterDigit(null, 3));

        [Test]
        public void FilterDigits_WithEmptyArray_ThrowArgumentException() {
            int[] init = { };
            Assert.Throws<ArgumentException>(() => Tasks.FilterDigit(init, 3));
        }

        [TestCase(12)]
        [TestCase(-5)]
        public void FilterDigits_OutOfRangeDigits_ThrowOutOfRangeArgException(int value) {
            int[] init = { 45, 12, 53, 23, 55, 12, 5 };
            Assert.Throws<ArgumentOutOfRangeException>(() => Tasks.FilterDigit(init, value));
        }
    }
}
