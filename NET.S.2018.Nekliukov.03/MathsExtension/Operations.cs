using System;

namespace MathsExtension
{
    public class Operations
    {
        /// <summary>
        /// Method for evaluating of the fractional numbers Nth degree root
        /// </summary>
        /// <param name="number">Number under root</param>
        /// <param name="degree">Root's degree</param>
        /// <param name="precision">Eps of the evaluation</param>
        /// <returns>Nth degree root</returns>
        /// <exception cref="ArgumentException">Thrown when degree is lower than 2</exception>
        /// <exception cref="ArgumentException">Thrown when precision is lower
        /// than or equal to 0</exception>
        /// <exception cref="ArgumentException">Thrown when you try to take odd
        /// degree root of negative number</exception>
        public static double FindNthRoot(double number, int degree, double precision)
        {
            if (degree < 2)
            {
                throw new ArgumentException();
            }

            if (precision <= 0)
            {
                throw new ArgumentException();
            }

            if (number < 0 && degree % 2 == 0)
            {
                throw new ArgumentException();
            }

            double res = number / 2;
            double prev = 0;
            while (Math.Abs(prev - res) >= precision)
            {
                prev = res;
                //// iteration rule of the Newton's method
                res = (1.0 / degree) * ((degree - 1) * res + number /
                    Math.Pow(res, degree - 1));
            }

            return res;
        }
    }
}
