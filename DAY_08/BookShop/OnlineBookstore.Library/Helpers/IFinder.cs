namespace OnlineBookstore.Library.Helpers
{
    /// <summary>
    /// Interface determine the correctness of choice. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IFinder<in T>
    {
        /// <summary>
        /// Determine the correctness of choice. 
        /// </summary>
        /// <param name="book">Input books.</param>
        /// <returns>Operation result status.</returns>
        bool BookIsRight(T book);
    }
}
