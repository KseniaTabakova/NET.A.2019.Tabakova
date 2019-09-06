using System;
using System.Collections.Generic;

namespace ArrayExtensions.Algorithms
{
    public class Extensions
    {
        #region FilterDigit method

        /// <summary>
        /// Filter the array with leaving numbers with only appropriate numbers.
        /// </summary>
        /// <param name="digit">Given digit.</param>
        /// <param name="array">Array which should be sorted.</param>
        /// <returns>Filtered array.</returns>
        public static int[] FilterDigit(int digit, params int[] array)
        {
            ThrowingNullExceptions(array, "No array has been given.");
            ThrowingArgumentException(digit, "The arguments must be above zero and less than 10.");

            List<int> ourNumbers = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                if (IsIncluded(digit, array[i]))
                {
                    ourNumbers.Add(array[i]);
                }
            }

            int[] result = ourNumbers.ToArray();
            return result;
        }

        /// <summary>
        /// Checks containing digit in each array number.
        /// </summary>
        /// <param name="digit">Given digit.</param>
        /// <param name="number">Array's number.</param>
        /// <returns>Contains the array's number an appropriate digit.</returns>
        private static bool IsIncluded(int digit, int number)
        {
            while (number != 0)
            {
                if (number % 10 == digit)
                {
                    return true;
                }
                else
                {
                    number /= 10;
                }
            }
            return false;
        }

        #endregion

        /// <summary>
        /// Throwing null exception in case of unforeseen consequence.
        /// </summary>
        /// <param name="array">Array witch can couse an exception.</param>
        /// <param name="message">Message to be show.</param>
        private static void ThrowingNullExceptions(int[] array, string message)
        {
            if (array is null)
            {
                throw new ArgumentNullException(message);
            }
        }

        /// <summary>
        /// Throwing argument exception in case of unforeseen consequence.
        /// </summary>
        /// <param name="array">Digit witch can cause an exception.</param>
        /// <param name="message">Message to be show.</param>
        private static void ThrowingArgumentException(int digit, string message)
        {
            if (digit< 0|| digit >9)
            {
                throw new ArgumentException(message);
            }
        }

    }
}
