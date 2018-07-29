using System;
using System.Collections.Generic;

namespace MatrixTypes
{
    /// <summary>
    /// Diagonal matrix - all elements, except main diagonal values,
    /// are equal to it's default value (int -> 0, bool -> false)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="MatrixTypes.SquareMatrix{T}" />
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        #region .Ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/> class.
        /// </summary>
        /// <param name="dimension">The dimension.</param>
        public DiagonalMatrix(int dimension) : this(dimension, Comparer<T>.Default) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/> class.
        /// </summary>
        /// <param name="initialMatrix">The initial matrix.</param>
        public DiagonalMatrix(T[,] initialMatrix) : this(initialMatrix , Comparer<T>.Default) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/> class.
        /// </summary>
        /// <param name="dimension">The dimension.</param>
        /// <param name="comparer">The comparer.</param>
        public DiagonalMatrix(int dimension, IComparer<T> comparer) : base(dimension, comparer) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/> class.
        /// </summary>
        /// <param name="initialMatrix">The initial matrix.</param>
        /// <param name="comparer">The comparer.</param>
        /// <exception cref="ArgumentException">Matrix is not diagonal!</exception>
        public DiagonalMatrix(T[,] initialMatrix, IComparer<T> comparer) : base(initialMatrix, comparer)
        {
            if (!IsDiagonal(this))
            {
                throw new ArgumentException("Matrix is not diagonal!");
            }
        }

        #endregion

        #region Private methods

        private bool IsDiagonal(DiagonalMatrix<T> matrix)
        {
            DiagonalMatrix<T> transposedMatrix =
                new DiagonalMatrix<T>(matrix.Value.GetLength(0));

            bool CheckDiagonal(DiagonalMatrix<T> newMatrix)
            {
                for (int i = 0; i < matrix.Value.GetLength(1); i++)
                {
                    for (int j = 0; j < matrix.Value.GetLength(0); j++)
                    {
                        if (i != j && matrix[i, j] != (dynamic) default(T))
                        {
                            return false;
                        }
                    }
                }

                return true;
            }

            return CheckDiagonal(matrix);
        }

        #endregion
    }
}