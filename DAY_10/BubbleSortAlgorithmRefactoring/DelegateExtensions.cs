using System;
using System.Collections.Generic;

namespace MathExtensions
{
    public static partial class BubbleSortAlgorithmRefactoring
    {
        public static void BubbleSort(this int[][] array, IComparer<int[]> comparer)
        {
            BubbleSort(array, comparer.Compare);
        }
        
        public static void BubbleSort(this int[][] array, Func<int[], int[], int> comparison)
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
                        if (comparison(array[j], array[j + 1]) > 0)
                        {
                            Swap(ref array[j], ref array[j + 1]);
                            check = true;
                        }
                    }
                }
            }
        }               
    }
}
