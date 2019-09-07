﻿using BookExtensions;

namespace BookExtensions
{
    /// <summary>
    /// Represent additional functionalities with which the book instance should be extended.
    /// </summary>
    public class BookWithTitleInformation : BookDecorator
    {
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
        public BookWithTitleInformation(AbstractBook book, string isbn, string author, string title, string publisher, int yearOfPublication, int numberOfPages, double price)
            : base(book, isbn, author, title, publisher, yearOfPublication, numberOfPages, price)
        {
            AdditionalInformation = $"If you have any recommendation about {book.Title} just write me: {book.Author}@gmail.com";
        }
    }
}
