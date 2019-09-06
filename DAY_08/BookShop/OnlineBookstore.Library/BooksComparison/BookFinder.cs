using OnlineBookstore.Library.Helpers;

namespace OnlineBookstore.Library.BookComparison
{
    /// <summary>
    /// Class provides method to find appropriate instance of book.
    /// </summary>
    class BookFinder : IFinder<Book>
    {
        private Tags tag;
        private string ourValue;

        /// <summary>
        /// Property for criteria establishment.
        /// </summary>
        public Tags Tag { get { return tag; } set { tag = value; } }

        /// <summary>
        /// Property for input value establishment.
        /// </summary>
        public string Value { get { return ourValue; } set { ourValue = value; } }

        /// <summary>
        /// Constructor witch contain criteria for find appropriate instance of book and value for this comparison. 
        /// </summary>
        /// <param name="tag">Criteria for find appropriate instance of book.</param>
        /// <param name="input">Value for this comparison.</param>
        public BookFinder(Tags tag, string input)
        {
            this.Tag = tag;
            Value = input;
        }

        /// <summary>
        /// Establish the collection search result.
        /// </summary>
        /// <param name="book">Instance of book.</param>
        /// <returns>Result of search.</returns>
        public bool BookIsRight(Book book)
        {
            switch (tag)
            {
                case Tags.Author: return ourValue == book.Author;
                case Tags.ISBN: return ourValue == book.ISBN;
                case Tags.Title: return ourValue == book.Title;
                case Tags.Publisher: return ourValue == book.Publisher;
                case Tags.YearOfPublication: return int.Parse(ourValue) == book.YearOfPublication;
                case Tags.NumberOfPages: return int.Parse(ourValue) == book.NumberOfPages;
                case Tags.Price: return double.Parse(ourValue) == book.Price;

            }
            return false;
        }

    }
}
