﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.Exceptions
{
    /// <summary>
    /// Class contains narrow exception. 
    /// </summary>
    public class MatrixRepresentationException : Exception
    {
        /// <summary>
        /// Field of exception message.
        /// </summary>
        public readonly string message;

        /// <summary>
        /// Constructor of exception type.
        /// </summary>
        /// <param name="message">Message to be show in case of exception.</param>
        public MatrixRepresentationException(string message)
        {
            this.message = message;
        }
    }
  
}
