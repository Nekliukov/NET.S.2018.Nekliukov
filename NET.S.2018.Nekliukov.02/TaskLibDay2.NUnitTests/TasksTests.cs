using System;
using NUnit.Framework;
using TasksLibDay2;

namespace TaskLibDay2.NUnitTests
{
    [TestFixture]
    public class TasksTests
    {
        [Test]
        public void FilterDigits_7RandomNumbers_FilteredArrayReturned()
        { 
            int[] expected = { 45, 53, 55, 5 };
            int[] actual = Tasks.FilterDigit(5, 45, 12, 53, 23, 55, 12, 5);
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void FilterDigits_7RandomNumbers_EmptyReturnedExpected()
        {
            int[] expected = { };
            int[] actual = Tasks.FilterDigit(9, 45, 12, 53, 23, 55, 12, 5);
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void FilterDigits_WithNull_ThrowArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => Tasks.FilterDigit(3, null));

        [Test]
        public void FilterDigits_WithEmptyArray_ThrowArgumentException()
            => Assert.Throws<ArgumentException>(() => Tasks.FilterDigit(3));

        [TestCase(12)]
        [TestCase(-5)]
        public void FilterDigits_OutOfRangeDigits_ThrowOutOfRangeArgException(int value)
        {
            Assert.Throws<ArgumentOutOfRangeException>(()
                => Tasks.FilterDigit(value, 45, 12, 53, 23, 55, 12, 5));
        }

        [Test]
        public void InsertNumber_Source15In15From0To0_15Expected()
        {
            int expected = 15;
            int actual = Tasks.InsertNumber(15, 15, 0, 0);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void InsertNumber_Source8In15From0To0_9Expected()
        {
            int expected = 9;
            int actual = Tasks.InsertNumber(8, 15, 0, 0);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void InsertNumber_Source8In15From3To8_120Expected()
        {
            int expected = 120;
            int actual = Tasks.InsertNumber(8, 15, 3, 8);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void InsertNumber_OutOfRangeArgs_ThrowOutOfRangeArgException()
            => Assert.Throws<ArgumentOutOfRangeException>(() => Tasks.InsertNumber(15, 9, 3, 55));
        [Test]
        public void InsertNumber_ArgumentPositionIsNotIn0to31_ThrowArgException()
            => Assert.Throws<ArgumentException>(() => Tasks.InsertNumber(15, 9, 15, 3));
    }
}
