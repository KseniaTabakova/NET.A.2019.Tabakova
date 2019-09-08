namespace Matrix
{
    /// <summary>
    /// Class provides the correctness of input data.
    /// </summary>
    public class Validator
    {
        /// <summary>
        /// Find out the correctness of matrix rank.
        /// </summary>
        /// <param name="rank">Input rank.</param>
        /// <returns>Operation result status.</returns>
        internal static bool RankIsValid(int rank)
        {
            if (rank <= 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Find out the correctness of matrix indexes.
        /// </summary>
        /// <param name="i">X-index.</param>
        /// <param name="j">Y-index.</param>
        /// <param name="rank">Input rank.</param>
        /// <returns>Operation result status.</returns>
        internal static bool MatrixIndexIsValid(int i, int j, int rank)
        {
            if (i < 0 || i >= rank || j < 0 || j >= rank)
            {
                return false;
            }
            return true;
        }
    }
}
