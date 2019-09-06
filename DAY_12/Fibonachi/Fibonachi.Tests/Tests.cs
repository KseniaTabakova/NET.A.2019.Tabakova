using NUnit.Framework;
using System;

namespace AlgorithmsTests
{
    class FibonachiTests
    {
        [Test]
        public void Generate_Fibonachi()
        {
            long[][] expected =
                {
                new long[] { 0 },
                new long[] { 0, 1 },
                new long[] { 0, 1, 1 },
                new long[] { 0, 1, 1, 2 },
                new long[] { 0, 1, 1, 2, 3 },
                new long[] { 0, 1, 1, 2, 3, 5 },
                new long[] { 0, 1, 1, 2, 3, 5, 8 },
                new long[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89 }
                };
            int[] inputLengthes = new int[] { 1, 2, 3, 4, 5, 6, 7, 12 };

            for (int i = 0; i < inputLengthes.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], Fibonachi.Fibonachi.GetFibonachi(inputLengthes[i]));
            }
        }
      
    }
}