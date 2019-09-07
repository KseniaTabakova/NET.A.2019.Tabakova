using System;

namespace Extensions
{
    /// <summary>
    /// Algorithms of finding the greatest common divisor with delegate using.
    /// </summary>
    public static class EuclideanAlgorithmsRefactoring
    {
        /// <summary>
        /// Delegate 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public delegate int GCD(int a, int b);

        /// <summary>
        /// Euclidian's algorithm to find GCD of 2 or more numbers. 
        /// </summary>
        /// <param name="input">Numbers to find greatest common divisor.</param>
        /// <returns>The greatest common divisor of presented numbers.</returns>
        public static int FindEuclideanGCD(int[] input)
        {
            return GcdBasic(FindEuclideanGCDForTwoNumbers, input);
        }

        /// <summary>
        /// Stein's algorithm to find GCD of 2 or more numbers.
        /// </summary>
        /// <param name="input">Numbers to find greatest common divisor.</param>
        /// <returns>The greatest common divisor of presented numbers.</returns>
        public static int FindSteinsGCD(int[] numbers)
        {
            return GcdBasic(FindSteinsGCDForTwoNumbers, numbers);
        }

        /// <summary>
        /// Helps to finding GDC of all elements.
        /// </summary>
        /// <param name="gcdOfTwoNum">GDC of two elements.</param>
        /// <param name="input">Numbers to find greatest common divisor.</param>
        /// <returns>The greatest common divisor of presented numbers.</returns>
        private static int GcdBasic(GCD gcdOfTwoNum, int[] input)
        {
            ThrowingNullExceptions(input, "No array has been given.");
            ThrowingOutOfRangeException(input, "There must be two or more arguments.");

            int currentGCD = 0;
            currentGCD = gcdOfTwoNum(input[0], input[1]);
            for (int k = 2; k < input.Length; k++)
            {
                currentGCD = gcdOfTwoNum(currentGCD, input[k]);
            }
            return currentGCD;
        }

        #region Methods for the delegate

        /// <summary>
        /// Finds GCD of 2 numbers by Euclidian's algorithm. The method contains information for the delegate.
        /// </summary>
        /// <param name="firstNum">The first number.</param>
        /// <param name="secondNum">The second number.</param>
        /// <returns>The greatest common divisor of two numbers.</returns>
        private static int FindEuclideanGCDForTwoNumbers(int firstNum, int secondNum)
        {
            firstNum = Math.Abs(firstNum);
            secondNum = Math.Abs(secondNum);

            if (firstNum == 0)
            {
                return secondNum;
            }

            if (secondNum == 0)
            {
                return firstNum;
            }

            while (firstNum != secondNum)
            {
                if (firstNum > secondNum)
                {
                    firstNum = firstNum - secondNum;
                }
                else
                {
                    secondNum = secondNum - firstNum;
                }
            }
            return firstNum;
        }

        /// <summary>
        /// Finds GCD of 2 numbers by Stein's algorithm. The method contains information for the delegate.
        /// </summary>
        /// <param name="firstNum">The first number.</param>
        /// <param name="secondNum">The second number.</param>
        /// <returns>The greatest common divisor of two numbers.</returns>
        private static int FindSteinsGCDForTwoNumbers(int firstNum, int secondNum)
        {
            firstNum = Math.Abs(firstNum);
            secondNum = Math.Abs(secondNum);

            if (firstNum == secondNum)
            {
                return firstNum;
            }

            if (firstNum == 0 || secondNum == 0)
            {
                return firstNum | secondNum;
            }
            if ((~firstNum & 1) != 0)
            {
                if ((secondNum & 1) != 0)
                {
                    return FindSteinsGCDForTwoNumbers(firstNum >> 1, secondNum);
                }
                return FindSteinsGCDForTwoNumbers(firstNum >> 1, secondNum >> 1) << 1;
            }

            if ((~secondNum & 1) != 0)
            {
                return FindSteinsGCDForTwoNumbers(firstNum, secondNum >> 1);
            }

            if (firstNum > secondNum)
            {
                return FindSteinsGCDForTwoNumbers((firstNum - secondNum) >> 1, secondNum);
            }
            return FindSteinsGCDForTwoNumbers((secondNum - firstNum) >> 1, firstNum);
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
        /// Throwing out of range exception in case of unforeseen consequence.
        /// </summary>
        /// <param name="array">Array witch can couse an exception.</param>
        /// <param name="message">Message to be show.</param>
        private static void ThrowingOutOfRangeException(int[] array, string message)
        {
            if (array.Length < 2)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
