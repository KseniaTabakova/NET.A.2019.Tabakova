using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BitOperations.UnitTests
{
    [TestClass]
    public class ExtensionsTests
    {
        [TestMethod]
        public void InsertNumber_DifferentNumbers_SameBits()
        {
            int input = BitsOperations.Algorithms.Extentions.InsertNumber(8,15, 0, 0);
            Assert.AreEqual(9,input);
        }
        [TestMethod]
        public void InsertNumber_DifferentNumbers_DifferentBits()
        {
            int input = BitsOperations.Algorithms.Extentions.InsertNumber(8, 15, 1, 2);
            Assert.AreEqual(14, input);
        }
        [TestMethod]
        public void InsertNumber_NegativeNumber_DifferentBits()
        {
            int input = BitsOperations.Algorithms.Extentions.InsertNumber(3,-1, 1, 2);
            Assert.AreEqual(7, input);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertNumber_DifferentNumber_InappropriateBits()
        {
            int input = BitsOperations.Algorithms.Extentions.InsertNumber(3, 10, -4, 2);          
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertNumber_SameNumber_InappropriateBits()
        {
            int input = BitsOperations.Algorithms.Extentions.InsertNumber(30, 10, 5, 33);
        }

    }
}
