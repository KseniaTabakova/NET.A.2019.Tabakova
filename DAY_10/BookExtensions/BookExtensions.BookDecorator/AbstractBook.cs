using OnlineBookstore.Library.Exceptions;
using OnlineBookstore.Library.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookstore.Library.Books
{
    public abstract class AbstractBook
    {
        private string isbn;
        private string author;
        private string title;
        private string publisher;
        private int yearOfPublication;
        private int numberOfPages;
        private double price;

        /// <summary>
        /// Encapsulation of standard book first isbn with validation.
        /// </summary>
        public string ISBN
        {
            get
            {
                return this.isbn;
            }
            set
            {
                if (!Validator.IsbnIsValid(value))
                {
                    throw new InvalidBookDataException("Error: invalid ISBN.");
                }
                this.isbn = value;
            }
        }

        /// <summary>
        /// Encapsulation of standard book author name with validation.
        /// </summary>
        public string Author
        {
            get
            {
                return this.author;
            }
            set
            {
                if (!Validator.AuthorIsValid(value))
                {
                    throw new InvalidBookDataException("Error: invalid author.");
                }
                this.author = value;
            }
        }

        /// <summary>
        /// Encapsulation of standard book title name with validation.
        /// </summary>
        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                if (!Validator.TitleIsValid(value))
                {
                    throw new InvalidBookDataException("Error: invalid title value.");
                }
                this.title = value;
            }
        }

        /// <summary>
        /// Encapsulation of standard book publisher name with validation.
        /// </summary>
        public string Publisher
        {
            get
            {
                return this.publisher;
            }
            set
            {
                if (!Validator.PublisherIsValid(value))
                {
                    throw new InvalidBookDataException("Error: invalid publisher.");
                }
                this.publisher = value;
            }
        }

        /// <summary>
        /// Encapsulation of standard book year of publication with validation.
        /// </summary>
        public int YearOfPublication
        {
            get
            {
                return this.yearOfPublication;
            }
            set
            {
                if (!Validator.YearIsValid(value))
                {
                    throw new InvalidBookDataException("Error: invalid year of publication.");
                }
                this.yearOfPublication = value;
            }
        }

        /// <summary>
        /// Encapsulation of standard book number of pages with validation.
        /// </summary>
        public int NumberOfPages
        {
            get
            {
                return this.numberOfPages;
            }
            set
            {
                if (!Validator.NumberOfPagesIsValid(value))
                {
                    throw new InvalidBookDataException("Error: invalid number of pages.");
                }
                this.numberOfPages = value;
            }
        }

        /// <summary>
        /// Encapsulation of standard book price with validation.
        /// </summary>
        public double Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (!Validator.PriceIsValid(value))
                {
                    throw new InvalidBookDataException("Error: invalid price.");
                }
                this.price = value;
            }
        }

        /// <summary>
        /// Parametrized constructor.
        /// </summary>
        /// <param name="isbn">Given ISBN.</param>
        /// <param name="author">Given Author name.</param>
        /// <param name="title">Given title name.</param>
        /// <param name="publisher">Given publisher name.</param>
        /// <param name="yearOfPublication">Given year of publication.</param>
        /// <param name="numberOfPages">Given number of pages.</param>
        /// <param name="price">Given price.</param>
        public AbstractBook(string isbn, string author, string title, string publisher, int yearOfPublication, int numberOfPages, double price)
        {
            this.ISBN = isbn;
            this.Author = author;
            this.Title = title;
            this.Publisher = publisher;
            this.YearOfPublication = yearOfPublication;
            this.NumberOfPages = numberOfPages;
            this.Price = price;
        }

        public virtual string GetNewBookFormat()
        {
            return this.Title = "NoName";
        }
    }
}
