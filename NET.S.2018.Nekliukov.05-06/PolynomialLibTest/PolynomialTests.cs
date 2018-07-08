using NUnit.Framework;
using PolynomialLib;

namespace PolynomialLibTest
{
    [TestFixture]
    public class PolynomialTests
    {
        [TestCase(new double[] { 4, 1, 63, 0, 5 }, ExpectedResult = "5*x^4 + 63*x^2 + 1*x^1 + 4")]
        [TestCase(new double[] { 4, 1, -63, 6, 5 }, ExpectedResult = "5*x^4 + 6*x^3 - 63*x^2 + 1*x^1 + 4")]
        [TestCase(new double[] { -4, -1, -63, 6, -5 }, ExpectedResult = "-5*x^4 + 6*x^3 - 63*x^2 - 1*x^1 - 4")]
        [TestCase(new double[] { 6, 0, 6}, ExpectedResult = "6*x^2 + 6")]
        public static string ToStringTest(double[] coefs)
        {
            Polynomial p = new Polynomial(coefs);
            return p.ToString();
        }

        [TestCase(new double[] { 4, 1, 63, 0, 5 }, new double[] { 4, 1, 63, 0, 5 }, ExpectedResult = true)]
        [TestCase(new double[] { 63, 0, 5 }, new double[] { 69, 45 }, ExpectedResult = false)]
        [TestCase(new double[] { 1, 2, 3 }, new double[] { 3, 2, 1 }, ExpectedResult = false)]
        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 2, -3 }, ExpectedResult = false)]
        [TestCase(new double[] { 1, 2.001, 3 }, new double[] { 1, 2, 3 }, ExpectedResult = false)]
        public static bool EqualTest(double[] firstCoefs, double[] secondCoefs)
        {
            Polynomial p1 = new Polynomial(firstCoefs);
            Polynomial p2 = new Polynomial(secondCoefs);
            return p1.Equals(p2);
        }

        [TestCase(new double[] { 3, 5, 7 }, new double[] { 1, 2, 3 },
            ExpectedResult = new double[] { 4, 7, 10 })]
        [TestCase(new double[] { 3, 5, 7, 8 }, new double[] { 1, 2, 3 },
            ExpectedResult = new double[] { 4, 7, 10, 8 })]
        [TestCase(new double[] { -5, 4 }, new double[] { -8, -5, int.MaxValue },
            ExpectedResult = new double[] { -13, -1, int.MaxValue })]
        public static double[] SumTest(double[] firstCoefs, double[] secondCoefs)
        {
            Polynomial p1 = new Polynomial(firstCoefs);
            Polynomial p2 = new Polynomial(secondCoefs);
            Polynomial p3 = p1 + p2;
            return p3.Coefficents;
        }

        [TestCase(new double[] { 1.25, 2, 3.55 }, new double[] { 1.25, 2, 3.55 }, ExpectedResult = true)]
        [TestCase(new double[] { int.MaxValue, 0 }, new double[] { int.MaxValue, 0 }, ExpectedResult = true)]
        [TestCase(new double[] { 12, 0.000000000004 }, new double[] { 12, 0.0 }, ExpectedResult = false)]
        [TestCase(new double[] { 2, 3, 4 }, new double[] { 0 }, ExpectedResult = false)]
        [TestCase(new double[] { 0, -0, 2 }, new double[] { 0, +0, 2 }, ExpectedResult = true)]
        public static bool EqualOperationTest(double[] firstCoefs, double[] secondCoefs)
        {
            Polynomial p1 = new Polynomial(firstCoefs);
            Polynomial p2 = new Polynomial(secondCoefs);
            return p1 == p2;
        }

        [TestCase(new double[] { 1.25, 2, 3.55 }, new double[] { 1.25, 2, 3.56 }, ExpectedResult = true)]
        [TestCase(new double[] { int.MaxValue, 0 }, new double[] { int.MaxValue, 0 }, ExpectedResult = false)]
        [TestCase(new double[] { 12, 0.000000000004 }, new double[] { 12, 0.0 }, ExpectedResult = true)]
        [TestCase(new double[] { 2, 3, 4 }, new double[] { 0 }, ExpectedResult = true)]
        [TestCase(new double[] { 2, 3, 4 }, new double[] { 2, 3, 4.5 }, ExpectedResult = true)]
        [TestCase(new double[] { 0, -0, 2 }, new double[] { 0, +0, 2 }, ExpectedResult = false)]
        public static bool NotEqualOperationTest(double[] firstCoefs, double[] secondCoefs)
        {
            Polynomial p1 = new Polynomial(firstCoefs);
            Polynomial p2 = new Polynomial(secondCoefs);
            return p1 != p2;
        }
    }
}
