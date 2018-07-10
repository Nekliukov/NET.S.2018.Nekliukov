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
            return p3.GetCoefs();
        }

        [TestCase(new double[] { 1.25, 2, 3.55 }, new double[] { 1.25, 2, 3.55 }, ExpectedResult = true)]
        [TestCase(new double[] { int.MaxValue, 0 }, new double[] { int.MaxValue, 0 }, ExpectedResult = true)]
        [TestCase(new double[] { 12, 0.000000000004 }, new double[] { 12, 0.0 }, ExpectedResult = true)]
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
        [TestCase(new double[] { 12, 0.000000000004 }, new double[] { 12, 0.0 }, ExpectedResult = false)]
        [TestCase(new double[] { 2, 3, 4 }, new double[] { 0 }, ExpectedResult = true)]
        [TestCase(new double[] { 2, 3, 4 }, new double[] { 2, 3, 4.5 }, ExpectedResult = true)]
        [TestCase(new double[] { 0, -0, 2 }, new double[] { 0, +0, 2 }, ExpectedResult = false)]
        public static bool NotEqualOperationTest(double[] firstCoefs, double[] secondCoefs)
        {
            Polynomial p1 = new Polynomial(firstCoefs);
            Polynomial p2 = new Polynomial(secondCoefs);
            return p1 != p2;
        }

        [TestCase(new double[] { 1, 2, 3 }, new double[] {2, 3, 4 }, ExpectedResult = new double[] { 2, 7, 16, 17, 12})]
        [TestCase(new double[] { 1d, 2d }, new double[] { 1d, 2d, 3d }, ExpectedResult = new double[] { 1d, 4d, 7d, 6d })]
        [TestCase(
            new double[] { 15.5, -27.1, 0.0, 0.0, 345.223 },
            new double[] { 35, 0.0, 1, 56 },
            ExpectedResult = new double[] { 542.5, -948.5, 15.5, 840.9, 10565.205, 0.0, 345.223, 19332.488 })]
        public static double[] MulTestPvsP(double[] firstCoefs, double[] secondCoefs)
        {
            Polynomial p1 = new Polynomial(firstCoefs);
            Polynomial p2 = new Polynomial(secondCoefs);
            Polynomial p3 = p1 * p2;
            return p3.GetCoefs();
        }

        [TestCase(new double[] { 1, 2, 3 }, 6.0, ExpectedResult = new double[] { 6, 12, 18})]
        [TestCase(new double[] { 0.0, 2.5, 100 }, 0.5, ExpectedResult = new double[] { 0, 1.25, 50 })]
        public static double[] MulTestPvsN(double[] firstCoefs, double number)
        {
            Polynomial p1 = new Polynomial(firstCoefs);
            Polynomial p2 = p1 * number;
            return p2.GetCoefs();
        }
    }
}
