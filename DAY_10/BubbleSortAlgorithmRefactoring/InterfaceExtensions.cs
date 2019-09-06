using System;
using System.Collections.Generic;

namespace MathExtensions
{
    public static partial class BubbleSortAlgorithmRefactoring
    {
        public static void BubbleSort(this int[][] array, Func<int[], int[], int> comparison)
        {
            IComparer<int[]> icomparer = new ComparisonAdapter(comparison);
            BubbleSort(array, icomparer);
        }

        public static void BubbleSort(this int[][] array, IComparer<int[]> comparer)
        {
            ThrowingExceptions(array, comparer);

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
                            check = true;
                        }
                    }
                }
            }
        }

        private static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        private class ComparisonAdapter : IComparer<int[]>
        {
            private readonly Func<int[], int[], int> _comparison;

            public ComparisonAdapter(Func<int[], int[], int> comparison)
            {
                _comparison = comparison;
            }

            public int Compare(int[] a, int[] b)
            {
                return _comparison(a, b);
            }
        }

        private static void ThrowingExceptions(int[][] array, IComparer<int[]> comparer)
        {

            if (array is null)
            {
                throw new ArgumentNullException("Jagged array can't be null.");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException("Jagged array can't be empty.");
            }

            if (comparer is null)
            {
                throw new ArgumentNullException("Can't sort the array without comparer criteria.");
            }
        }
    }
}
