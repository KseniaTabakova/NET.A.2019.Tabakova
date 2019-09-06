using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ArrayOperations.Tests
{
    public class ArrayExtensionsTests
    { 
        [Test]
        public static void DoBubbleSort_Sum_Increasing()
        {
            int [][] input = { new int[] { 1, 2, 3, 4 }, new int[] { 1, 2 }, new int[] { 1, 2, 3 } };
            int[][] expected = { new int[] { 1, 2 }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4 } };
            int[][] result = ArrayExtensions.DoBubbleSort(input);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public static void DoBubbleSort_Sum_Decreasing()
        {
            int[][] input = { new int[] { 1, 2, 3, 4 }, new int[] { 1, 2 }, new int[] { 1, 2, 3 } };
            int[][] expected = { new int[] { 1, 2, 3,4 }, new int[] { 1, 2, 3 }, new int[] { 1, 2} };
            int[][] result = ArrayExtensions.DoBubbleSort(input, order: ArrayExtensions.Order.Decreasing);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public static void DoBubbleSort_Max_Increasing_NegativeNumbers()
        {
            int[][] input = { new int[] { 10, 29, 3, 4 }, new int[] { 1, 0 }, new int[] { -31, 256, 3, 8, 45 } };
            int[][] expected = { new int[] { 1,0  }, new int[] { 10, 29, 3, 4 }, new int[] { -31, 256, 3, 8, 45 } };
            int[][] result = ArrayExtensions.DoBubbleSort(input, sortingCriteria: ArrayExtensions.Criteria.MaximumElement);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public static void DoBubbleSort_Min_Decreasing()
        {
            int[][] input = { new int[] { 40, 29, 23, 4, 5 }, new int[] { -91, 29, 37, 4, 0 }, new int[] { -31, 256, 3, 8, 45 }, new int[] { 1, 256, 33, 8, 45, -45 } };
            int[][] expected = { new int[] { 40, 29, 23, 4, 5 }, new int[] { -31, 256, 3, 8, 45 }, new int[] { 1, 256, 33, 8, 45, -45 }, new int[] { -91, 29, 37, 4, 0 } };
            int[][] result = ArrayExtensions.DoBubbleSort(input, sortingCriteria: ArrayExtensions.Criteria.MinimumElement, order: ArrayExtensions.Order.Decreasing);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public static void DoBubbleSort_Sum_Increasing_TheSameNumbers()
        {
            int[][] input = { new int[] { 1,1,1,1 }, new int[] { 1 }, new int[] { 1,1,1,1,1,1,1,1,1 } };
            int[][] expected = { new int[] { 1 }, new int[] { 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1 } };
            int[][] result = ArrayExtensions.DoBubbleSort(input);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public static void DoBubbleSort_Sum_Increasing_OneArrayInside()
        {
            int[][] input = { new int[] { -15, 10, 12, 51 }};
            int[][] expected = { new int[] { -15, 10, 12, 51 } };
            int[][] result = ArrayExtensions.DoBubbleSort(input);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DoBubbleSort_NullArray()
        {
            Assert.Throws<System.ArgumentNullException>(_NullArrayTestBody);
        }

        private void _NullArrayTestBody()
        {
            int[][] input = null;
            ArrayExtensions.DoBubbleSort(input);
        }

        [Test]
        public void DoBubbleSort_NullArrayInside()
        {
            Assert.Throws<System.ArgumentNullException>(_NullArrayInsideTestBody);
        }

        private void _NullArrayInsideTestBody()
        {
            int[][] input = { null, new int[] { -91, 29, 37, 4, 0 }, new int[] { -31, 256, 3, 8, 45 }};
            ArrayExtensions.DoBubbleSort(input);
        }
    }
}
