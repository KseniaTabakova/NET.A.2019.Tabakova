using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumberFinder.Tests
{
    [TestClass]
    public class ExtentionsTests
    {
        [TestMethod]
        public void FindNextBiggerNumber_ConsecutiveNumbers()
        {
            int input = NumberFinder.Algorithms.Extensions.FindNextBiggerNumber(12);
            Assert.AreEqual(21,input);
        }

        [TestMethod]
        public void FindNextBiggerNumber_RandomNumber()
        {
            int input = NumberFinder.Algorithms.Extensions.FindNextBiggerNumber(513);
            Assert.AreEqual(531, input);
        }

        [TestMethod]
        public void FindNextBiggerNumber_BigRandomNumber()
        {
            int input = NumberFinder.Algorithms.Extensions.FindNextBiggerNumber(2017);
            Assert.AreEqual(2071, input);
        }

        [TestMethod]
        public void FindNextBiggerNumber_DecreasingNumbers()
        {
            int input = NumberFinder.Algorithms.Extensions.FindNextBiggerNumber(321);
            Assert.AreEqual(321, input);
        }
        [TestMethod]
        public void FindNextBiggerNumber_UniqueNumber()
        {
            int input = NumberFinder.Algorithms.Extensions.FindNextBiggerNumber(3);
            Assert.AreEqual(3, input);
        }

    }
}
