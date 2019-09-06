using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTasks.Algorithms
{
    /// <summary>
    /// Represents extensions for int-type array maniputon.
    /// </summary>
    public static class ArrayExtensions
    {
        /// <summary>
        /// Finds minimum number in a positive array with not considering a zero number.
        /// </summary>
        /// <param name="array">Target array.</param>
        /// <param name="index">Returns index of found number.</param>
        /// <returns></returns>
        public static int MinNumber(this int[] array, out int index)
        {
            int min = array.GetAbsOfNumber().Max();
            foreach (int number in array)
            {
                if (number <= min && number != 0)
                {
                    min = number;
                }
            }
            index = Array.IndexOf(array, min);
            return min;
        }

        /// <summary>
        /// Get the module of all numbers in array.
        /// </summary>
        /// <param name="array">Target array.</param>
        /// <returns>Modified array with absolute value of each presented number.</returns>
        public static int[] GetAbsOfNumber(this int[] array)
        {
            for (int j = 0; j < array.Length; j++)
            {
                array[j] = Math.Abs(array[j]);
            }
            return array;
        }
    }
}
