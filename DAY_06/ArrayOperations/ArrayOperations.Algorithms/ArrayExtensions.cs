using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace ArrayOperations
{
    /// <summary>
    /// Class contains method for array sorting.
    /// </summary>
    public class ArrayExtensions
    {
        #region Jagged array bubble sorting method
        /// <summary>
        /// Method of jagged array sorting with different criteria and two possible orders.
        /// </summary>
        /// <param name="array">Input array.</param>
        /// <param name="sortingCriteria">Sorting array criteria.</param>
        /// <param name="order">Required order of sorted array.</param>
        /// <returns>Sorted jagged array with requirements.</returns>
        public static int[][] DoBubbleSort(int[][] array, Criteria sortingCriteria = Criteria.SumOfElements, Order order = Order.Increasing)
        {
            ThrowingNullExceptions(array, "No array has been given.");
            int[] sortedKeys=null;
            switch (sortingCriteria)
            {
                case Criteria.SumOfElements: sortedKeys = SortingCriteria.SummarizeElementsInEachRank(array);
                    break;
                case Criteria.MaximumElement: sortedKeys = SortingCriteria.GetMaximumElementInEachRank(array);
                    break;
                case Criteria.MinimumElement: sortedKeys = SortingCriteria.GetMinimumElementInEachRank(array);
                    break;
            }
            var dictionaryOfArrays = SplitArray(sortedKeys, array);
            
            int[][] sortedArray=null;
            switch (order)
            {
                case Order.Decreasing: sortedArray = GetDecreasingBubbleSort(sortedKeys, dictionaryOfArrays);
                    break;
                case Order.Increasing: sortedArray = GetIncreasingBubbleSort(sortedKeys, dictionaryOfArrays);
                    break;
            }

            return sortedArray;
        }

        #endregion

        #region Methods for increasind and decreasing sortion
        /// <summary>
        /// Increasing bubble sort.
        /// </summary>
        /// <param name="keys">Results of sorting criteria for jagged array.</param>
        /// <param name="dictionary">Dictionary of arrays and their criteria keys.</param>
        /// <returns>Sorted jagged array.</returns>
        private static int[][] GetIncreasingBubbleSort(int[] keys, Dictionary<int, int[]> dictionary)
        {
            for (int i = 0; i < keys.Length; i++)
            {
                for (int j = i + 1; j < keys.Length; j++)
                {
                    if (keys[i] > keys[j])
                    {
                        Swap(ref keys[i], ref keys[j]);
                    }
                }
            }
            return GetSortedJaggedArray(keys, dictionary);
        }

        /// <summary>
        /// Decreasing bubble sort.
        /// </summary>
        /// <param name="keys">Results of sorting criteria for jagged array.</param>
        /// <param name="dictionary">Dictionary of arrays and their criteria keys.</param>
        /// <returns>Sorted jagged array.</returns>
        private static int[][] GetDecreasingBubbleSort(int[] keys, Dictionary<int, int[]> dictionary)
        {
            for (int i = 0; i < keys.Length; i++)
            {
                for (int j = i + 1; j < keys.Length; j++)
                {
                    if (keys[i] < keys[j])
                    {
                        Swap(ref keys[i], ref keys[j]);
                    }
                }
            }
            return GetSortedJaggedArray(keys, dictionary);
        }

        #endregion

        #region Array's sorting helper methods
        /// <summary>
        /// Getting ordered rows of array 
        /// </summary>
        /// <param name="keys">Results of sorting criteria for jagged array.</param>
        /// <param name="dictionary">Dictionary of arrays and their criteria keys.</param>
        /// <returns>Sorted jagged array.</returns>
        private static int[][] GetSortedJaggedArray(int[] keys, Dictionary<int, int[]> dictionary)
        {
            int[][] sortedArray = new int[keys.Length][];
            for (int k = 0; k < keys.Length; k++)
            {
                sortedArray[k] = dictionary[keys[k]];
            }
            return sortedArray;
        }

        /// <summary>
        /// Changing places of values.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Association of rank sorting results with their arrays.
        /// </summary>
        /// <param name="keys">Results of sorting criteria for jagged array.</param>
        /// <param name="array">Input array.</param>
        /// <returns></returns>
        private static Dictionary<int, int[]> SplitArray(int[] keys, int[][] array)
        {
            var orderedArrays = new Dictionary<int, int[]>();

            for (int j = 0; j < keys.Length; j++)
            {
                orderedArrays[keys[j]] = array[j];
            }
            return orderedArrays;
        }

#endregion

        /// <summary>
        /// Throwing null exception in case of unforeseen consequence.
        /// </summary>
        /// <param name="array">Array witch can couse an exception.</param>
        /// <param name="message">Message to be show.</param>
        private static void ThrowingNullExceptions(int[][] array, string message)
        {
            if (array is null)
            {
                throw new ArgumentNullException(message);
            }
            foreach (int[] row in array)
                if(row==null)
                    throw new ArgumentNullException(message);
        }

        /// <summary>
        /// Enum of order criteria.
        /// </summary>
        public enum Order
        {
            Increasing =0,
            Decreasing=1
        }

        /// <summary>
        /// Enum of sorting criteria.
        /// </summary>
        public enum Criteria
        {
            SumOfElements = 0,
            MaximumElement = 1,
            MinimumElement = 2
        }
    }
}