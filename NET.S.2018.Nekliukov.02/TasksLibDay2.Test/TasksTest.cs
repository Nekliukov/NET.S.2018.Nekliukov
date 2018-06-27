using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TasksLibDay2;

namespace TasksLibDay2.Test
{
    [TestClass]
    public class TasksTest
    {
        [TestMethod]
        public void FilterDigit_7RandomNumbers_3FilteredNumbersExpected()
        {
            // arrange
            int[] test = { 54, 11, 647, 1, 45, 5, 10 };
            int digit = 5;
            int[] expected = { 54, 45, 5 };

            // action
            int[] actual = Tasks.FilterDigit(test, digit);

            // assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FilterDigit_7RandomNumbers_EmptyReturnedArrayExpected()
        {
            // arrange
            int[] test = { 54, 11, 647, 1, 45, 5, 10 };
            int digit = 9;
            int[] expected = {};

            // action
            int[] actual = Tasks.FilterDigit(test, digit);

            // assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void FilterDigit_NullArrayArgument_ArgumentNullExceptionExpected()
        {
            // arrange
            int[] test = null;
            int digit = 5;

            // action
            int[] actual = Tasks.FilterDigit(test, digit);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void FilterDigit_EmptyArrayArgument_ArgumentExceptionExpected()
        {
            // arrange
            int[] test = { };
            int digit = 5;

            // action
            int[] actual = Tasks.FilterDigit(test, digit);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FilterDigit_7RandomNumbersAndNotDigit_ArgumentOutOfRangeExceptionExpected()
        {
            // arrange
            int[] test = { 54, 11, 647, 1, 45, 5, 10 };
            int digit = 12;

            // action
            int[] actual = Tasks.FilterDigit(test, digit);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FilterDigit_7RandomNumbersAndNegativeDigit_ArgumentOutOfRangeExceptionExpected()
        {
            // arrange
            int[] test = { 54, 11, 647, 1, 45, 5, 10 };
            int digit = -5;

            // action
            int[] actual = Tasks.FilterDigit(test, digit);
        }
    }
}
