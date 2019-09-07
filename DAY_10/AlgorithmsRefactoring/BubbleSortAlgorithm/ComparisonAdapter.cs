using System;
using System.Collections.Generic;

namespace MathTasks
{
    /// <summary>
    /// Adapter transforms the interface of one class into the interface of another.
    /// </summary>
    internal class ComparisonAdapter : IComparer<int[]>
    {
        /// <summary>
        /// Adaptable member.
        /// </summary>
        private readonly Func<int[], int[], int> _comparison;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="comparison">Adaptable member.</param>
        public ComparisonAdapter(Func<int[], int[], int> comparison)
        {
            _comparison = comparison;
        }

        /// <summary>
        /// Method that is used.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <returns>Number - comparison result.</returns>
        public int Compare(int[] a, int[] b)
        {
            return _comparison(a, b);
        }
    }
}
