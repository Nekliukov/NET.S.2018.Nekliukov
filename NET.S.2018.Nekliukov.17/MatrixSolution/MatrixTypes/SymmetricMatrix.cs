using System;
using System.Collections.Generic;

namespace MatrixTypes
{
    /// <summary>
    /// Symmetric matrix - it's a matrix that will be the same
    /// after transposition
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="MatrixTypes.SquareMatrix{T}" />
    public sealed class SymmetricMatrix<T>: SquareMatrix<T>
    {
        #region .Ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="SymmetricMatrix{T}"/> class.
        /// </summary>
        /// <param name="dimension">The dimension.</param>
        public SymmetricMatrix(int dimension) : this(dimension, Comparer<T>.Default) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SymmetricMatrix{T}"/> class.
        /// </summary>
        /// <param name="dimension">The dimension.</param>
        /// <param name="comparer">The comparer.</param>
        public SymmetricMatrix(int dimension, IComparer<T> comparer) : base(dimension, comparer) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SymmetricMatrix{T}"/> class.
        /// </summary>
        /// <param name="initialMatrix">The initial matrix.</param>
        public SymmetricMatrix(T[,] initialMatrix) : this(initialMatrix, Comparer<T>.Default) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SymmetricMatrix{T}"/> class.
        /// </summary>
        /// <param name="initialMatrix">The initial matrix.</param>
        /// <param name="comparer">The comparer.</param>
        /// <exception cref="ArgumentException">Matrix is not symmertic!</exception>
        public SymmetricMatrix(T[,] initialMatrix, IComparer<T> comparer) : base(initialMatrix, comparer)
        {
            if (!IsSymmetric(this))
            {
                throw new ArgumentException("Matrix is not symmertic!");
            }
        }

        #endregion

        #region Private methods

        private bool IsSymmetric(SymmetricMatrix<T> matrix)
        {
            SymmetricMatrix<T> transposedMatrix =
                new SymmetricMatrix<T>(matrix.Value.GetLength(0));

            void Transpose(SymmetricMatrix<T> newMatrix)
            {
                for (int i = 0; i < matrix.Value.GetLength(1); i++)
                {
                    for (int j = 0; j < matrix.Value.GetLength(0); j++)
                    {
                        newMatrix[j, i] = matrix[i, j];
                    }
                }
            }

            Transpose(transposedMatrix);

            return transposedMatrix == matrix;
        }

        #endregion
    }
}
