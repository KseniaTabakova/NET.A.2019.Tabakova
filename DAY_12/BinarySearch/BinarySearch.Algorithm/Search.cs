using System;
using System.Collections.Generic;

namespace BinarySearch.Algorithm
{
    /// <summary>
    /// Class of binary search realization.
    /// </summary>
    public class Search
    {
        /// <summary>
        /// Implements binaty search.
        /// </summary>
        /// <typeparam name="T">Type.</typeparam>
        /// <param name="array">Given array.</param>
        /// <param name="element">Find element.</param>
        /// <param name="comparer">Comparer.</param>
        /// <returns>Index of element.</returns>
        public static int? BinarySearch<T>(T[] array, T element, IComparer<T> comparer)
        {
            ThrowingNullExceptions(array, "Array can not be null.");
            ThrowingArgumentExceptions(array, "Array can not be empty.");
            ThrowingNullExceptions(element, "Element can not be null");

            return BinarySearch(array, element, comparer.Compare);
        }

        /// <summary>
        /// Implements binaty search.
        /// </summary>
        /// <typeparam name="T">Type.</typeparam>
        /// <param name="array">Given array.</param>
        /// <param name="element">Find element.</param>
        /// <param name="comparison">Comparer.</param>
        /// <returns>Index of element.</returns>
        private static int? BinarySearch<T>(T[] array, T element, Comparison<T> comparison)
        {          
            int first = 0;
            int last = array.Length-1;

            while (first <= last)
            {
                int mid = (last + first) / 2;
                
                if (comparison(element, array[mid]) < 0)
                {
                    first = mid + 1;
                }
                else if (comparison(element, array[mid]) > 0)
                {
                    last = mid - 1;
                }
                else if (comparison(element, array[mid]) == 0)
                {
                    return mid;
                }
            }
                return null;
        }

        /// <summary>
        /// Throwing null exception in case of unforeseen consequence.
        /// </summary>
        /// <param name="array">Array witch can couse an exception.</param>
        /// <param name="message">Message to be show.</param>
        private static void ThrowingNullExceptions<T>(T[] array, string message)
        {
            if (array == null)
            {
                throw new ArgumentNullException(message);
            }
        }

        /// <summary>
        /// Throwing argument exception in case of unforeseen consequence.
        /// </summary>
        /// <param name="array">Array witch can couse an exception.</param>
        /// <param name="message">Message to be show.</param>
        private static void ThrowingArgumentExceptions<T>(T[] array, string message)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException(message);
            }
        }

        /// <summary>
        /// Throwing null exception in case of unforeseen consequence.
        /// </summary>
        /// <param name="element">Element witch can couse an exception.</param>
        /// <param name="message">Message to be show.</param>
        private static void ThrowingNullExceptions<T>(T element, string message)
        {
            if (element == null)
            {
                throw new ArgumentNullException(message);
            }
        }

    }
}
