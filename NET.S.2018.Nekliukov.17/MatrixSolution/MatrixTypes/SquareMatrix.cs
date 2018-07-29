//#define CONTRACTS_FULL

using System;
using System.Collections.Generic;
using System.Windows.Forms;
//using System.Diagnostics.Contracts;
using Microsoft.CSharp.RuntimeBinder;

namespace MatrixTypes
{
    public class SquareMatrix<T>
    {        
        #region Protected field(s)

        private T[,] nativeMatrix;
        protected IComparer<T> comparer;

        private delegate void MethodContainer(int a, int b);

        private event MethodContainer onElementChanging;

        #endregion

        #region Property(ies)

        /// <summary>
        /// Gets the native matrix
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public T[,] Value
        {
            get => nativeMatrix;
            protected set
            {
                MatrixValidation(value);
                nativeMatrix = value;
            }
        }

        #endregion

        #region Indexator

        /// <summary>
        /// Gets or sets the <see cref="T"/> with the specified index i.
        /// </summary>
        /// <value>
        /// The <see cref="T"/>.
        /// </value>
        /// <param name="indexI">The index i.</param>
        /// <param name="indexJ">The index j.</param>
        /// <returns></returns>
        public T this[int indexI, int indexJ]
        {
            get => Value[indexI, indexJ];
            set
            {
                Value[indexI, indexJ] = value;
                onElementChanging?.Invoke(indexI, indexJ);
            }
        }

        #endregion

        #region .Ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:MatrixTypes.SquareMatrix`1" /> class.
        /// </summary>
        /// <param name="dimension">The dimension.</param>
        public SquareMatrix(int dimension): this (dimension, Comparer<T>.Default) {}

        /// <summary>
        /// Initializes a new instance of the <see cref="SquareMatrix{T}"/> class.
        /// </summary>
        /// <param name="initialMatrix">The initial matrix.</param>
        public SquareMatrix(T[,] initialMatrix) : this(initialMatrix, Comparer<T>.Default) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SquareMatrix{T}"/> class.
        /// </summary>
        /// <param name="dimension">The dimension.</param>
        /// <param name="comparer">The comparer.</param>
        /// <exception cref="ArgumentException">Wrong dimension value</exception>
        public SquareMatrix(int dimension, IComparer<T> comparer)
        {
#if CONTRACTS_FULL
            Contract.Requires<ArgumentException>(dimension > 0,
                $"Wrong {nameof(dimension)} value. It must be higher than 0");
#else
            if (dimension <= 0)
            {
                throw new ArgumentException($"Wrong {nameof(dimension)}" +
                     " value. It must be higher than 0");
            }
#endif

            ValidateComparer();
            this.comparer = comparer;

            Value = new T[dimension, dimension];

            ChangeHandler changeHandler = new ChangeHandler();
            onElementChanging += changeHandler.GenerateMessage;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SquareMatrix{T}"/> class.
        /// </summary>
        /// <param name="initialMatrix">The initial matrix.</param>
        /// <param name="comparer">The comparer.</param>
        /// <exception cref="ArgumentNullException">Null matrix value</exception>
        /// <exception cref="ArgumentException">
        /// Empty matrix was sent
        /// or
        /// Matrix is not square type
        /// </exception>
        public SquareMatrix(T[,] initialMatrix, IComparer<T> comparer)
        {
            Value = initialMatrix;
            ValidateComparer();
            this.comparer = comparer;
            ChangeHandler changeHandler = new ChangeHandler();
            onElementChanging += changeHandler.GenerateMessage;    
        }

        #endregion

        #region Overridden methods

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((SquareMatrix<T>)obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return ((nativeMatrix != null ? nativeMatrix.GetHashCode() : 0) * 397)
                       ^ (comparer != null ? comparer.GetHashCode() : 0);
            }
        }

        #endregion

        #region Protected methods

        protected bool Equals(SquareMatrix<T> other)
            => Equals(nativeMatrix, other.nativeMatrix) && Equals(comparer, other.comparer);

        #endregion

        #region Overloaded operation(s)

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static SquareMatrix<T> operator + (SquareMatrix<T> lhs, SquareMatrix<T> rhs)
        {
            ValidatePlusOperator(lhs, rhs);
            SquareMatrix<T> resultMatrix = new SquareMatrix<T>(lhs.Value.GetLength(0));

            for (int i = 0; i < lhs.Value.GetLength(0); i++)
            {
                for (int j = 0; j < lhs.Value.GetLength(1); j++)
                {
                    resultMatrix[i,j] = (dynamic)lhs[i, j] + (dynamic)rhs[i, j];
                }
            }

            return resultMatrix;
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator == (SquareMatrix<T> lhs, SquareMatrix<T> rhs)
        {
            ValidateEqualOperator(lhs, rhs);

            for (int i = 0; i < lhs.Value.GetLength(0); i++)
            {
                for (int j = 0; j < lhs.Value.GetLength(1); j++)
                {
                    if ((dynamic)lhs[i, j] != (dynamic)rhs[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(SquareMatrix<T> lhs, SquareMatrix<T> rhs)
            => !(lhs == rhs);

        #endregion

        #region Private methods
   
        protected void MatrixValidation(T[,] matrix)
        {
            // Compiles only in case of declaring symbol CONTRACTS_FULL
#if CONTRACTS_FULL
            Contract.Requires<ArgumentNullException>( matrix != null,
                $"Matrix {nameof(matrix)} equals to null.");

            Contract.Requires<ArgumentException>(matrix.GetLength(0) != 0 || matrix.GetLength(1) != 0,
                $"Matrix {nameof(matrix)} is empty.");

            Contract.Requires<ArgumentException>(matrix.GetLength(0) == matrix.GetLength(1),
                $"Matrix {nameof(matrix)} is not square.");

#else
            if (matrix == null)
            {
                throw new ArgumentNullException($"Matrix {nameof(matrix)} equals to null.");
            }

            if (matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
            {
                throw new ArgumentException($"Matrix {nameof(matrix)} is empty.");
            }

            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                throw new ArgumentException($"Matrix {nameof(matrix)} is not square.");
            }
#endif
        }

        protected void ValidateComparer()
        {
            if (!typeof(IComparable<T>).IsAssignableFrom(typeof(T)) &&
                !typeof(IComparable).IsAssignableFrom(typeof(T)))
            {
                throw new InvalidOperationException("Your type doesn't implement IComparable interface");
            }
        }

        private static void ValidatePlusOperator(SquareMatrix<T> lhs, SquareMatrix<T> rhs)
        {
            try
            {
                var tempResult = (dynamic)lhs.nativeMatrix[0, 0] +
                                 (dynamic)rhs.nativeMatrix[0, 0];
            }
            catch (RuntimeBinderException ex)
            {
                throw new ApplicationException("Matrix inner types cannot be calculated by" +
                                               " operator + .)", ex);
            }
        }

        private static void ValidateEqualOperator(SquareMatrix<T> lhs, SquareMatrix<T> rhs)
        {
            try
            {
                bool tempResult = (dynamic)lhs.nativeMatrix[0, 0] ==
                                 (dynamic)rhs.nativeMatrix[0, 0];
            }
            catch (RuntimeBinderException ex)
            {
                throw new ApplicationException("Result cannot be calculated by" +
                                               " operator == .)", ex);
            }
        }

        #endregion

    }
}
