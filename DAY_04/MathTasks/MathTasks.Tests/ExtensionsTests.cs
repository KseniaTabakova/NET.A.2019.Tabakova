using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MathTasks.Tests
{
    [TestClass]
    public class ExtensionsTests
    {
        #region FindEuclideanGCD Tests
        [TestMethod]
        public void FindEuclideanGCD_TwoArrayElements()
        {
            string diagnosticsResult;
            int[] input = { 30, 12 };
            int result = Diagnostics.Diagnostics_.FixTotalRunTime(Algorithms.Extensions.FindEuclideanGCD, input, out diagnosticsResult);
            Assert.AreEqual(6, result);
            Console.WriteLine(diagnosticsResult);
        }

        [TestMethod]
        public void FindEuclideanGCD_HavingZeroElement()
        {
            string diagnosticsResult;
            int[] input = { 0, 12 };
            int result = Diagnostics.Diagnostics_.FixTotalRunTime(Algorithms.Extensions.FindEuclideanGCD, input, out diagnosticsResult);
            Assert.AreEqual(12, result);
            Console.WriteLine(diagnosticsResult);
        }

        [TestMethod]
        public void FindEuclideanGCD_MoreThanTwoElements()
        {
            string diagnosticsResult;
            int[] input = { 0, 1, 37, 3 };
            int result = Diagnostics.Diagnostics_.FixTotalRunTime(Algorithms.Extensions.FindEuclideanGCD, input, out diagnosticsResult);
            Assert.AreEqual(1, result);
            Console.WriteLine(diagnosticsResult);
        }

        [TestMethod]
        public void FindEuclideanGCD_NegativeElements()
        {
            string diagnosticsResult;
            int[] input = { 10, -15, 25, -35 };
            int result = Diagnostics.Diagnostics_.FixTotalRunTime(Algorithms.Extensions.FindEuclideanGCD, input, out diagnosticsResult);
            Assert.AreEqual(5, result);
            Console.WriteLine(diagnosticsResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindEuclideanGCD_NullArray()
        {
            string diagnosticsResult;
            int[] input = null;
            int result = Diagnostics.Diagnostics_.FixTotalRunTime(Algorithms.Extensions.FindEuclideanGCD, input, out diagnosticsResult);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindEuclideanGCD_ZeroElementsInArray()
        {
            string diagnosticsResult;
            int[] input = { };
            int result = Diagnostics.Diagnostics_.FixTotalRunTime(Algorithms.Extensions.FindEuclideanGCD, input, out diagnosticsResult);

        }
        #endregion

        #region FindEuclideanBinaryGCD Tests

        [TestMethod]
        public void FindEuclideanBinaryGCD_TwoArrayElements()
        {
            string diagnosticsResult;
            int[] input = { 30, 12 };
            int result = Diagnostics.Diagnostics_.FixTotalRunTime(Algorithms.Extensions.FindEuclideanBinaryGCD, input, out diagnosticsResult);
            Assert.AreEqual(6, result);
            Console.WriteLine(diagnosticsResult);
        }

        [TestMethod]
        public void FindEuclideanBinaryGCD_HavingZeroElement()
        {
            string diagnosticsResult;
            int[] input = { 0, 12 };
            int result = Diagnostics.Diagnostics_.FixTotalRunTime(Algorithms.Extensions.FindEuclideanBinaryGCD, input, out diagnosticsResult);
            Assert.AreEqual(12, result);
            Console.WriteLine(diagnosticsResult);
        }
        [TestMethod]
        public void FindEuclideanBinaryGCD_MoreThanTwoElements()
        {
            string diagnosticsResult;
            int[] input = { 0, 1, 37, 3 };
            int result = Diagnostics.Diagnostics_.FixTotalRunTime(Algorithms.Extensions.FindEuclideanBinaryGCD, input, out diagnosticsResult);
            Assert.AreEqual(1, result);
            Console.WriteLine(diagnosticsResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindEuclideanBinaryGCD_NullArray()
        {
            string diagnosticsResult;
            int[] input = null;
            int result = Diagnostics.Diagnostics_.FixTotalRunTime(Algorithms.Extensions.FindEuclideanBinaryGCD, input, out diagnosticsResult);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindEuclideanBinaryGCD_ZeroElementsInArray()
        {
            string diagnosticsResult;
            int[] input = { };
            int result = Diagnostics.Diagnostics_.FixTotalRunTime(Algorithms.Extensions.FindEuclideanBinaryGCD, input, out diagnosticsResult);

        }

        [TestMethod]
        public void FindEuclideanBinaryGCD_NegativeElements()
        {
            string diagnosticsResult;
            int[] input = { 10, -15, 25, -35 };
            int result = Diagnostics.Diagnostics_.FixTotalRunTime(Algorithms.Extensions.FindEuclideanBinaryGCD, input, out diagnosticsResult);
            Assert.AreEqual(5, result);
            Console.WriteLine(diagnosticsResult);
        }

        #endregion
    }
}
