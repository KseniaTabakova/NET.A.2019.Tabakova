using System;
using System.Collections.Generic;

namespace BookExtensions.Service
{
    /// <summary>
    /// Class provides books service with a possibility of message log.
    /// </summary>
    public class BookListService : IBookService
    {
        /// <summary>
        /// Instance of storage.
        /// </summary>
        private AbstractBookStorage booksRepository;

        /// <summary>
        /// Instance of logger.
        /// </summary>
        private Logs logger;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="storage">Storage wich contain all books data.</param>
        public BookListService(AbstractBookStorage storage)
        {
            booksRepository = storage;
            logger = new Logs();
        }

        /// <summary>
        /// Constructor with a logger instance.
        /// </summary>
        /// <param name="storage">Storage wich contain all books data.</param>
        /// <param name="logger">Logger instance.</param>
        public BookListService(AbstractBookStorage storage, Logs logger)
        {
            booksRepository = storage;
            this.logger = logger;
        }

        /// <summary>
        /// Add book to the service's storage.
        /// </summary>
        /// <param name="book">Book which should be added to the storage.</param>
        /// <returns>Operation success status.</returns>
        public bool AddBookToShop(Book book)
        {
            bool added = false;
            try
            {
                added = booksRepository.AddBook(book);
                if (added == true)
                    logger.Info(@"Book ""{book.Title}"" was added.");
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                throw;
            }
        }

        /// <summary>
        /// Delete book from the service's storage.
        /// </summary>
        /// <param name="book">Book which should be deleted.
        /// <returns>Operation success status.</returns>
        public bool RemoveBookFromShop(Book book)
        {
            bool removed = false;
            try
            {
                removed = booksRepository.RemoveBook(book);
                if (removed == true)
                    logger.Info(@"Book ""{book.Title}"" was removed.");
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                throw;
            }
        }

        /// <summary>
        /// Refresh books local collection.
        /// </summary>
        /// <param name="books">Books to be saved.</param>
        /// <returns>Books collection.</returns>
        public IList<Book> Refresh(AbstractBookStorage books)
        {
            try
            {
                booksRepository.Refresh(books);
                logger.Info("Books were refreshed.");
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                throw;
            }
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

            logger.Info($"Searching books by {predicate} criteria.");

            foreach (var book in allBooksInStorage)
            {
                if (predicate.BookIsRight(book))
                {
                    findedBooks.Add(book);
                }
            }
            if (findedBooks.Count == 0)
                logger.Error("We can not find book(s) with such criteria.");
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

            logger.Info($"Sorting books by {comparer}.");
            Array.Sort(books.ToArray(), comparer);

            return books;
        }
    }
}
