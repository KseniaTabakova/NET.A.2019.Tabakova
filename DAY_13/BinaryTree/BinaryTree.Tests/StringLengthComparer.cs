using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    namespace BinarySearchTreeTests
    {
        public class StringLengthComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                if (x.Length == y.Length)
                {
                    return 0;
                }

                if (x.Length > y.Length)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        }
    }
}
