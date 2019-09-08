using NUnit.Framework;
using System.Collections.Generic;
using BinarySearch.Algorithm;
using System;

namespace Tests
{
    public class SearchTests
    {
        [TestCase(new [] { 2,33,56,1,-5 }, -5, ExpectedResult = 4)]      
        [TestCase(new [] { 10, 56, 3, 15, 9, 7 }, 9, ExpectedResult = 4)]
        [TestCase(new [] { -9, 0, 3, -3, -1, 10, 1, 3, 5, 7, 9 }, 0, ExpectedResult = 1)]
        public int? BinarySearch_Int(int[] array, int element)
        {
            return Search.BinarySearch(array, element, Comparer<int>.Default);
        }
      
        [TestCase(new [] { "aaa", "bbb", "ccc" }, "bbb", ExpectedResult = 1)]
        [TestCase(new [] { "zzz", "bbb", "ccc" }, "bbb", ExpectedResult = 1)]
        [TestCase(new [] { "rewtre", "tre", "ttfc", "ercxxz" }, "ercxxz", ExpectedResult = 3)]
        public int? BinarySearch_String(string[] array, string element)
        {
            return Search.BinarySearch(array, element, Comparer<string>.Default);
        }
        
        [TestCase(null, "bbb")]
        [TestCase(new [] { "aaa", "bbb", "ccc" }, null)]
        public void BinarySearch_StringFail(string[] array, string element)
        {
            Assert.Throws<ArgumentNullException>(() => Search.BinarySearch(array, element, Comparer<string>.Default));
        }

        [TestCase(new [] { "aaa", "bbb", "ccc" }, "zzz")]
        public void BinarySearch_StringFail2(string[] a, string element)
        {
            Assert.Throws<ArgumentException>(() => Search.BinarySearch(a, element, Comparer<string>.Default));
        }

    }
}