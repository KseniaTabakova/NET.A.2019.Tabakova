// <copyright file="Extensions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ArraySorting.Algorithms
{
    using System;

    /// <summary>
    /// Class provides Merge Sort and Quick Sort algorithms for Int32.
    /// </summary>
    public class Extensions
    {
        #region Methods to impliment MergeSort

        /// <summary>
        /// Merge Sort of the <paramref name="array" />.
        /// </summary>
        /// <param name="array">The array which will be sort.</param>
        public static void MergeSort(int[] array)
        {
            ThrowingNullExceptions(array, "No array has been given.");
            ThrowingOutOfRangeException(array, "No arguments has been given.");
            MergeSortHelper(ref array, 0, array.Length - 1);
        }

        /// <summary>
        /// Recursive division into 2 arrays.
        /// </summary>
        /// <param name="array">Dividing array.</param>
        /// <param name="start">The start of sorting position.</param>
        /// <param name="end">The end of sorting position.</param>
        private static void MergeSortHelper(ref int[] array, int start, int end)
        {
            if (start < end)
            {
                int middle = (start + end) / 2;
                MergeSortHelper(ref array, start, middle);
                MergeSortHelper(ref array, middle + 1, end);

                Merge(ref array, start, middle, end);
            }
        }

        /// <summary>
        /// Merge of 2 arrays.
        /// </summary>
        /// <param name="array">Detachable array.</param>
        /// <param name="start">The start of sorting position.</param>
        /// <param name="middle">The middle of the array.</param>
        /// <param name="end">The end of sorting position.</param>
        private static void Merge(ref int[] array, int start, int middle, int end)
        {
            int leftArrayLength = middle - start + 1;
            int rigthArrayLength = end - middle;
            int i, j, k;

            int[] leftArray = new int[leftArrayLength];
            int[] rightArray = new int[rigthArrayLength];
            for (i = 0; i < leftArrayLength; i++)
            {
                leftArray[i] = array[start + i];
            }

            for (j = 0; j < rigthArrayLength; j++)
            {
                rightArray[j] = array[middle + 1 + j];
            }

            i = 0;
            j = 0;
            k = start;

            while (i < leftArrayLength && j < rigthArrayLength)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    array[k++] = leftArray[i++];
                }
                else
                {
                    array[k++] = rightArray[j++];
                }
            }

            while (i < leftArrayLength)
            {
                array[k++] = leftArray[i++];
            }

            while (j < rigthArrayLength)
            {
                array[k++] = rightArray[j++];
            }
        }

        #endregion

        #region Methods to impliment QuickSort

        /// <summary>
        /// Quick Sort of the <paramref name="array" />.
        /// </summary>
        /// <param name="array">The array which will be sort.</param>
        public static void QuickSort(int[] array)
        {
            ThrowingNullExceptions(array, "No array has been given.");
            ThrowingOutOfRangeException(array, "No arguments has been given.");
            QuickSortHelper(ref array, 0, array.Length - 1);
        }

        /// <summary>
        /// Recursive division into 2 arrays.
        /// </summary>
        /// <param name="array">Dividing array.</param>
        /// <param name="start">The start of sorting position.</param>
        /// <param name="end">The end of sorting position.</param>
        private static void QuickSortHelper(ref int[] array, int start, int end)
        {
            if (start < end)
            {
                int positionOfSelectedElement = Division(array, start, end);

                QuickSortHelper(ref array, start, positionOfSelectedElement - 1);
                QuickSortHelper(ref array, positionOfSelectedElement + 1, end);
            }
        }

        /// <summary>
        /// Distribution of the main element in array.
        /// </summary>
        /// <param name="array">Detachable array.</param>
        /// <param name="start">The start of sorting position.</param>
        /// <param name="end">The end of sorting position.</param>
        /// <returns>Position of the main element.</returns>
        private static int Division(int[] array, int start, int end)
        {
            int mainElement = array[end];
            int index = start;

            for (int i = start; i < end; i++)
            {
                if (array[i] < mainElement)
                {
                    Swap(array, i, index);
                    index++;
                }
            }

            Swap(array, index, end);
            return index;
        }

        #endregion

        /// <summary>
        /// Throwing null exception in case of unforeseen consequence.
        /// </summary>
        /// <param name="array">Array witch can couse an exception.</param>
        /// <param name="message">Message to be show.</param>
        private static void ThrowingNullExceptions(int[] array, string message)
        {
            if (array is null)
            {
                throw new ArgumentNullException(message);
            }
        }

        /// <summary>
        /// Throwing out of range exception in case of unforeseen consequence.
        /// </summary>
        /// <param name="array">Array witch can couse an exception.</param>
        /// <param name="message">Message to be show.</param>
        private static void ThrowingOutOfRangeException(int[] array, string message)
        {
            if (array.Length == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Interchange of places.
        /// </summary>
        /// <param name="array">Detachable array.</param>
        /// <param name="a">First element.</param>
        /// <param name="b">Second element.</param>
        private static void Swap(int[] array, int a, int b)
        {
            int temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }
    }
}
