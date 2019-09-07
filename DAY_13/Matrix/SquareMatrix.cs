using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    
    /// Represents square matrix
    
    public class SquareMatrix<T>
    {
        private T[,] _values;

       
        public SquareMatrix(int order)
        {
            if (order <= 0)
            {
                throw new ArgumentException("Order of matrix cannot be less or equal to zero");
            }

            _values = new T[order, order];
            Order = order;
        }

       
        public SquareMatrix(T[,] array)
        {
            if (array.GetUpperBound(0) != array.GetUpperBound(0))
            {
                throw new ArgumentException("Number of rows in given array is not equal to number of columns");
            }

            if (array.GetUpperBound(0) == -1)
            {
                throw new ArgumentException("Impossible to create matrix of zero order");
            }

            _values = array;
            Order = array.GetUpperBound(0) + 1;
        }

        
        public delegate void ElementChangedEventHandler(object sender, ElementChangedEventArgs e);

       
       
        public event ElementChangedEventHandler ElementChanged;

        
        public int Order { get; private set; }

        
        public T this[int i, int j]
        {
            get
            {
                if (i < 0 ||
                i >= Order ||
                j < 0 ||
                j >= Order)
                {
                    throw new ArgumentException("Invalid index value");
                }

                return _values[i, j];
            }

            set
            {
                ChangeElement(i, j, value);
            }
        }

   
        public void Transpose()
        {
            T[,] tempArr = new T[Order, Order];

            for (int i = 0; i < Order; i++)
            {
                for (int j = 0; j < Order; j++)
                {
                    tempArr[j, i] = _values[i, j];
                }
            }

            _values = tempArr;
        }

        
        public virtual void ChangeElement(int i, int j, T value)
        {
            if (i < 0 ||
                i >= Order ||
                j < 0 ||
                j >= Order)
            {
                throw new ArgumentException("Invalid index value");
            }

            _values[i, j] = value;

            OnElementChanged(this, new ElementChangedEventArgs($"Element [{i}, {j}] changed to {value}"));
        }

      
        public override string ToString()
        {
            string res = string.Empty;

            for (int i = 0; i < Order; i++)
            {
                for (int j = 0; j < Order; j++)
                {
                    res += string.Format("{0, -8}", _values[i, j]);
                }

                res += "\n";
            }

            return res;
        }

       
        protected bool IsSymmetric()
        {
            int colIndex = 1;

            for (int i = 0; i < Order - 1; i++)
            {
                for (int j = colIndex; j < Order; j++)
                {
                    if (Comparer<T>.Default.Compare(_values[i, j], _values[j, i]) != 0)
                    {
                        return false;
                    }
                }

                colIndex++;
            }

            return true;
        }

        
        protected bool IsDiagonal()
        {
            for (int i = 0; i < Order; i++)
            {
                for (int j = 0; j < Order; j++)
                {
                    if (i != j && Comparer<T>.Default.Compare(_values[i, j], default(T)) != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        protected virtual void OnElementChanged(object sender, ElementChangedEventArgs e)
        {
            if (ElementChanged != null)
            {
                ElementChanged(sender, e);
            }
        }
    }
}
