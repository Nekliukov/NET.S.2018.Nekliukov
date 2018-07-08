using NUnit.Framework;
using PolynomialLib;

namespace PolynomialLibTest
{
    [TestFixture]
    public class PolynomialTests
    {
        [TestCase(new double[] { 4, 1, 63, 0, 5 }, ExpectedResult = "4*x^4 + 1*x^3 + 63*x^2 + 5")]
        [TestCase(new double[] { 4, 1, -63, 6, 5 }, ExpectedResult = "4*x^4 + 1*x^3 - 63*x^2 + 6*x^1 + 5")]
        [TestCase(new double[] { -4, -1, -63, 6, -5 }, ExpectedResult = "-4*x^4 - 1*x^3 - 63*x^2 + 6*x^1 - 5")]
        [TestCase(new double[] { 0, 0, 6}, ExpectedResult = "6")]
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
    }
}
