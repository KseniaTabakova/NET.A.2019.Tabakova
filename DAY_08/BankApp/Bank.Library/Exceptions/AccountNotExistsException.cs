using System;

namespace Bank.Library.Exceptions
{
    /// <summary>
    /// Class contains narrow exception. 
    /// </summary>
    public class AccountNotExistsException : Exception
    {
        /// <summary>
        /// Field of exception message.
        /// </summary>
        public readonly string message;

        /// <summary>
        /// Constructor of exception type.
        /// </summary>
        /// <param name="message">Message to be show in case of exception.</param>
        public AccountNotExistsException(string message): base (message)
        {
            this.message = message;
        }
    }
}
