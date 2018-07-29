using System;
using System.Collections.Generic;
using NUnit.Framework;
using MatrixTypes;

namespace MatrixTypesTest
{
    [TestFixture]
    public class SquareMatrixTest
    {
        private readonly List<int[,]> testIntMatrix = new List<int[,]>()
        {
            new int[,]
            {
                {2, 4, 5},
                {8, 9, 1},
                {5, 5, 5}
            },
            new int[,]
            {
                {900, 189,-25, 47},
                {-8899, 1000, 15, 3},
                {5, 5, 5, 5},
                {800, 900, 1000, 87},
            }
        };

        [Test]
        public void TestSquareMatrix()
        {
            int[,] result =
            {
                {4, 8, 10},
                {16, 18, 2},
                {10, 10, 10}
            };

            SquareMatrix<int> ExpectedResult = new SquareMatrix<int>(result);
            SquareMatrix<int> sqMatrix1 = new SquareMatrix<int>(testIntMatrix[0]);
            //sqMatrix1[0, 1] = 16;
            Assert.IsTrue(ExpectedResult == (sqMatrix1 + sqMatrix1));
        }

        [Test]
        public void TestSymmetricMatrix()
        {
            int[,] initMatrix =
            {
                {1, 2, 3},
                {2, 8, 8},
                {3, 8, 8}
            };

            SquareMatrix<int> inmatrix = new SymmetricMatrix<int>(initMatrix);
            SquareMatrix<int> symm = new SymmetricMatrix<int>(initMatrix);
            Assert.IsTrue(inmatrix == symm);
        }

        [Test]
        public void TestDiagonalMatrix()
        {
            int[,] initMatrix =
            {
                {1, 0, 0, 0, 0},
                {0, 2, 0, 0, 0},
                {0, 0, 3, 0, 0},
                {0, 0, 0, 4, 0},
                {0, 0, 0, 0, 5},
            };

            SquareMatrix<int> inmatrix = new DiagonalMatrix<int>(initMatrix);
            SquareMatrix<int> symm = new DiagonalMatrix<int>(initMatrix);
            Assert.IsTrue(inmatrix == symm);
        }

        [Test]
        public void TestAdditionMatrix()
        {
            int[,] initMatrix1 =
            {
                {1, 0, 0, 0, 0},
                {0, 2, 0, 0, 0},
                {0, 0, 3, 0, 0},
                {0, 0, 0, 4, 0},
                {0, 0, 0, 0, 5},
            };

            int[,] initMatrix2 =
            {
                {1, 0, 2, 45, 0},
                {124, 2, 0, 0, 0},
                {2156, 5, 3, 0, 0},
                {0, -11, 0, 4, 0},
                {0, 0, 54, 0, 5},
            };

            SquareMatrix<int> diag = new DiagonalMatrix<int>(initMatrix1);
            SquareMatrix<int> square = new SquareMatrix<int>(initMatrix2);
            SquareMatrix<int> res = diag + square;
            //Assert.IsTrue(true);
        }

        [Test]
        public void TestIndexChanging()
        {
            SquareMatrix<int> diag = new SquareMatrix<int>(testIntMatrix[1])
            {
                [3, 3] = 15,
                [1, 2] = 1998
            };
        }
    }      
}
