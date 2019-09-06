using OnlineBookstore.Library.BookSort;
using OnlineBookstore.Library.Exceptions;
using OnlineBookstore.Library.Helpers;
using OnlineBookstore.Library.Service;
using System;
using System.Collections.Generic;

namespace OnlineBookstore.Library
{
    /// <summary>
    /// Class provides books service.
    /// </summary>
    public class BookListService : IBookService
    {
        /// <summary>
        /// Instance of storage.
        /// </summary>
        private AbstractBookStorage booksRepository;

        /// <summary>
        /// Constrictor.
        /// </summary>
        /// <param name="storage">Storage wich contain all books data.</param>
        public BookListService(AbstractBookStorage storage)
        {         
            booksRepository = storage;        
        }

        /// <summary>
        /// Add book to the service's storage.
        /// </summary>
        /// <param name="book">Book which should be added to the storage.</param>
        /// <returns>Operation success status.</returns>
        public bool AddBookToShop(Book book)
        {
            return booksRepository.AddBook(book);
        }

        /// <summary>
        /// Delete book from the service's storage.
        /// </summary>
        /// <param name="book">Book which should be deleted.
        /// <returns>Operation success status.</returns>
        public bool RemoveBookFromShop(Book book)
        {
            return booksRepository.RemoveBook(book);
        }

        /// <summary>
        /// Refresh books local collection.
        /// </summary>
        /// <param name="books">Books to be saved.</param>
        /// <returns>Books collection.</returns>
        public IList<Book> Refresh(AbstractBookStorage books)
        {
            return booksRepository.Refresh(books);          
        }

        /// <summary>
        /// Returns instance of book.
        /// </summary>
        /// <param name="isbn">Book isbn.</param>
        /// <returns>Instance of book.</returns>
        public Book FindBook(string isbn)
        {
            Book book = booksRepository.FindBook(isbn);
            return book;
        }

        /// <summary>
        /// Find appropriate books through books collection.
        /// </summary>
        /// <param name="parameter">Criteria.</param>
        /// <param name="books">Collection.</param>
        /// <returns>Appropriate books collection.</returns>
        public IEnumerable<Book> FindBooks(IFinder<Book> predicate, AbstractBookStorage books)
        {
            IList<Book> allBooksInStorage = Refresh(books);
            List<Book> findedBooks = new List<Book>();

            foreach (var book in allBooksInStorage)
            {
                if (predicate.BookIsRight(book))
                {
                    findedBooks.Add(book);
                }
            }
            if (findedBooks.Count == 0)
                throw new BookNotExistsException("Error: we could't find book(s) with such criteria.");
            return findedBooks;
        }

        /// <summary>
        /// Sort books collection with appropriate criteria.
        /// </summary>
        /// <param name="comparator">Criteria.</param>
        /// <returns>Sorted collection.</returns>
        public IEnumerable<Book> SortBy(IBookComparer comparer)
        {
            List<Book> books = new List<Book>();

            //тот ли это метод
            Array.Sort(books.ToArray(), comparer);

            return books;
        }
    }
}
