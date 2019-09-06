using System;
using System.Collections.Generic;

namespace Fibonachi
{
    public class Fibonachi
    {
        public static IEnumerable<long> GetFibonachi(int length)
        {
            if (length < 1)
            {
                throw new ArgumentException("Sequence Length should be bigger than 0!");
            }

            return DoFibonachi(length);
        }

        private static IEnumerable<long> DoFibonachi(int length)
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
    }
}
