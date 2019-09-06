using System;
using Bank.Library.Exceptions;
using Bank.Library.Helpers;

namespace Bank.Library.Account
{
    public class AccountHolder
    {
        private string firstName;
        private string lastName;
        private string phone;
        
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
                    throw new InvalidPhoneNumberException($"{phone} must contains only digits and + -() sign.");
                }
                phone = value;
            }
        }     

        public AccountHolder(string firstName, string lastName, string phone)
        {
            firstName = firstName.Substring(0, 1).ToUpper() + firstName.Substring(1).ToLower();
            lastName = lastName.Substring(0, 1).ToUpper() + lastName.Substring(1).ToLower();

            FirstName = firstName;
            LastName = lastName;
            Phone = phone;        
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "1";
            }

            string s1 = "Customer record: ";

            switch (format.ToUpperInvariant())
            {
                case "1":
                    return "There is no information input.Try again.";
                case "2":
                    return s1 + FirstName + " " + LastName;
                case "3":
                    return s1 + FirstName + " " + LastName + " " + Phone;
                default:
                    throw new ArgumentException($"There is no such {nameof(format)} format of representation of {nameof(AccountHolder)}.");
            }
        }    
    }
}
