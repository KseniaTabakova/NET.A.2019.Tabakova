
using OnlineBookstore.Library.Books;
using OnlineBookstore.Library.Exceptions;
using OnlineBookstore.Library.Helpers;
using System;
using System.Globalization;

namespace OnlineBookstore.Library.Book
{
    /// <summary>
    /// Class represents standard book.
    /// </summary>
    public class Book : AbstractBook, IEquatable<Book>, IComparable<Book>, IComparable, IBookFormatter 
    {
       
        public Book(string isbn, string author, string title, string publisher, int yearOfPublication, int numberOfPages, double price):
            base(isbn, author, title, publisher, yearOfPublication, numberOfPages, price)
        {

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
