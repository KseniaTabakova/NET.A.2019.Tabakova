using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileCabinet.Library.Helpers
{
    /// <summary>
    /// Class contains validation of Users' input.
    /// </summary>
    class Validator
    {
        /// <summary>
        /// Check the validation of Name.
        /// </summary>
        /// <param name="name">Given name.</param>
        /// <returns>Result of validation.</returns>
        internal static bool NameIsValid(string name)
        {
            if (name is null || name.Length <3)
                return false;
            return true;
        }

        /// <summary>
        /// Check the validation of Day of Birth.
        /// </summary>
        /// <param name="dateOfBirth">Given day of birth.</param>
        /// <returns>Result of validation.</returns>
        internal static bool DateOfBirthIsValid(string dateOfBirth)
        {
            if (dateOfBirth is null)
                return false;
            if (!Regex.Match(dateOfBirth, @"^(\d{1,2})\.(\d{1,2}).(\d{4})?$").Success)
                return false;
            return true;
        }
    }
}
