using System;
using ArrayExtensions.Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class ExtensionsTests
    {
        [TestMethod]
        public void FilterDigit_RandomArray()
        {
            int[] input = {1, 2, 22, 7, 84, 201};
            int[] expected = {2, 22, 201};
            int[] result = ArrayExtensions.Algorithms.Extensions.FilterDigit(2, input);
            CollectionAssert.AreEqual(expected,result);
        }

        [TestMethod]
        public void FilterDigit_RandomArray_DigitNotMatch()
        {
            int[] input = { 7, 1, 2, 3, 4, 5, 6, 68, 69, 15 };
            int[] expected = { };
            int[] result = Extensions.FilterDigit(0, input);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FilterDigit_RandomArray_AllHaveDigit()
        {
            int[] input = { 77,7,7,17,67 };
            int[] expected = { 77, 7, 7, 17, 67 };
            int[] result = Extensions.FilterDigit(7, input);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FilterDigit_InappropriateDigit()
        {
            int[] input = { 77, 7, 7, 17, 67 };
            int[] result = Extensions.FilterDigit(17, input);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FilterDigit_NullArray()
        {
            int[] input = null;
            int[] result = Extensions.FilterDigit(3, input);

        }
    }
}
