using System;
using System.Globalization;

namespace BookExtensions
{
    /// <summary>
    /// Class represents abstract book.
    /// </summary>
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
        /// Book's information extension.
        /// </summary>
        public string AdditionalInformation { get; protected set; }

        /// <summary>
        /// Encapsulation of standard book first isbn.
        /// </summary>
        public virtual string ISBN { get; set; }

        /// <summary>
        /// Encapsulation of standard book author name.
        /// </summary>
        public virtual string Author { get; set; }

        /// <summary>
        /// Encapsulation of standard book title name.
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// Encapsulation of standard book publisher name.
        /// </summary>
        public virtual string Publisher { get; set; }
                
        /// <summary>
        /// Encapsulation of standard book year of publication.
        /// </summary>
        public virtual int YearOfPublication { get; set; }

        /// <summary>
        /// Encapsulation of standard book number of pages.
        /// </summary>
        public virtual int NumberOfPages { get; set; }

        /// <summary>
        /// Encapsulation of standard book price.
        /// </summary>
        public virtual double Price { get; set; }

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

        /// <summary>
        /// New representation of book's instance in String format with different formats.
        /// </summary>
        /// <param name="format">Proposed format.</param>
        /// <param name="formatProvider">Regional options.</param>
        /// <returns>Representation of instance.</returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            CultureInfo info = formatProvider as CultureInfo;
            info = info == null ? CultureInfo.InvariantCulture : CultureInfo.CurrentCulture;

            string separator = ", ";
            switch (format.ToUpper())
            {
                case "A": return Author + separator + Title;
                case "B": return Author + separator + Title + separator + Publisher + separator + YearOfPublication;
                case "C":
                    return "ISBN 13: " + ISBN + separator + Author + separator + Title + separator + Publisher
      + separator + YearOfPublication + separator + NumberOfPages;
                case "D": return Author + separator + Title + separator + Publisher + separator + YearOfPublication;
                case "E":
                    return "ISBN 13: " + ISBN + separator + Author + separator + Title + separator + Publisher
      + separator + YearOfPublication + separator + NumberOfPages + separator + String.Format("C2", Price);
                default: throw new FormatException($"The {format} format is not supported.");
            }
        }
    }
}