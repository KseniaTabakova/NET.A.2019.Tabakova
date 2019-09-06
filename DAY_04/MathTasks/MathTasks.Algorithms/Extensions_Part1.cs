using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTasks.Algorithms
{
    /// <summary>
    /// Algorithms of finding the greatest common divisor.
    /// </summary>
    public partial class Extensions
    {
        /// <summary>
        /// Euclidian's algorithm to find GCD of 2 or more numbers. 
        /// </summary>
        /// <param name="input">Numbers to find greatest common divisor.</param>
        /// <returns>The greatest common divisor of presented numbers.</returns>
        public static int FindEuclideanGCD(int[] input)
        {
            ThrowingNullExceptions(input, "No array has been given.");
            ThrowingOutOfRangeException(input, "No arguments has been given.");

            bool lastNumberInArray = false;
            ref bool lastNumberInArrayRef = ref lastNumberInArray;

            int GCD = 0;
            while (!lastNumberInArray)
            {
                GCD = FillArrayWithNumberDifference( input, out lastNumberInArrayRef);
            }
            return GCD;
        }

        /// <summary>
        /// Subtracts the smallest element from each represented numbers except itself.
        /// </summary>
        /// <param name="input">Numbers of array to be subtracted.</param>
        /// <param name="zero">Information about the presence of zeros after subtraction.</param>
        /// <returns>Modified array.</returns>
        private static int FillArrayWithNumberDifference( int[] input, out bool zero)
        {
            int indexOfMinValue;
            int mibValue = input.MinNumber(out indexOfMinValue);

            int i = 0;
            int countZeroValues = 0;
            while (i < input.Length)
            {
                if (i != indexOfMinValue && input[i] != 0)
                {
                    input[i] = input[i] - mibValue;
                }
                if (input[i] == 0)
                {
                    countZeroValues++;
                }
                i++;
            }
            zero = CheckUniqueNumber(input, countZeroValues);
            return mibValue;
        }

        /// <summary>
        /// Checks for the presence of one unique number among zero numbers in modified array.
        /// </summary>
        /// <param name="array">Modified array.</param>
        /// <param name="countZeroNumber">Presence of one unique number.</param>
        /// <returns></returns>
        private static bool CheckUniqueNumber(int[] array, int countZeroNumber)
        {
            return countZeroNumber == array.Length - 1 ? true : false;
        }

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
        /// Throwing out of range exception in case of unforeseen consequence.
        /// </summary>
        /// <param name="array">Array witch can couse an exception.</param>
        /// <param name="message">Message to be show.</param>
        private static void ThrowingOutOfRangeException(int[] array, string message)
        {
            if (array.Length == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }  
}

