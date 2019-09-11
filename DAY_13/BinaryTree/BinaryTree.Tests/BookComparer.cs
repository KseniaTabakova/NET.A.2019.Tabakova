using System;
using System.Collections.Generic;

namespace BinarySearchTreeTests
{
    public class BookComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if (x.Name.Length == y.Name.Length)
            {
                return 0;
            }

            if (x.Name.Length > y.Name.Length)
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