using System;

namespace MathTasks.Algorithms
{
    public partial class Extensions
    {
        /// <summary>
        /// Stein's algorithm to find GCD of 2 or more numbers.
        /// </summary>
        /// <param name="input">Numbers to find greatest common divisor.</param>
        /// <returns>The greatest common divisor of presented numbers.</returns>
        public static int FindEuclideanBinaryGCD(int[] input)
        {
            ThrowingNullExceptions(input, "No array has been given.");
            ThrowingOutOfRangeException(input, "No arguments has been given.");

            int currentGCD = 0;
            currentGCD = FindEuclideanBinaryGCDBasic(input[0], input[1]);
            for (int k = 2; k < input.Length; k++)
            {
                currentGCD = FindEuclideanBinaryGCDBasic(currentGCD, input[k]);
            }
            return currentGCD;
        }

        /// <summary>
        /// Finds GCD of 2 numbers by Stein's algorithm.
        /// </summary>
        /// <param name="firstNum">The first number.</param>
        /// <param name="secondNum">The second number.</param>
        /// <returns>The greatest common divisor of two numbers.</returns>
        private static int FindEuclideanBinaryGCDBasic(int firstNum, int secondNum)
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
                    return FindEuclideanBinaryGCDBasic(firstNum >> 1, secondNum);
                }
                return FindEuclideanBinaryGCDBasic(firstNum >> 1, secondNum >> 1) << 1;
            }

            if ((~secondNum & 1) != 0)
            {
                return FindEuclideanBinaryGCDBasic(firstNum, secondNum >> 1);
            }

            if (firstNum > secondNum)
            {
                return FindEuclideanBinaryGCDBasic((firstNum - secondNum) >> 1, secondNum);
            }
            return FindEuclideanBinaryGCDBasic((secondNum - firstNum) >> 1, firstNum);
        }
    }
}
