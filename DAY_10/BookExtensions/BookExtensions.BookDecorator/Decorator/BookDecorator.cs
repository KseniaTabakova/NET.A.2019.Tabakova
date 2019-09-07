using BookExtensions;

namespace BookExtensions
{
    /// <summary>
    /// Decorator for book instance.
    /// </summary>
    public abstract class BookDecorator : AbstractBook
    {
        /// <summary>
        /// Reference to the object for decoration - object of base class.
        /// </summary>
        protected AbstractBook book;

        /// <summary>
        /// Parametrized constructor.
        /// </summary>
        /// <param name="book">Relations with the base class through an aggregation relation.</param>
        /// <param name="isbn">Given ISBN.</param>
        /// <param name="author">Given Author name.</param>
        /// <param name="title">Given title name.</param>
        /// <param name="publisher">Given publisher name.</param>
        /// <param name="yearOfPublication">Given year of publication.</param>
        /// <param name="numberOfPages">Given number of pages.</param>
        /// <param name="price">Given price.</param>
        public BookDecorator(AbstractBook book, string isbn, string author, string title, string publisher, int yearOfPublication, int numberOfPages, double price)
            : base(isbn, author, title, publisher, yearOfPublication, numberOfPages, price)
        {           
            this.book = book;
        }
    }
}
