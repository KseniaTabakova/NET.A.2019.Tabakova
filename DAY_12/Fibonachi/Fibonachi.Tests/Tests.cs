using NUnit.Framework;
using System;

namespace Tests
{
    class FibonachiTests
    {
        [Test]
        public void GetFibonacci()
        {
            long[][] expected =
                {
                new long[] { 0, 1, 1 },
                new long[] { 0, 1, 1, 2 },
                new long[] { 0, 1, 1, 2, 3, 5 },
                new long[] { 0, 1, 1, 2, 3, 5, 8 },
                new long[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89 }
                };
            int[] length = { 3, 4, 6, 7, 12 };

            for (int i = 0; i < length.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], FibonacciAlgorithm.Fibonacci.GetFibonacci(length[i]));
            }
        }
    
    }
}