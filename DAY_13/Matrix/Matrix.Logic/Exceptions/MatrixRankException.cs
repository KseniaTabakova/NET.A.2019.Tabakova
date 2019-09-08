using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    /// <summary>
    /// Class contains narrow exception. 
    /// </summary>
    public class MatrixRankException : Exception
    {
        /// <summary>
        /// Field of exception message.
        /// </summary>
        public readonly string message;

        /// <summary>
        /// Constructor of exception type.
        /// </summary>
        /// <param name="message">Message to be show in case of exception.</param>
        public MatrixRankException(string message)
        {
            this.message = message;
        }
    }
}
