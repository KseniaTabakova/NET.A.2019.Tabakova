using OnlineBookstore.Library.BookSort;
using OnlineBookstore.Library.Helpers;
using OnlineBookstore.Library.Exceptions;
using System;
namespace OnlineBookstore.Library.BookComparers
{
    /// <summary>
    /// Class provised sortion of books instances.
    /// </summary>
    public class BooksComparer : IBookComparer
    {
        /// <summary>
        /// Criteria with wich storage will be sort.
        /// </summary>
        private Tags tag;

        /// <summary>
        /// Constructor witch contain criteria for sorting.
        /// </summary>
        /// <param name="tag">Sort criteria.</param>
        public BooksComparer(Tags tag)
        {
            this.tag = tag;
        }

        /// <summary>
        /// Compare two instance of Books.
        /// </summary>
        /// <param name="x">The first book.</param>
        /// <param name="y">The second book.</param>
        /// <returns>The result of comparison.</returns>
        public int Compare(Book x, Book y)
        {
            if (x is null)
            {
                throw new BookNotExistsException("Error: there is nothing to compare!");
            }

            switch (tag)
            {
                case Tags.Author: return x.Author.CompareTo(y.Author);
                case Tags.ISBN: return x.ISBN.CompareTo(y.ISBN);
                case Tags.Title: return x.Title.CompareTo(y.Title);
                case Tags.Publisher: return x.Publisher.CompareTo(y.Publisher);
                case Tags.YearOfPublication: return x.YearOfPublication.CompareTo(y.YearOfPublication);
                case Tags.NumberOfPages: return x.NumberOfPages.CompareTo(y.NumberOfPages);
                case Tags.Price: return x.Price.CompareTo(y.Price);
                default: Console.WriteLine("Sorry, we have nothing to show you today."); return int.Parse(DateTime.Now.ToString());
            }         
        }
    }

}
