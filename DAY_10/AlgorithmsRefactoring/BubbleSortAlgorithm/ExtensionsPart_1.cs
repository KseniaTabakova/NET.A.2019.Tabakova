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
        /// <param name="comparer">The comparer for array.</param>
        public static void BubbleSort(this int[][] array, IComparer<int[]> comparer)
        {
            ThrowingNullExceptions(array, "Array can not be null.");
            ThrowingNullExceptions(comparer, "You must enter comparer criteria.");
            ThrowingArgumentExceptions(array, "Array can not be empty.");

            BubbleSort(array, comparer.Compare);
        }

        /// <summary>
        /// Contains logic for Bubble sort of jagged array.
        /// </summary>
        /// <param name="array">Input jagged array.</param>
        /// <param name="comparison">The comparison for array.</param>
        private static void BubbleSortHelper(this int[][] array, Func<int[], int[], int> comparison)
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
                        if (comparison(array[j], array[j + 1]) > 0)
                        {
                            Swap(ref array[j], ref array[j + 1]);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Swap two typeof<T> in array.
        /// </summary>
        /// <typeparam name="T">Type.</typeparam>
        /// <param name="a">The first typeof<T>.</param>
        /// <param name="b">The second typeof<T>.</param>
        private static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Throwing null exception in case of unforeseen consequence.
        /// </summary>
        /// <param name="array">Jagged array witch can couse an exception.</param>
        /// <param name="message">Message to be show.</param>
        private static void ThrowingNullExceptions(int[][] array, string message)
        {
            if (array is null)
            {
                throw new ArgumentNullException(message);
            }
        }

        /// <summary>
        /// Throwing null exception in case of unforeseen consequence.
        /// </summary>
        /// <param name="comparer">Comparer witch can couse an exception.</param>
        /// <param name="message">Message to be show.</param>
        private static void ThrowingNullExceptions(IComparer<int[]> comparer, string message)
        {
            if (comparer is null)
            {
                throw new ArgumentNullException(message);
            }
        }

        /// <summary>
        /// Throwing argument exception in case of unforeseen consequence.
        /// </summary>
        /// <param name="array">Jagged array witch can couse an exception.</param>
        /// <param name="message">Message to be show.</param>
        private static void ThrowingArgumentExceptions(int[][] array, string message)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException(message);
            }
        }

        /// <summary>
        /// Throwing null exception in case of unforeseen consequence.
        /// </summary>
        /// <param name="comparison">Comparison witch can couse an exception.</param>
        /// <param name="message">Message to be show.</param>
        private static void ThrowingNullExceptions(Func<int[], int[], int> comparison, string message)
        {
            if (comparison is null)
            {
                throw new ArgumentNullException(message);
            }
        }
    }
}
