using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public static class MatrixExtensionMethods
    {
        
        public static SquareMatrix<T> Add<T>(this SquareMatrix<T> first, SquareMatrix<T> second)
        {
            if (first.Order != second.Order)
            {
                throw new ArgumentException("Impossible to add matrices with different orders");
            }

            T[,] temp = new T[first.Order, first.Order];

            for (int i = 0; i < first.Order; i++)
            {
                for (int j = 0; j < first.Order; j++)
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
