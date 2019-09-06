using System.Collections.Generic;

namespace OnlineBookstore.Library.Helpers
{
    /// <summary>
    /// Interface provides functionality to work with file system.
    /// </summary>
    public interface IFileSystem
    {
        /// <summary>
        /// Save books to the local file.
        /// </summary>
        /// <param name="books">Books to be saved.</param>
        void SaveBooks(IEnumerable<Book> books);

        /// <summary>
        /// Load books from the local file to the storage.
        /// </summary>
        /// <returns>Books collection.</returns>
        IList<Book> LoadBooks();

    }
}
