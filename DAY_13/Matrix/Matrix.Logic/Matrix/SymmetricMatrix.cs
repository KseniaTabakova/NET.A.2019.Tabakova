using System;
using Matrix.Exceptions;

namespace Matrix
{
    /// <summary>
    /// Generalized class of Symmetric Matrix presentation. 
    /// </summary>
    /// <typeparam name="T">Type.</typeparam>
    public class SymmetricMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        /// Logic of square matrix inizialization constructor.
        /// </summary>
        /// <param name="rank">Number of elements in rank.</param>
        public SymmetricMatrix(int rank) : base(rank)
        {
        }

        /// <summary>
        /// Logic of square matrix inizialization constructor.
        /// </summary>
        /// <param name="array">Ready to use jagged array.</param>
        public SymmetricMatrix(T[,] array) : base(array)
        {
            if (!this.IsSymmetric()) throw new MatrixRepresentationException("Impossible to create symmetric matrix with given array");           
        }
    }
}
