
using OnlineBookstore.Library.Books;

namespace OnlineBookstore.Library.Book
{
    public abstract class BookDecorator : AbstractBook
    {
        protected AbstractBook book;
        public BookDecorator(AbstractBook book, string isbn, string author, string title, string publisher, int yearOfPublication, int numberOfPages, double price)
            :base(isbn, author,title, publisher,yearOfPublication,numberOfPages,price)
        {
            this.book = book;
        }

    }
}
