using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathsExtension.Test
{
    [TestClass]
    public class OperationsTest
    {
        [TestMethod]
        public void FindNthRoot_NumIs1DegreeIs5_1Expected()
            => Assert.AreEqual(1, Operations.FindNthRoot(1, 5, 0.0001), 0.1);

        [TestMethod]
        public void FindNthRoot_NumIs8DegreeIs3_2Expected()
            => Assert.AreEqual(2, Operations.FindNthRoot(8, 3, 0.0001), 0.1);

        [TestMethod]
        public void FindNthRoot_NumIs0p0410025DegreeIs4_0p45Expected()
            => Assert.AreEqual(0.45, actual: Operations.FindNthRoot(0.04100625, 4, 0.0001), delta: 0.01);

        [TestMethod]
        public void FindNthRoot_NumIs0p001DegreeIs3_0p1Expected()
            => Assert.AreEqual(0.1, actual: Operations.FindNthRoot(0.001, 3, 0.0001), delta: 0.1);

        [TestMethod]
        public void FindNthRoot_NumIs0p0279936DegreeIs7_0p6Expected()
            => Assert.AreEqual(0.6, actual: Operations.FindNthRoot(0.0279936, 7, 0.0001), delta: 0.1);

        [TestMethod]
        public void FindNthRoot_NumIs0p0081DegreeIs4_0p3Expected()
            => Assert.AreEqual(0.3, actual: Operations.FindNthRoot(0.0081, 4, 0.00001), delta: 0.1);

        [TestMethod]
        public void FindNthRoot_NumIsMinus0p0410025DegreeIs3_Minus0p2Expected()
            => Assert.AreEqual(-0.2, actual: Operations.FindNthRoot(-0.008, 3, 0.001), delta: 0.1);

        [TestMethod]
        public void FindNthRoot_NumIs0p004241979DegreeIs9_0p545Expected()
            => Assert.AreEqual(0.545, actual: Operations.FindNthRoot(0.004241979, 9, 0.00000001), delta: 0.001);

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void FindNthRoot_Minus0p0_2_0p0001_ArgumentExcpetionExpected()
            => Operations.FindNthRoot(-0.01, 2, 0.0001);

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void FindNthRoot_0p001_Miuns2_0p0001_ArgumentExcpetionExpected()
             => Operations.FindNthRoot(0.001, -2, 0.0001);

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void FindNthRoot_0p01_2_Minus1_ArgumentExcpetionExpected()
            => Operations.FindNthRoot(0.01, 2, -1);

        [TestMethod]
        public void FindNextBiggerNum_12_21Expected()
        {
            Stopwatch sw = new Stopwatch();
            Assert.AreEqual(341, Operations.FindNextBiggerNumber(314, out sw));
        }

        [TestMethod]
        public void FindNextBiggerNum_513_531Expected()
            => Assert.AreEqual(531, Operations.FindNextBiggerNumber(513));

        [TestMethod]
        public void FindNextBiggerNum_3456432_3462345Expected()
            => Assert.AreEqual(3462345, Operations.FindNextBiggerNumber(3456432));

        [TestMethod]
        public void FindNextBiggerNum_2017_2071Expected()
            => Assert.AreEqual(2071, Operations.FindNextBiggerNumber(2017));

        [TestMethod]
        public void FindNextBiggerNum_654321_Minus1Expected()
            => Assert.AreEqual(-1, Operations.FindNextBiggerNumber(654321));

        [TestMethod]
        public void FindNextBiggerNum_1234126_2071Expected()
            => Assert.AreEqual(1234162, Operations.FindNextBiggerNumber(1234126));

        [TestMethod]
        public void FindNextBiggerNum_MAXINT_Minus1Expected()
            => Assert.AreEqual(-1, Operations.FindNextBiggerNumber(int.MaxValue));

        [TestMethod]
        public void FindNextBiggerNum_9_Minus1Expected()
            => Assert.AreEqual(-1, Operations.FindNextBiggerNumber(9));

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void FindNextBiggerNum_Minus5_ArgumentExceptionExpected()
            => Operations.FindNextBiggerNumber(-5);
    }
}
