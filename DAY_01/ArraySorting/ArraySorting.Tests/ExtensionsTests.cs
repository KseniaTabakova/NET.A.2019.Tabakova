using ArraySorting.Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static ArraySorting.Algorithms.Extensions;

namespace ArraySorting.UnitTests
{
    [TestClass]
    public class ExtensionsTests
    {
        #region Merge Sort tests

        [TestMethod]
        public void MergeSort_ArrayWithOneElement()
        {
            int[] input = {3};
            int[] expected = {3};
            MergeSort(input);
            CollectionAssert.AreEqual(expected, input);
        }

        [TestMethod]
        public void MergeSort_UniqueArrayElements()
        {
            int[] input = {10, 5, 91, 78, 23};
            int[] expected = {5, 10, 23, 78, 91};
            MergeSort(input);
            CollectionAssert.AreEqual(expected, input);
        }

        [TestMethod]
        public void MergeSort_ArrayWithNegativeElements()
        {
            int[] input = {-1, 0, -23, 86, 9, 9, 9, 9, 9, -10};
            int[] expected = {-23, -10, -1, 0, 9, 9, 9, 9, 9, 86};
            MergeSort(input);
            CollectionAssert.AreEqual(expected, input);
        }

        [TestMethod]
        public void MergeSort_ReverseSortedArray()
        {
            int[] input = {90, 85, 81, 55, 28, 20, 16, 13};
            int[] expected = {13, 16, 20, 28, 55, 81, 85, 90};
            MergeSort(input);
            CollectionAssert.AreEqual(expected, input);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MergeSort_NullArray()
        {
            int[] input = null;
            MergeSort(input);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MergeSort_ArrayWithoutElements()
        {
            int[] input = { };
            MergeSort(input);

        }

        public void MergeSort_UnchangedArray()
        {
            int[] input = {13, 16, 20, 28, 55, 81, 85, 90};
            MergeSort(input);
            CollectionAssert.AreEqual(input, input);
        }

        #endregion

        #region Quick Sort tests

        [TestMethod]
        public void QuickSort_UnchangedArray()
        {
            int[] input = {0, 5, 12, 34, 47, 99};
            QuickSort(input);
            CollectionAssert.AreEqual(input, input);

        }

        [TestMethod]
        public void QuickSort_ReverseSortedArray()
        {
            int[] input = {9, 8, 8, 6, 5, 4, 1};
            int[] expected = {1,4,5,6,8,8,9};
            QuickSort(input);
            CollectionAssert.AreEqual(expected, input);
        }

        [TestMethod]
        public void QuickSort_ArrayWithOneElement()
        {
            int[] input = { 101 };
            int[] expected = { 101 };
            QuickSort(input);
            CollectionAssert.AreEqual(expected, input);
        }
        [TestMethod]
        public void QuickSort_ArrayWithNegativeElements()
        {
            int[] input = { -1, 0, -23, 86, 9, -10 };
            int[] expected = { -23, -10, -1, 0, 9, 86 };
            QuickSort(input);
            CollectionAssert.AreEqual(expected, input);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void QuickSort_NullArray()
        {
            int[] input = null;
            QuickSort(input);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void QuickSort_ArrayWithoutElements()
        {
            int[] input = { };
            QuickSort(input);

        }

        #endregion
    }
}