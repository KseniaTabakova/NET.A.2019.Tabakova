using NUnit.Framework;
using System.Collections.Generic;
using System;
using BinarySearch.Algorithm;

namespace AlgorithmsTests
{
    public class SearchTests
    {
        [TestCase(new int[] { 0, 1, 3, 5, 7, 9 }, 3, ExpectedResult = 2)]
        [TestCase(new int[] { }, 3, ExpectedResult = null)]
        [TestCase(new int[] { 0, 1, 3, 5, 7, 9 }, 9, ExpectedResult = 5)]
        [TestCase(new int[] { -9, -7, -5, -3, -1, 0, 1, 3, 5, 7, 9 }, 0, ExpectedResult = 5)]
        public int? BinarySearch_Int(int[] a, int element)
        {
            return Search.BinarySearch(a, element, Comparer<int>.Default);
        }

        [TestCase(new int[] { 0, 1, 3, 5, 7, 9 }, 3, ExpectedResult = 2)]
        [TestCase(new int[] { }, 3, ExpectedResult = null)]
        [TestCase(new int[] { 0, 1, 3, 5, 7, 9 }, 9, ExpectedResult = 5)]
        [TestCase(new int[] { -9, -7, -5, -3, -1, 0, 1, 3, 5, 7, 9 }, 0, ExpectedResult = 5)]
        public int? BinarySearch_Int_Delegate(int[] a, int element)
        {
            return Search.BinarySearch(a, element, (lhs, rhs) => lhs.CompareTo(rhs));
        }

       
        [TestCase(new double[] { 0.312, 1.235, 3.56, 5.002, 7.1234, 9.1231 }, 3.56, ExpectedResult = 2)]
        [TestCase(new double[] { 0.312, 0.312123, 0.3128797, 0.31299999 }, 0.3128797, ExpectedResult = 2)]
        public int? BinarySearch_Double_Delegate(double[] a, double element)
        {
            return Search.BinarySearch(a, element, (lhs, rhs) => lhs.CompareTo(rhs));
        }

        [TestCase(new string[] { "aaa", "bbb", "ccc" }, "bbb", ExpectedResult = 1)]
        [TestCase(new string[] { "aaaa", "bbb", "ccc" }, "bbb", ExpectedResult = 1)]
        [TestCase(new string[] { "Apoijlj", "falKovIch", "Ksenia", "Yabdmf" }, "Ksenia", ExpectedResult = 2)]
        public int? BinarySearch_String(string[] a, string element)
        {
            return Search.BinarySearch(a, element, Comparer<string>.Default);
        }

        [TestCase(new string[] { "aaa", "bbb", "ccc" }, "bbb", ExpectedResult = 1)]
        [TestCase(new string[] { "aaaa", "bbb", "ccc" }, "bbb", ExpectedResult = 1)]
        [TestCase(new string[] { "Apoijlj", "falKovIch", "Ksenia", "Yabdmf" }, "Ksenia", ExpectedResult = 2)]
        public int? BinarySearch_String_Delegate(string[] a, string element)
        {
            return Search.BinarySearch(a, element, (lhs, rhs) => lhs.CompareTo(rhs));
        }

        [TestCase(null, "bbb")]
        [TestCase(new string[] { "aaa", "bbb", "ccc" }, null)]
        public void BinarySearch_StringFail(string[] a, string element)
        {
            Assert.Throws<ArgumentNullException>(() => Search.BinarySearch(a, element, Comparer<string>.Default));
        }

        [TestCase(new string[] { "aaa", "bbb", "ccc" }, "ddd")]
        public void BinarySearch_StringFail2(string[] a, string element)
        {
            Assert.Throws<ArgumentException>(() => Search.BinarySearch(a, element, Comparer<string>.Default));
        }
    }
}