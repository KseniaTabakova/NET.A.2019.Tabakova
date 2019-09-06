using System;

namespace MathExtensions
{
    public delegate int GCD(int a, int b);

    public static class EuclideanAlgorithmsRefactoring
    {
        public static int FindEuclideanBinaryGCD(int[] input)
        {
            return GcdAlgorithm(FindEuclideanGCDForTwoNumbers, input);
        }

        public static int GcdSteinsAlgorithm(int[] numbers)
        {
            return GcdAlgorithm(FindEuclideanBinaryGCDForTwoNumbers, numbers);
        }

        
        private static int GcdAlgorithm(GCD gcdOfTwo, int[] input)
        {
            ThrowingNullExceptions(input, "No array has been given.");
            ThrowingOutOfRangeException(input, "No arguments has been given.");

            int currentGCD = 0;
            currentGCD = gcdOfTwo(input[0], input[1]);
            for (int k = 2; k < input.Length; k++)
            {
                currentGCD = gcdOfTwo(currentGCD, input[k]);
            }
            return currentGCD;
        }

        private static int FindEuclideanGCDForTwoNumbers(int a, int b)
        {
            
            a = Math.Abs(a);
            b = Math.Abs(b);

            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            while (a != b)
            {
                if (a > b)
                {
                    a = a - b;
                }
                else
                {
                    b = b - a;
                }
            }

            return a;
        }


        private static int FindEuclideanBinaryGCDForTwoNumbers(int firstNum, int secondNum)
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
                    return FindEuclideanBinaryGCDForTwoNumbers(firstNum >> 1, secondNum);
                }
                return FindEuclideanBinaryGCDForTwoNumbers(firstNum >> 1, secondNum >> 1) << 1;
            }

            if ((~secondNum & 1) != 0)
            {
                return FindEuclideanBinaryGCDForTwoNumbers(firstNum, secondNum >> 1);
            }

            if (firstNum > secondNum)
            {
                return FindEuclideanBinaryGCDForTwoNumbers((firstNum - secondNum) >> 1, secondNum);
            }
            return FindEuclideanBinaryGCDForTwoNumbers((secondNum - firstNum) >> 1, firstNum);
        }

        private static void ThrowingNullExceptions(int[] array, string message)
        {
            if (array is null)
            {
                throw new ArgumentNullException(message);
            }
        }

        private static void ThrowingOutOfRangeException(int[] array, string message)
        {
            if (array.Length < 2)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

    }
}
