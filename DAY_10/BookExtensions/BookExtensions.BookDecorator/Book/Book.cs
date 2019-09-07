using System;
using System.Globalization;

namespace BookExtensions
{
    /// <summary>
    /// Class represents standard book.
    /// </summary>
    public class Book : AbstractBook, IEquatable<Book>, IComparable<Book>, IComparable
    {
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
        public Book(string isbn, string author, string title, string publisher, int yearOfPublication, int numberOfPages, double price) :
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
                && YearOfPublication == other.YearOfPublication
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