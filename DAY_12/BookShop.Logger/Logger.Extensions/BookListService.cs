using OnlineBookstore.Library.BookSort;
using OnlineBookstore.Library.Exceptions;
using OnlineBookstore.Library.Helpers;
using OnlineBookstore.Library.Logger;
using OnlineBookstore.Library.Service;
using System;
using System.Collections.Generic;

namespace OnlineBookstore.Library
{

    public class BookListService : IBookService
    {

        private AbstractBookStorage booksRepository;
        private Logs logger;

        public BookListService(AbstractBookStorage storage)
        {
            booksRepository = storage;
            logger = new Logs();
        }

        public BookListService(AbstractBookStorage storage, Logs logger)
        {
            booksRepository = storage;
            this.logger = logger;
        }



        public bool AddBookToShop(Book book)
        {
            bool added = false;
            try
            {
                added = booksRepository.AddBook(book);
                if (added == true) logger.Info($"Book \"{book.Title}\" was added.");
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                throw;
            }

        }


        public bool RemoveBookFromShop(Book book)
        {
            bool removed = false;
            try
            {
                removed = booksRepository.RemoveBook(book);
                if (removed == true) logger.Info($"Book \"{book.Title}\" was removed.");
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                throw;
            }

        }

        public IList<Book> Refresh(AbstractBookStorage books)
        {
            try
            {
                booksRepository.Refresh(books);
                logger.Info($"Books were refreshed.");
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                throw;
            }
        }


        public Book FindBook(string isbn)
        {
            Book book = booksRepository.FindBook(isbn);
            return book;
        }


        public IEnumerable<Book> FindBooks(IFinder<Book> predicate, AbstractBookStorage books)
        {
            IList<Book> allBooksInStorage = Refresh(books);
            List<Book> findedBooks = new List<Book>();

            logger.Info($"Searching books by {predicate}.");

            foreach (var book in allBooksInStorage)
            {
                if (predicate.BookIsRight(book))
                {
                    findedBooks.Add(book);
                }
            }
            if (findedBooks.Count == 0)
                logger.Error("Error: we could't find book(s) with such criteria.");
            return findedBooks;
        }


        public IEnumerable<Book> SortBy(IBookComparer comparer)
        {
            List<Book> books = new List<Book>();

            logger.Info($"Sorting books by {comparer}.");

            Array.Sort(books.ToArray(), comparer);

            return books;
        }
    }
}
