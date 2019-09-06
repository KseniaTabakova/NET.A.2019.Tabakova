
using OnlineBookstore.Library.Exceptions;
using OnlineBookstore.Library.Helpers;
using System;
using System.Globalization;

namespace OnlineBookstore.Library.Book
{
    /// <summary>
    /// Class represents standard book.
    /// </summary>
    public class Book : IEquatable<Book>, IComparable<Book>, IComparable, IBookFormatter
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
        public Book(string isbn, string author, string title, string publisher, int yearOfPublication, int numberOfPages, double price)
        {
            this.ISBN = isbn;
            this.Author = author;
            this.Title = title;
            this.Publisher = publisher;
            this.YearOfPublication = yearOfPublication;
            this.NumberOfPages = numberOfPages;
            this.Price = price;
        }

        /// <summary>
        /// Method to compare two objects. 
        /// </summary>
        /// <param name="other">Object to compare.</param>
        /// <returns>Position of the second element relative to the first.</returns>
        public int CompareTo(object other)
        {
            Book b = other as Book;

            if (b is null || other is null)
            {
                throw new Exception("It is impossible to compare two instances. ");
            }
            else
                return CompareTo((Book)other);
        }

        /// <summary>
        /// Method to compare two Books with default value. 
        /// </summary>
        /// <param name="other">Object to compare.</param>
        /// <returns>Position of the second element relative to the first.</returns>
        public int CompareTo(Book other)
        {
            return Title.CompareTo(other.Title);
        }

        /// <summary>
        /// Equivalence check.
        /// </summary>
        /// <param name="other">Book to compare.</param>
        /// <returns>Equivalence result.</returns>
        public bool Equals(Book other)
        {
            if (other is null)
            {
                return false;
            }

            if (GetHashCode() != other.GetHashCode())
            {
                return false;
            }

            return ISBN == other.ISBN
                && Author == other.Author
                && Title == other.Title
                && Publisher == other.Publisher
                && yearOfPublication == other.yearOfPublication
                && NumberOfPages == other.NumberOfPages
                && Price == other.Price;
        }

        /// <summary>
        /// Overrided book instance equivalence check.
        /// </summary>
        /// <param name="other">Book to compare.</param>
        /// <returns>Equivalence result.</returns>
        public override bool Equals(object other)
        {
            if (other is null)
            {
                return false;
            }

            if (GetType() != other.GetType())
            {
                return false;
            }

            return this.Equals(other as Book);
        }

        /// <summary>
        /// Overrided for book instance hashcode method.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return ISBN?.GetHashCode() ?? 0;
        }

        /// <summary>
        /// Overrided representation of book instance in String format with different formats.
        /// </summary>
        /// <param name="format">Formats possible.</param>
        /// <returns>Representation of instance.</returns>
        public string ToString(string format)
        {
            switch (format)
            {
                case "1": return Title + ", " + Author;
                case "2": return Title + ", " + YearOfPublication + ", " + Author + ", " + ISBN;
                case "3": return Title + ", " + YearOfPublication + ", " + NumberOfPages + ", " + Author + ", " + ISBN + ", " + Publisher + ", " + Price;
                default: throw new FormatException(String.Format("The {0} format string is not supported.", format));
            }
        }

        /// <summary>
        /// Overrided representation of book instance in String format with different formats.
        /// </summary>
        /// <param name="format">Formats possible.</param>
        /// <returns>Representation of instance.</returns>
        public string GetBookFormat(string format, IFormatProvider formatProvider)
        {
            CultureInfo info = formatProvider as CultureInfo;
            if (info == null)
                info = CultureInfo.InvariantCulture;
            else
                info = CultureInfo.CurrentCulture;
            string separator = ", ";
            switch (format.ToUpper())
            {
                case "A": return Author + separator + Title;
                case "B": return Author + separator + Title + separator + Publisher + separator + YearOfPublication;
                case "C": return "ISBN 13: " + ISBN + separator + Author + separator + Title + separator + Publisher
                  + separator + YearOfPublication + separator + NumberOfPages;
                case "D": return Author + separator + Title + separator + Publisher + separator + YearOfPublication;
                case "E": return "ISBN 13: " + ISBN + separator + Author + separator + Title + separator + Publisher
                  + separator + YearOfPublication + separator + NumberOfPages + separator + String.Format("C2", Price);
                default: throw new FormatException(String.Format("The {0} format string is not supported.", format));
            }
        }

        /// <summary>
        /// Checks equally of two books.
        /// </summary>
        /// <param name="b1">First book.</param>
        /// <param name="b2">Second book.</param>
        /// <returns>True if books are equal.</returns>
        public static bool operator ==(Book b1, Book b2)
        {
            return b1.Equals(b2);
        }

        /// <summary>
        /// Checks equally of two books.
        /// </summary>
        /// <param name="b1">First book.</param>
        /// <param name="b2">Second book.</param>
        /// <returns>True if books are not equal.</returns>
        public static bool operator !=(Book b1, Book b2)
        {
            return !b1.Equals(b2);
        }
    }
}
