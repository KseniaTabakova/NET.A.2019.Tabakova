using System;

namespace OnlineBookstore.Library.Book
{
    public interface IBookFormatter
    {
        string GetBookFormat(string format, IFormatProvider formatProvider);
    }
}
