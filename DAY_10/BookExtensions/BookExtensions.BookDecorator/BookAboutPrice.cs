using OnlineBookstore.Library.Books;
using System;

namespace OnlineBookstore.Library.Book
{
    public class BookPrice : BookDecorator
    {
        public BookPrice(AbstractBook book, string isbn, string author, string title, string publisher, int yearOfPublication, int numberOfPages, double price) 
            : base(book, isbn,author,title,publisher,yearOfPublication,numberOfPages,price )
        {

        }

        public override string GetNewBookFormat()
        {
            return $"Total price for You is {book.Price}";
        }
    }
}
