namespace OnlineBookstore.Library.Helpers
{
    /// <summary>
    /// Class provides the correctness of input data.
    /// </summary>
    class Validator
    {
        /// <summary>
        /// Find out the correctness of ISBN.
        /// </summary>
        /// <param name="isbn">Input isbn.</param>
        /// <returns>Operation result status.</returns>
        internal static bool IsbnIsValid(string isbn)
        {
            bool isValid = false;
            if (isbn is null || isbn.Length == 0)
            {
                isValid = false;
            }

            isbn = isbn.Replace("-", "").Replace(" ", "");

            if (isbn.Length != 9)
            {
                isValid = false;
            }

            int result;
            for (int i = 0; i != 9; i++)
                if (!int.TryParse(isbn[i].ToString(), out result))
                {
                    isValid = false;
                }

            int sum = 0;
            for (int i = 0; i != 9; i++)
                sum += (i + 1) * int.Parse(isbn[i].ToString());

            string finalISBN = string.Empty;

            int remainder = sum % 11;
            int controlDigit = 11 - remainder;
            if ((sum + controlDigit) % 11 == 0)
            {
                isValid = true;
            }
            return isValid;
        }

        /// <summary>
        /// Find out the correctness of Author name.
        /// </summary>
        /// <param name="author">Input author name.</param>
        /// <returns>Operation result status.</returns>
        internal static bool AuthorIsValid(string author)
        {
            if (author == null || author.Length <3 || author.Length>15)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Find out the correctness of title name.
        /// </summary>
        /// <param name="title">Input title name.</param>
        /// <returns>Operation result status.</returns>
        internal static bool TitleIsValid(string title)
        {
            if (title == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Find out the correctness of publisher name.
        /// </summary>
        /// <param name="publisher">Input publisher name.</param>
        /// <returns>Operation result status.</returns>
        internal static bool PublisherIsValid(string publisher)
        {
            if (publisher == null || publisher.Length > 15)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Find out the correctness of year.
        /// </summary>
        /// <param name="year">Input year.</param>
        /// <returns>Operation result status.</returns>
        internal static bool YearIsValid(int year)
        {
            if (year < 1950 || year> 2019)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Find out the correctness of number of pages.
        /// </summary>
        /// <param name="numberOfPages">Input number of pages.</param>
        /// <returns>Operation result status.</returns>
        internal static bool NumberOfPagesIsValid(int numberOfPages)
        {
            if (numberOfPages <= 0 )
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Find out the correctness of price.
        /// </summary>
        /// <param name="price">Input number of price.</param>
        /// <returns>Operation result status.</returns>
        internal static bool PriceIsValid(double price)
        {
            if (price < 0)
            {
                return false;
            }
            return true;
        }
    }
}
