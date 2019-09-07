using System;

namespace OnlineBookstore.Library.Book
{
    /// <summary>
    /// Interface contains method for string representation of book instance.
    /// </summary>
    public interface IBookFormatter
    {
        /// <summary>
        /// New representation of book's instance in String format with different formats.
        /// </summary>
        /// <param name="format">Proposed format.</param>
        /// <param name="formatProvider">Regional options.</param>
        /// <returns>Representation of instance.</returns>
        string ToString(string format, IFormatProvider formatProvider);
    }
}