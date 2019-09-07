using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree.comparers
{
    public class CustomBookComparer : IComparer<Book>
    {
      
        public int Compare(Book x, Book y)
        {
            return x.NumberOfPages.CompareTo(y.NumberOfPages);
        }
    }
}
