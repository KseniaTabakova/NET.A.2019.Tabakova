using OnlineBookstore.Library.Books;
using System;

namespace OnlineBookstore.Library.Book
{
    public class BookTitle : BookDecorator
    {
        public BookTitle(AbstractBook book, string isbn, string author, string title, string publisher, int yearOfPublication, int numberOfPages, double price)
            : base(book, isbn, author, title, publisher, yearOfPublication, numberOfPages, price)
        {

        }

        public override string GetNewBookFormat()
        {
            return $"If you have any recommendation about {book.Title} just write me: ksenia@tut.by";
        }
    }
}
