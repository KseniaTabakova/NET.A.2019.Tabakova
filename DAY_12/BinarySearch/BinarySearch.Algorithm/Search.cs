using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch.Algorithm
{
    public class Search
    {
        public static int? BinarySearch<T>(T[] a, T element, IComparer<T> comparer)
        {
            return BinarySearch(a, element, comparer.Compare);
        }
      
        public static int? BinarySearch<T>(T[] a, T element, Comparison<T> comparison)
        {
            ThrowingExceptions(a, element, comparison);

            if (a.Length == 0)
            {
                return null;
            }

            int first = 0;
            int last = a.Length;

            while (first < last)
            {
                int mid = first + (last - first) / 2;

                if (comparison(element, a[mid]) <= 0)
                {
                    last = mid;
                }
                else
                {
                    first = mid + 1;
                }
            }

            if (comparison(a[last], element) == 0)
            {
                return last;
            }
            else
            {
                return null;
            }
        }

        private static void ThrowingExceptions<T>(T[] a, T element, Comparison<T> comparison)
        {
            if (a == null)
            {
                throw new ArgumentNullException($"Input can't be null.");
            }

            if (element == null)
            {
                throw new ArgumentNullException($"Number can't be null.");
            }

            if ((comparison(element, a[0]) < 0) || (comparison(element, a[a.Length - 1]) > 0))
            {
                throw new ArgumentException("Element is out of range.");
            }
        }

    }
}
