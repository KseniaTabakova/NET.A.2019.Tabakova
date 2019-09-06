using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumericExtentions.Tests
{
    [TestClass]
    public class ConverterTests
    {
        [TestMethod]
        [Timeout(3000)]
        public void GetBinaryValue_NegativeNumber()
        {
            double input = -255.255;
            string result = NumericExtentions.DoubleExtentions.Converter.GetBinaryValue(input, 64, 11);
            string expected = "1100000001101111111010000010100011110101110000101000111101011100";
           Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [Timeout(3000)]
        public void GetBinaryValue_PositiveNumber()
        {
            double input = 255.255;
            string result = NumericExtentions.DoubleExtentions.Converter.GetBinaryValue(input, 64, 11);
            string expected = "0100000001101111111010000010100011110101110000101000111101011100";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [Timeout(3000)]
        public void GetBinaryValue_BigPositiveNumberVer1()
        {
            double input = 42949672.0;
            string result = NumericExtentions.DoubleExtentions.Converter.GetBinaryValue(input, 64, 11);
            string expected = "0100000110000100011110101110000101000000000000000000000000000000";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [Timeout(3000)]
        public void GetBinaryValue_BigPositiveNumberVer2()
        {
            double input = 4294967295.0;
            string result = NumericExtentions.DoubleExtentions.Converter.GetBinaryValue(input, 64, 11);
            string expected = "0100000111101111111111111111111111111111111000000000000000000000";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [Timeout(3000)]
        public void GetBinaryValue_MinDoubleNumber()
        {
            double input = double.MinValue;
            string result = NumericExtentions.DoubleExtentions.Converter.GetBinaryValue(input, 64, 11);
            string expected = "1111111111101111111111111111111111111111111111111111111111111111";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [Timeout(3000)]
        public void GetBinaryValue_MaxDoubleNumber()
        {
            double input = double.MaxValue;
            string result = NumericExtentions.DoubleExtentions.Converter.GetBinaryValue(input, 64, 11);
            string expected = "0111111111101111111111111111111111111111111111111111111111111111";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [Timeout(3000)]
        public void GetBinaryValue_EpsilonDoubleNumber()
        {
            double input = double.Epsilon;
            string result = NumericExtentions.DoubleExtentions.Converter.GetBinaryValue(input, 64, 11);
            string expected = "0000000000000000000000000000000000000000000000000000000000000001";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [Timeout(3000)]
        public void GetBinaryValue_NaNDoubleNumber()
        {
            double input = double.NaN;
            string result = NumericExtentions.DoubleExtentions.Converter.GetBinaryValue(input, 64, 11);
            string expected = "1111111111111000000000000000000000000000000000000000000000000000";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [Timeout(3000)]
        public void GetBinaryValue_NegativeInfinityDoubleNumber()
        {
            double input = double.NegativeInfinity;
            string result = NumericExtentions.DoubleExtentions.Converter.GetBinaryValue(input, 64, 11);
            string expected = "1111111111110000000000000000000000000000000000000000000000000000";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [Timeout(3000)]
        public void GetBinaryValue_PositiveInfinityDoubleNumber()
        {
            double input = double.PositiveInfinity;
            string result = NumericExtentions.DoubleExtentions.Converter.GetBinaryValue(input, 64, 11);
            string expected = "0111111111110000000000000000000000000000000000000000000000000000";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [Timeout(3000)]
        public void GetBinaryValue_NegativeZeroDoubleNumber()
        {
            double input = -0.0;
            string result = NumericExtentions.DoubleExtentions.Converter.GetBinaryValue(input, 64, 11);
            string expected = "1000000000000000000000000000000000000000000000000000000000000000";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [Timeout(3000)]
        public void GetBinaryValue_PositiveZeroDoubleNumber()
        {
            double input = 0.0;
            string result = NumericExtentions.DoubleExtentions.Converter.GetBinaryValue(input, 64, 11);
            string expected = "0000000000000000000000000000000000000000000000000000000000000000";
            Assert.AreEqual(expected, result);
        }
    }
}
