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
            long bprev = 0;
            long prev = 1;

            for (int i = 0; i < length; ++i)
            {
                yield return bprev;

                var temp = prev;
                checked
                {
                    prev += bprev;
                }
                bprev = temp;
            }
        }
    }
}
