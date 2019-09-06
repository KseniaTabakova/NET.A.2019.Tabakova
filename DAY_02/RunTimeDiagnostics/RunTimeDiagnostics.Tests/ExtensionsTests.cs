using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RunTimeDiagnistics;

namespace NumberFinder.Tests
{
    [TestClass]
    public class ExtensionsTests
    {
        [TestMethod]
        public void FixTotalRunTime_FindNextBiggerNumber_BigNumber()
        {
            string diagnosticsResult;
            var t = Diagnostics.FixTotalRunTime(Algorithms.Extensions.FindNextBiggerNumber, 1234567655,
                out diagnosticsResult);
            Assert.AreEqual(1234575566, t, diagnosticsResult);
        }

        [TestMethod]
        public void FixTotalRunTime_FindNextBiggerNumber_ConsecutiveNumbers()
        {
            string diagnosticsResult;
            var t = Diagnostics.FixTotalRunTime(Algorithms.Extensions.FindNextBiggerNumber, 513,
                out diagnosticsResult);
            Assert.AreEqual(531, t, diagnosticsResult);
        }

        [TestMethod]
        public void FixTotalRunTime_FindNextBiggerNumber_BigRandomNumber()
        {
            string diagnosticsResult;
            var t = Diagnostics.FixTotalRunTime(Algorithms.Extensions.FindNextBiggerNumber,3456432,
                out diagnosticsResult);
            Assert.AreEqual(3462345, t, diagnosticsResult);       
        }

        [TestMethod]
        public void FixTotalRunTime_FindNextBiggerNumber_DecreasingNumbers()
        {
            string diagnosticsResult;
            var t = Diagnostics.FixTotalRunTime(Algorithms.Extensions.FindNextBiggerNumber, 654321,
                out diagnosticsResult);
            Assert.AreEqual(654321, t, diagnosticsResult);
        }

        [TestMethod]
        public void FixTotalRunTime_FindNextBiggerNumber_UniqueNumber()
        {
            string diagnosticsResult;
            var t = Diagnostics.FixTotalRunTime(Algorithms.Extensions.FindNextBiggerNumber, 9,
                out diagnosticsResult);
            Assert.AreEqual(9, t, diagnosticsResult);
        }
    }
}
