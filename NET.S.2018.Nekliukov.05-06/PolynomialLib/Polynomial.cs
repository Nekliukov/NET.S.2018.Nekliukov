using System;

namespace PolynomialLib
{
    public class Polynomial
    {
        #region Constants
        private const double EPSILON = double.Epsilon;
        #endregion

        #region Private fields
        private double[] coefficents;
        #endregion

        #region Public API        
        /// <summary>
        /// Initializes a new instance of the <see cref="Polynomial"/> class.
        /// </summary>
        /// <param name="coefficents">The coefficents.</param>
        public Polynomial(double[] coefficents) => this.Coefficents = coefficents;

        #region Properties        
        /// <summary>
        /// Gets the coefficents.
        /// </summary>
        /// <value>
        /// The coefficents.
        /// </value>
        /// <exception cref="System.ArgumentException">There are no coeffiecents to create a polynomial</exception>
        /// <exception cref="System.ArgumentNullException">Array of coefficents can't be equal to null</exception>
        public double[] Coefficents
        {
            get
            {
                return coefficents;
            }

            private set
            {
                if (value == Array.Empty<double>())
                {
                    throw new ArgumentException("There are no coeffiecents to create a polynomial");
                }

                coefficents = value ?? throw new
                    ArgumentNullException("Array of coefficents can't be equal to null");
            }
        }

        public int CoefCount { get => coefficents.Length; private set { } }
        #endregion

        #region Overloaded operations        
        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="firstPoly">The first polynomial.</param>
        /// <param name="secondPoly">The second polynomial.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Polynomial operator + (Polynomial firstPoly, Polynomial secondPoly)
        {
            Polynomial resultPoly = FindBiggerPolynomial(firstPoly, secondPoly);

            for (int i = 0; i < resultPoly.CoefCount; i++)
            {
                try
                {
                    resultPoly.coefficents[i] = firstPoly.coefficents[i] + secondPoly.coefficents[i];
                }
                catch (IndexOutOfRangeException)
                {
                    break;
                }
            }

            return resultPoly;
        }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="firstPoly">The first polynomial.</param>
        /// <param name="secondPoly">The second polynomial.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Polynomial operator - (Polynomial firstPoly, Polynomial secondPoly)
        {
            Polynomial resultPoly = FindBiggerPolynomial(firstPoly, secondPoly);

            for (int i = 0; i < resultPoly.coefficents.Length; i++)
            {
                try
                {
                    resultPoly.coefficents[i] = firstPoly.coefficents[i] - secondPoly.coefficents[i];
                }
                catch (IndexOutOfRangeException)
                {
                    break;
                }
            }

            return resultPoly;
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="firstPoly">The first polynomial.</param>
        /// <param name="secondPoly">The second polynomial.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator == (Polynomial firstPoly, Polynomial secondPoly)
        {
            if (firstPoly.CoefCount != firstPoly.CoefCount)
            {
                return false;
            }

            for (int i = 0; i < firstPoly.CoefCount; i++)
            {
                if (Math.Abs(firstPoly.coefficents[i] - secondPoly.coefficents[i]) > EPSILON)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="firstPoly">The first polynomial.</param>
        /// <param name="secondPoly">The second polynomial.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(Polynomial firstPoly, Polynomial secondPoly)
            => !(firstPoly == secondPoly);
        #endregion

        #region Overriden methods         
        /// <summary>
        /// Returns <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            string resultPoly = string.Empty, sign;

            for (int i = CoefCount - 1; i > 0; i--)
            {
                if (coefficents[i] == 0)
                {
                    continue;
                }

                sign = (coefficents[i - 1] >= 0) ? " + " : " - ";
                resultPoly = string.Concat(
                    resultPoly,
                    Convert.ToString(Math.Abs(coefficents[i])),
                    "*x^",
                    Convert.ToString(i),
                    sign);
            }

            resultPoly = (coefficents[CoefCount - 1] < 0) ? resultPoly.Insert(0, "-") : resultPoly;
            return string.Concat(resultPoly, Convert.ToString(Math.Abs(Coefficents[0])));
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance;
        ///   otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Polynomial))
            {
                return false;
            }

            Polynomial polyToCompare = obj as Polynomial;
            if (polyToCompare.GetHashCode() == this.GetHashCode())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms
        /// and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;

                // get hash code for all items in array
                foreach (var item in coefficents)
                {
                    hash = (hash * 23) + item.GetHashCode();
                }

                return hash;
            }
        }
        #endregion

        #endregion

        #region Private API
        private static Polynomial FindBiggerPolynomial(Polynomial firstPoly, Polynomial secondPoly)
        {
            int firstLen = firstPoly.CoefCount,
                secondLen = secondPoly.CoefCount;
            int maxLen = (firstLen >= secondLen) ? firstLen : secondLen;
            double[] resultCoefs = new double[maxLen];
            if (firstLen >= secondLen)
            {
                Array.Copy(firstPoly.coefficents, resultCoefs, firstLen);
            }
            else
            {
                Array.Copy(secondPoly.coefficents, resultCoefs, secondLen);
            }

            return new Polynomial(resultCoefs);
        }
        #endregion
    }
}
