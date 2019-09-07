using ExtentEvdalit;
using System;
using System.Collections.Generic;

namespace MathTasks
{
    /// <summary>
    /// Algorithms of sorting a jagged array.
    /// </summary>
    public static partial class SortAlgorithm
    {
        /// <summary>
        /// Bubble sort for jagged arrays.
        /// </summary>
        /// <param name="array">Input jagged array.</param>
        /// <param name="comparison">The comparison for array.</param>
        public static void BubbleSort(this int[][] array, Func<int[], int[], int> comparison)
        {
            ThrowingNullExceptions(array, "Array can not be null.");
            ThrowingNullExceptions(comparison, "You must enter comparer criteria.");
            ThrowingArgumentExceptions(array, "Aarray can not be empty.");

            IComparer<int[]> comparer = new ComparisonAdapter(comparison);
            BubbleSort(array, comparer);
        }

        /// <summary>
        /// Contains logic for Bubble sort of jagged array.
        /// </summary>
        /// <param name="array">Input jagged array.</param>
        /// <param name="comparer">The comparer for array.</param>
        private static void BubbleSortHelper(this int[][] array, IComparer<int[]> comparer)
        {
            if (array.Length == 1)
            {
                return;
            }

            for (int i = 0; i < array.Length - 1; i++)
            {
                bool check = true;
                while (check)
                {
                    check = false;
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (comparer.Compare(array[j], array[j + 1]) > 0)
                        {
                            Swap(ref array[j], ref array[j + 1]);
                        }
                    }
                }
            }
        }
    }
}
