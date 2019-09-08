using System;
using System.Collections.Generic;

namespace FibonacciAlgorithm
{
    /// <summary>
    /// Fibonacci sequence generation.
    /// </summary>
    public class Fibonacci
    {
        /// <summary>
        /// Method for Fibonacci sequence generation.
        /// </summary>
        /// <param name="length">Amount of numbers.</param>
        /// <returns>Sequence generation.</returns>
        public static IEnumerable<long> GetFibonacci(int length)
        {
            ThrowingArgumentExceptions(length, "Length should be bigger than zero.");         
            return DoFibonacchi(length);
        }

        /// <summary>
        /// Logic for Fibonacci sequence generation.
        /// </summary>
        /// <param name="length">Amount of numbers.</param>
        /// <returns>Sequence generation.</returns>       
        private static IEnumerable<long> DoFibonacchi(int length)
        {
            long current = 0;
            long previous = 1;

            for (int i = 0; i < length; ++i)
            {
                var temp = current;
                checked
                {
                    current += previous;
                }
                previous = temp;

                yield return current;
            }
        }

        /// <summary>
        /// Throwing argument exception in case of unforeseen consequence.
        /// </summary>
        /// <param name="array">Element witch can couse an exception.</param>
        /// <param name="message">Message to be show.</param>
        private static void ThrowingArgumentExceptions(int length, string message)
        {
            if (length <1)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
