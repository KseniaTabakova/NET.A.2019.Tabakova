using System;

namespace Matrix
{
    /// <summary>
    /// Generalized class of Square Matrix presentation. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SquareMatrix<T> 
    {
        /// <summary>
        /// Event of any changes in matrix.
        /// </summary>
        public event EventHandler<ElementChangedEventArgs> ElementChanged;

        /// <summary>
        /// Method to run an event.
        /// </summary>
        /// <param name="sender">Sender of event.</param>
        /// <param name="e">Additional information about event.</param>
        public void OnElementChanged(object sender, ElementChangedEventArgs e) => ElementChanged?.Invoke(sender, e);

        /// <summary>
        /// Square matrix.
        /// </summary>
        private T[,] matrix;

        /// <summary>
        /// Number of elements in rank.
        /// </summary>
        public int Rank { get; private set; }

        /// <summary>
        /// Constructor to create square matrix with appropriate rank.
        /// </summary>
        /// <param name="rank">Number of elements in rank.</param>
        public SquareMatrix(int rank)
        {
            if (!Validator.RankIsValid(rank)) throw new MatrixRankException("Rank must be more than zero.");

            matrix = new T[rank, rank];
            Rank = rank;
        }

        /// <summary>
        /// Constructor to create square matrix with appropriate rank.
        /// </summary>
        /// <param name="array">Ready to use jagged array.</param>
        public SquareMatrix(T[,] array)
        {
            if (array.GetLowerBound(0) != array.GetUpperBound(0)) throw new MatrixRankException("It is not possible to create a square matrix.");
            
            matrix = array;
            Rank = array.GetUpperBound(0) + 1;
        }

        /// <summary>
        /// MatrixI indexator.
        /// </summary>
        /// <param name="i">On x - index.</param>
        /// <param name="j">On y - index.</param>
        /// <returns>Number on such position.</returns>
        public T this[int i, int j]
        {
            get
            {
                if (!Validator.MatrixIndexIsValid(i, j, Rank)) throw new ArgumentException("Invalid index.");               
                return matrix[i, j];
            }
            set
            {
                matrix[i, j] = value;
                OnElementChanged(this, new ElementChangedEventArgs($"Element at [{i}, {j}] changed to {value}."));
            }
        }

        /// <summary>
        /// Replacing rows with columns of matrix. 
        /// </summary>
        public void Transpose()
        {
            T[,] tempArr = new T[Rank, Rank];
            for (int i = 0; i < Rank; i++)
            {
                for (int j = 0; j < Rank; j++)
                {
                    tempArr[j, i] = matrix[i, j];
                }
            }
            matrix = tempArr;
        }

        /// <summary>
        /// Overloaded representation in String format of matrix.  
        /// </summary>
        /// <returns>String format of matrix.</returns>
        public override string ToString()
        {
            string res = string.Empty;

            for (int i = 0; i < Rank; i++)
            {
                for (int j = 0; j < Rank; j++)
                {
                    res += string.Format("{0, -2}", matrix[i, j]);
                }
                Console.WriteLine();
            }
            return res;
        }
    }
}
