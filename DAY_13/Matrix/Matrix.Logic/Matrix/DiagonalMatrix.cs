using System;
using System.Collections.Generic;
using Matrix.Exceptions;

namespace Matrix
{
    /// <summary>
    /// Generalized class of Diagonal Matrix presentation. 
    /// </summary>
    /// <typeparam name="T">Type.</typeparam>
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        /// Logic of square matrix inizialization constructor.
        /// </summary>
        /// <param name="rank">Number of elements in rank.</param>
        public DiagonalMatrix(int rank) : base(rank)
        {
        }

        /// <summary>
        /// Logic of square matrix inizialization constructor.
        /// </summary>
        /// <param name="array">Ready to use jagged array.</param>
        public DiagonalMatrix(T[,] array) : base(array)
        {
            if (!this.IsDiagonal()) throw new MatrixRepresentationException("Impossible to create diagonal matrix with given array");
        }
    }
}
