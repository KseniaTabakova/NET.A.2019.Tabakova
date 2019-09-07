using System;
using System.Collections.Generic;
using System.IO;

namespace OnlineBookstore.Library
{
    /// <summary>
    /// Class represents books storage.
    /// </summary>
    public class BookListStorage : AbstractBookStorage
    {
        /// <summary>
        /// Path to the binary file in the local PC.
        /// </summary>
        private readonly string basePath = AppDomain.CurrentDomain.BaseDirectory + "books.dat";

        /// <summary>
        /// Save books to the local file.
        /// </summary>
        /// <param name="books">Books to be saved.</param>
        public override void SaveBooks(IEnumerable<Book> books)
        {
            using (var writer = new BinaryWriter(File.Open(basePath, FileMode.Create, FileAccess.Write)))
            {
                foreach (var book in books)
                {
                    writer.Write(book.ISBN);
                    writer.Write(book.Author);
                    writer.Write(book.Title);
                    writer.Write(book.Publisher);
                    writer.Write(book.YearOfPublication);
                    writer.Write(book.Price);
                    writer.Write(book.NumberOfPages);
                }
            }
        }

        /// <summary>
        /// Load books from the local file to the storage.
        /// </summary>
        /// <returns>Books collection.</returns>
        public override IList<Book> LoadBooks()
        {
            List<Book> booksList = new List<Book>();
            using (BinaryReader reader = new BinaryReader(File.Open(basePath, FileMode.Open, FileAccess.Read)))
            {
                while (reader.PeekChar() > -1)
                {
                    var isbn = reader.ReadString();
                    var author = reader.ReadString();
                    var title = reader.ReadString();
                    var publisher = reader.ReadString();
                    var year = reader.ReadInt32();
                    var price = reader.ReadDouble();
                    var pages = reader.ReadInt32();

                    Book book = new Book(isbn, author, title, publisher, year, pages, price);
                    booksList.Add(book);
                }
            }
            
            return booksList;
        }      

    }
}
