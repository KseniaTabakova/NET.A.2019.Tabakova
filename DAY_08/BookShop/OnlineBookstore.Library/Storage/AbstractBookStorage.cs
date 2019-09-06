using OnlineBookstore.Library.Exceptions;
using OnlineBookstore.Library.Helpers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OnlineBookstore.Library
{
    /// <summary>
    /// Class represents common functionality for books storage.
    /// </summary>
    public abstract class AbstractBookStorage : IFileSystem, IEnumerable<Book>
    {
        /// <summary>
        /// Storage for books.
        /// </summary>
        protected internal List<Book> booksStorage = new List<Book>();

        /// <summary>
        /// Add book to the storage.
        /// </summary>
        /// <param name="book">Book which should be added to the storage.</param>
        /// <returns>Operation success status.</returns>
        public virtual bool AddBook(Book book)
        {
            if (this.booksStorage.Contains(book))
            {
                throw new BookAlreadyExistsException("Error: storage already contains book with the same ISBN.");
            }
            this.booksStorage.Add(book);
            return true;
        }

        /// <summary>
        /// Delete book from the storage.
        /// </summary>
        /// <param name="book">Book which should be deleted from the storage.</param>
        /// <returns>Operation success status.</returns>
        public virtual bool RemoveBook(Book book)
        {
            if (!this.booksStorage.Contains(book))
            {
                throw new BookNotExistsException("Error: storage doesn't contain such book.");
            }

            this.booksStorage.Remove(book);
            return true;
        }

        /// <summary>
        /// Returns instance of book.
        /// </summary>
        /// <param name="isbn">Book isbn.</param>
        /// <returns>Instance of book.</returns>
        public Book FindBook(string isbn)
        {
            if (booksStorage.Find(t => t.ISBN == isbn) is null)
                throw new BookNotExistsException("Storage has't got such book.");
            Book bookToFind = (from book in booksStorage
                               where book.ISBN == isbn
                               select book).First();
            return bookToFind;
        }

        /// <summary>
        /// Save books to the local file.
        /// </summary>
        /// <param name="books">Books to be saved.</param>
        public abstract void SaveBooks(IEnumerable<Book> books);

        /// <summary>
        /// Load books from the local file to the storage.
        /// </summary>
        /// <returns>Books collection.</returns>
        public abstract IList<Book> LoadBooks();

        /// <summary>
        /// Refresh books local collection by implementing save and load functions.
        /// </summary>
        /// <param name="books">Books to be saved.</param>
        /// <returns>Books collection.</returns>
        public virtual IList<Book> Refresh(IEnumerable<Book> books)
        {
            SaveBooks(books);
            return LoadBooks();
        }

        /// <summary>
        /// Count books in the storage.
        /// </summary>
        /// <returns>The amount of books in the storage.</returns>
        public int Count()
        {
            return booksStorage.Count;
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return booksStorage.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
