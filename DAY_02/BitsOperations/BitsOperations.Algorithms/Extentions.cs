using System;

namespace BitsOperations.Algorithms
{
    /// <summary>
    /// Class provides bits inserting from the j-th to the i-th bit.
    /// </summary>
    public class Extentions
    {
        #region Insert of numbers

        /// <summary>
        /// Insert of bits with getting the new number in decimal notation.
        /// </summary>
        /// <param name="firstNumber">Decimal number where the second number will be insert.</param>
        /// <param name="secondNumber">Inserting decimal number.</param>
        /// <param name="startPosition">The start of the inserting portion.</param>
        /// <param name="endPosition">The end of the inserting portion.</param>
        /// <returns>Decimal notation of bits inserts.</returns>
        public static int InsertNumber(int firstNumber, int secondNumber, int startPosition, int endPosition)
        {
            ThrowingArgumentException(startPosition, endPosition, "The arguments must be above zero, in the range from 0 to 31 " +
                "and start position must greater than the end one.");

            int tempNumber = 0;
            tempNumber = ~tempNumber;
            tempNumber = tempNumber << (endPosition - startPosition + 1);
            tempNumber = ~tempNumber;

            secondNumber = secondNumber & tempNumber;
            secondNumber = secondNumber << startPosition;

            int newNumber = secondNumber | firstNumber;
            return int.Parse(Convert.ToString(newNumber, 10));
        }

        #endregion

        /// <summary>
        /// Throwing argument exception in case of unforeseen consequence.
        /// </summary>
        /// <param name="firstBit">The first condition bit which can call an exception.</param>
        /// <param name="secondBit">The second condition bit which can call an exception.</param>
        /// <param name="message">Message to be show.</param>
        private static void ThrowingArgumentException(int firstBit, int secondBit, string message)
        {
            if (firstBit > secondBit || firstBit < 0 || secondBit < 0 || firstBit<0 || secondBit>31)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
