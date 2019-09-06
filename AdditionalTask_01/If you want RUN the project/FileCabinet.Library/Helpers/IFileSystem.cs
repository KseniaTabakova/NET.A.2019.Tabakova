namespace FileCabinet.Library.Storage
{
    /// <summary>
    /// Interface of file system data sharing.
    /// </summary>
    public interface IFileSystem
    {
        /// <summary>
        /// Import data in xml format.
        /// </summary>
        /// <param name="fileName">Name of a document.</param>
        void ImportXml(string fileName);

        /// <summary>
        /// Export data in xml format.
        /// </summary>
        /// <param name="fileName">Name of a document.</param>
        /// <param name="filePath">Path to document.</param>
        void ExportXml(string fileName, out string filePath);

        /// <summary>
        /// Import data in csv format.
        /// </summary>
        /// <param name="fileName">Name of a document.</param>
        void ImportCsv(string fileName);

        /// <summary>
        /// Export data in csv format.
        /// </summary>
        /// <param name="fileName">Name of a document.</param>
        /// <param name="filePath">Path to document.</param>
        void ExportCsv(string fileName, out string filePath);
    }
}
