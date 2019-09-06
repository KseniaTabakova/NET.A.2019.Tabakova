using System.Collections.Generic;
using OnlineBookstore.Library.Helpers;
using OnlineBookstore.Library.BookSort;

namespace OnlineBookstore.Library.Service
{
    /// <summary>
    /// Interface of books functionality service.
    /// </summary>
    public interface IBookService
    {
        /// <summary>
        /// Add book to the service's storage.
        /// </summary>
        /// <param name="book">Book which should be added to the storage.</param>
        /// <returns>Operation success status.</returns>
        bool AddBookToShop(Book book);

        /// <summary>
        /// Delete book from the service's storage.
        /// </summary>
        /// <param name="book">Book which should be deleted.
        /// <returns>Operation success status.</returns>
        bool RemoveBookFromShop(Book book);

        /// <summary>
        /// Find appropriate books through books collection.
        /// </summary>
        /// <param name="parameter">Criteria.</param>
        /// <param name="books">Collection.</param>
        /// <returns>Appropriate books collection.</returns>
        IEnumerable<Book> FindBooks(IFinder<Book> parameter, AbstractBookStorage books);

        /// <summary>
        /// Refresh books local collection.
        /// </summary>
        /// <param name="books">Books to be saved.</param>
        /// <returns>Books collection.</returns>
        IList<Book> Refresh(AbstractBookStorage books);

        /// <summary>
        /// Sort books collection with appropriate criteria.
        /// </summary>
        /// <param name="comparator">Criteria.</param>
        /// <returns>Sorted collection.</returns>
        IEnumerable<Book> SortBy(IBookComparer comparator);
    }
}
