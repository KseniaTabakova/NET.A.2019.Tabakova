using System;
using System.Collections.Generic;
using Matrix.Exceptions;

namespace Matrix
{
    static class MatrixExtensions
    {
        public static bool IsSymmetric<T>(this SquareMatrix<T> matrix)
        {
            int colIndex = 1;

            for (int i = 0; i < matrix.Rank - 1; i++)
            {
                for (int j = colIndex; j < matrix.Rank; j++)
                {
                    if (Comparer<T>.Default.Compare(matrix[i, j], matrix[j, i]) != 0)
                    {
                        return false;
                    }
                }

                colIndex++;
            }

            return true;
        }

        public static bool IsDiagonal<T>(this SquareMatrix<T> matrix)
        {
            for (int i = 0; i < matrix.Rank; i++)
            {
                for (int j = 0; j < matrix.Rank; j++)
                {
                    if (i != j && Comparer<T>.Default.Compare(matrix[i, j], default(T)) != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static T[,] Add<T>(this T[,] first, T[,] second)
        {
            if (first.Rank != second.Rank) throw new MatrixRepresentationException("Impossible to add matrices with different orders");

            T[,] temp = new T[first.Rank, first.Rank];

            for (int i = 0; i < first.Rank; i++)
            {
                for (int j = 0; j < first.Rank; j++)
                {
                    dynamic firstOperand = first[i, j];
                    dynamic secondOperand = second[i, j];
                    temp[i, j] = firstOperand + secondOperand;
                }
            }

            return new SquareMatrix<T>(temp);
        }
    }
}
