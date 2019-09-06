using System;

namespace FileCabinet.Library.Exceptions
{
    /// <summary>
    /// Class contains narrow exception. 
    /// </summary>
    public class FileNotFoundException : Exception
    {
        /// <summary>
        /// Field of exception message.
        /// </summary>
        public readonly string message;

        /// <summary>
        /// Constructor of exception type.
        /// </summary>
        /// <param name="message">Message to be show in case of exception.</param>
        public FileNotFoundException(string message)
        {
            this.message = message;
        }

    }
}
