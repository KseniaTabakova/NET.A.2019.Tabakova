namespace ArrayOperations
{
    /// <summary>
    /// Class contains 3 variation of sorting criteria for jagged array.
    /// </summary>
    public static class SortingCriteria
    {
        #region Arrays' sum criteria method

        /// <summary>
        /// Get array of the sum of each jagged array rang.
        /// </summary>
        /// <param name="array">Input array.</param>
        /// <returns>Array of arrays' sums.</returns>
        internal static int[] SummarizeElementsInEachRank(int[][] array)
        {
            int sum = 0;
            int[] sumValues = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    sum += array[i][j];
                }
                sumValues[i] = sum;
                sum = 0;
            }
            return sumValues;
        }

        #endregion

        #region Arrays' maximum element criteria method

        /// <summary>
        /// Get array of the maximum element of each jagged array rang.
        /// </summary>
        /// <param name="array">Input array.</param>
        /// <returns>Array of arrays' maximum element.</returns>
        internal static int[] GetMaximumElementInEachRank(int[][] array)
        {
            int max = Int32.MinValue;
            int[] maxValues = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] > max)
                        max = array[i][j];
                }
                maxValues[i] = max;
                max = 0;
            }
            return maxValues;
        }

        #endregion

        #region Arrays' minimum element criteria method

        /// <summary>
        /// Get array of the minimum element of each jagged array rang.
        /// </summary>
        /// <param name="array">Input array.</param>
        /// <returns>Array of arrays' minimum element.</returns>
        internal static int[] GetMinimumElementInEachRank(int[][] array)
        {
            int min = Int32.MaxValue;
            int[] minValues = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] < min)
                        min = array[i][j];
                }
                minValues[i] = min;
                min = 9;
            }
            return minValues;
        }
        #endregion
    }
}
