using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookstore.Library.BookSort
{
    /// <summary>
    /// Interface provides new version of the method for sorting.
    /// </summary>
    public interface IBookComparer : IComparer<Book>
    {
        /// <summary>
        /// Compare two instance of Books.
        /// </summary>
        /// <param name="x">The first book.</param>
        /// <param name="y">The second book.</param>
        /// <returns>The result of comparison.</returns>
        new int Compare(Book x, Book y);
    }
}
