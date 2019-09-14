using Bank.Library.Exceptions;
using Bank.Library.Helpers;
using System;
using System.Globalization;

namespace Bank.Library.Account
{
    /// <summary>
    /// Class represents an account holder.
    /// </summary>
    public class AccountHolder
    {
        private string firstName;
        private string lastName;
        private string phone;

        /// <summary>
        /// Encapsulation of Account Holder first name with validation.
        /// </summary>
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (!Validator.NameIsValid(value))
                {
                    throw new InvalidNameException("Name should contains only english letters.");
                }
                firstName = value;
            }
        }

        /// <summary>
        /// Encapsulation of Account Holder last name with validation.
        /// </summary>
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (!Validator.NameIsValid(value))
                {
                    throw new InvalidNameException("Name must contains only English letters.");
                }
                lastName = value;
            }
        }

        /// <summary>
        /// Encapsulation of Account Holder phone number with validation.
        /// </summary>
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                if (!Validator.PhoneIsValid(value))
                {
                    throw new InvalidPhoneNumberException($"Number must contains only digits and + -() sign.");
                }
                phone = value;
            }
        }

        /// <summary>
        /// Parametrized constructor witch corrects input data.
        /// </summary>
        /// <param name="firstName">Given by holder first name.</param>
        /// <param name="lastName">Given by holder last name.</param>
        /// <param name="phone">Given by holder phone number.</param>
        public AccountHolder(string firstName, string lastName, string phone)
        {
            firstName = firstName.Substring(0, 1).ToUpper() + firstName.Substring(1).ToLower();
            lastName = lastName.Substring(0, 1).ToUpper() + lastName.Substring(1).ToLower();

            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
        }

        /// <summary>
        /// New representation of account holder's instance in String format with different formats.
        /// </summary>
        /// <param name="format">Proposed format.</param>
        /// <param name="formatProvider">Regional options.</param>
        /// <returns>Representation of instance.</returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            CultureInfo info = formatProvider as CultureInfo;
            info = info == null ? CultureInfo.InvariantCulture : CultureInfo.CurrentCulture;

            if (string.IsNullOrEmpty(format))
            {
                format = "0";
            }

            string s1 = "Customer record: ";
            switch (format.ToUpperInvariant())
            {
                case "0":
                    return "There is no information input.Try again.";
                case "1":
                    return s1 + FirstName + " " + LastName;
                case "2":
                    return s1 + FirstName + " " + LastName + " " + Phone;
                default:
                    throw new ArgumentException($"There is no such {nameof(format)} format of representation for {nameof(AccountHolder)}.");
            }
        }
    }
}
