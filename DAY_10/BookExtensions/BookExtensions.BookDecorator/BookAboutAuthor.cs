using OnlineBookstore.Library.Books;
using System;

namespace OnlineBookstore.Library.Book
{
    public class BookAuthor :BookDecorator
    {
        public BookAuthor(AbstractBook book, string isbn, string author, string title, string publisher, int yearOfPublication, int numberOfPages, double price)
            : base(book, isbn, author, title, publisher, yearOfPublication, numberOfPages, price)
        {

        }

        public override string GetNewBookFormat()
        {
            return $"More information about {book.Author} you can find here: https://www.google.com/";
        }
    }
}
