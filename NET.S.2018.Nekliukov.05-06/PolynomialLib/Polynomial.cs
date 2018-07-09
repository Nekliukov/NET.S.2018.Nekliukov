using System;

namespace PolynomialLib
{
    /// <summary>
    /// Class that represents a polynomial abstraction and
    /// provides some methods to work with it
    /// </summary>
    /// <seealso cref="System.ICloneable" />
    /// <seealso cref="PolynomialLib.IEquatable" />
    public sealed class Polynomial: ICloneable, IEquatable<Polynomial>
    {
        #region Constants
        private const double EPSILON = 1e-10;
        #endregion

        #region Private fields
        private double[] coefficents;
        private int degree;
        #endregion

        #region Public API        
        /// <summary>
        /// Initializes a new instance of the <see cref="Polynomial"/> class.
        /// </summary>
        /// <param name="coefficents">The coefficents.</param>
        public Polynomial(params double[] coefficents)
        {
            if (coefficents == Array.Empty<double>())
            {
                throw new ArgumentException("There are no coeffiecents to create a polynomial");
            }

            this.coefficents = coefficents ?? throw new
                ArgumentNullException("Array of coefficents can't be equal to null");
        }


        #region Properties        
        public int CoefCount { get => coefficents.Length; private set { } }
        #endregion

            /// <summary>
            /// Returns value copy of Polynomial's coefficents.
            /// </summary>
            /// <returns>Value copy of Polynomial's coefficents</returns>
        public double[] GetCoefs()
        {
            double[] resultCoefs = new double[CoefCount];
            Array.Copy(coefficents, resultCoefs, CoefCount);
            return resultCoefs;
        }

        #region Overloaded operations        

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="lhs">The first polynomial.</param>
        /// <param name="rhs">The second polynomial.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Polynomial operator + (Polynomial lhs, Polynomial rhs)
        {
            Polynomial resultPoly = FindBiggerPolynomial(lhs, rhs);

            for (int i = 0; i < resultPoly.CoefCount; i++)
            {
                try
                {
                    resultPoly.coefficents[i] = lhs.coefficents[i] + rhs.coefficents[i];
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
        /// <param name="poly">The polynomial.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Polynomial operator - (Polynomial poly)
        {
            Polynomial resultPoly = poly.Clone();
            for (int i = 0; i < resultPoly.CoefCount; i++)
            {
                resultPoly.coefficents[i] *= -1;
            }
            return resultPoly;
        }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="lhs">The first polynomial.</param>
        /// <param name="rhs">The second polynomial.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Polynomial operator -(Polynomial lhs, Polynomial rhs) => -(lhs + rhs);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="lhs">The first polynomial.</param>
        /// <param name="rhs">The second polynomial.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator == (Polynomial lhs, Polynomial rhs)
        {
            if (lhs.CoefCount != lhs.CoefCount)
            {
                return false;
            }

            for (int i = 0; i < lhs.CoefCount; i++)
            {
                if (Math.Abs(lhs.coefficents[i] - rhs.coefficents[i]) > EPSILON)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="lhs">The first polynomial.</param>
        /// <param name="rhs">The second polynomial.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(Polynomial lhs, Polynomial rhs)
            => !(lhs == rhs);

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
            return string.Concat(resultPoly, Convert.ToString(Math.Abs(coefficents[0])));
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
            if (this.GetType() != obj.GetType() || obj == null)
            {
                return false;
            }

            Polynomial p = (Polynomial)obj;

            return this == p;
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

        #region Indexer        
        /// <summary>
        /// Gets the <see cref="System.Double"/> at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="System.Double"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns>Coefficent at the specified index</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Index out of range
        /// </exception>
        public double this[int index]
        {
            get
            {
                if (index < 0 || index >= this.coefficents.Length)
                {
                    throw new ArgumentOutOfRangeException("Index out of range");
                }

                return coefficents[index];
            }

            private set
            {
                if (index < 0 || index >= this.coefficents.Length)
                {
                    throw new ArgumentOutOfRangeException("Index out of range");
                }

                coefficents[index] = value;
            }
        }

        #endregion
        #endregion

        #region IClone implementation  
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>New instance</returns>
        public Polynomial Clone() => new Polynomial(this.coefficents);

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        object ICloneable.Clone() => this.Clone();
        #endregion

        #region IEquatable implementation

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        public bool Equals(Polynomial other) => this == other;

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
