using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Library.Exceptions
{
    public class NegativeSumException : Exception
    {
        /// <summary>
        /// Field of exception message.
        /// </summary>
        public readonly string message;

        public NegativeSumException(string message) : base(message)
        {
            this.message = message;
        }
    }
}
