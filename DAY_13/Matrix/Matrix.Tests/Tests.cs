using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Matrix.Tests
{
    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        public void CreateSquareMatrix()
        {
            double[,] array = { { 1.22, 3.2 }, { 4.22, 2 } };
            SquareMatrix<double> matrix = new SquareMatrix<double>(array);
            Assert.AreEqual(2, matrix.Rank);
        }

        [TestMethod]
        public void CreateSymmetricMatrixTest_ArgumentException()
        {
            int[,] array = { { 0, 1 }, { 2, 0 } };
            Assert.ThrowsException<ArgumentException>(() => new SymmetricMatrix<int>(array));
        }

        [TestMethod]
        public void CreateDiagonalMatrixTest_ArgumentException()
        {
            float[,] array = { { 0, 1.0f }, { 0.0f, 0 } };
            Assert.ThrowsException<ArgumentException>(() => new DiagonalMatrix<float>(array));
        }

        [TestMethod]
        public void ElementChangedTest()
        {
            short[,] array = { { 1, 1, 1, 4 }, { 1, 1, 1, 3 }, { 1, 1, 1, 2 }, { 4, 3, 2, 1 } };
            SymmetricMatrix<short> matrix = new SymmetricMatrix<short>(array);
            List<string> receivedEvents = new List<string>();

            matrix.ElementChanged += (sender, e) => { receivedEvents.Add(e.Message); };
            matrix[0, 2] = 5;
       
            Assert.AreEqual(2, receivedEvents.Count);
            Assert.AreEqual("Element [0, 2] changed to 5", receivedEvents[0]);
            Assert.AreEqual("Element [2, 0] changed to 5", receivedEvents[1]);
        }

        [TestMethod]
        public void AddTest()
        {
            int[,] array1 = {{ 1, 1, 1, 4 },{ 1, 1, 1, 3 },{ 1, 1, 1, 2 },{ 4, 3, 2, 1 }};
            int[,] array2 ={{ 1, 0, 0, 0 },{ 0, 3, 0, 0 },{ 0, 0, 2, 0 },{ 0, 0, 0, 4 }};
            int[,] expectedArray = {{ 2, 1, 1, 4 },{ 1, 4, 1, 3 },{ 1, 1, 3, 2 },{ 4, 3, 2, 5 }};

            SymmetricMatrix<int> matrix1 = new SymmetricMatrix<int>(array1);
            DiagonalMatrix<int> matrix2 = new DiagonalMatrix<int>(array2);
            SquareMatrix<int> expectedMatrix = new SquareMatrix<int>(expectedArray);

            var result = matrix1.Add(matrix2);
            for (int i = 0; i < result.Order; i++)
            {
                for (int j = 0; j < result.Order; j++)
                {
                    Assert.AreEqual(expectedMatrix[i, j], result[i, j]);
                }
            }
        }
    }
}