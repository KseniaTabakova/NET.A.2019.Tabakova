using System;

namespace FileCabinet.Library.Person
{
    /// <summary>
    /// Class represents Standard User. 
    /// </summary>
    class StandardUser : User
    {
        #region Standard User fields

        /// <summary>
        /// First name.
        /// </summary>
        private string firstName;

        /// <summary>
        /// Last name.
        /// </summary>
        private string lastName;

        /// <summary>
        /// Day of birth.
        /// </summary>
        private string dateOfBirth;

        /// <summary>
        /// Id.
        /// </summary>
        private int id;

        #endregion

        #region Standard User properties 

        /// <summary>
        /// Encapsulation of Standard User first name with validation.
        /// </summary>
        public override string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (!Helpers.Validator.NameIsValid(value))
                    throw new Exceptions.InvalidNameException("Invalid First Name. Its length must be greater than three. Try again.");
                this.firstName = value;
            }
        }

        /// <summary>
        /// Encapsulation of Standard User last name with validation.
        /// </summary>
        public override string LastName
        {
            get { return this.lastName; }
            set
            {
                if (!Helpers.Validator.NameIsValid(value))
                    throw new Exceptions.InvalidNameException("Invalid Last Name. Its length must be greater than three. Try again.");
                this.lastName = value;
            }
        }

        /// <summary>
        /// Encapsulation of Standard User day of birth with validation.
        /// </summary>
        public override string DateOfBirth
        {
            get { return this.dateOfBirth; }
            set
            {
                if (!Helpers.Validator.DateOfBirthIsValid(value))
                    throw new Exceptions.InvalidDayOfBirthException("Day of Birth data must be in format DD.MM.YYYY");
                this.dateOfBirth = value;
            }
        }

        /// <summary>
        /// Encapsulation of Standard User id.
        /// </summary>
        public override int ID
        {
            get { return this.id; }
            internal set
            {
                this.id = value;
            }
        }

        #endregion

        #region Standart User constructor

        /// <summary>
        /// Empty constructor with no arguments.
        /// </summary>
        public StandardUser()
        {
        }

        /// <summary>
        /// Parametrized constructor.
        /// </summary>
        /// <param name="fName">Given First Name.</param>
        /// <param name="lName">Given Last Name.</param>
        /// <param name="dBirth">Given Day of Birth.</param>
        /// <param name="id">Assigned id.</param>
        public StandardUser(string fName, string lName, string dBirth, int id)
        {
            this.FirstName = fName;
            this.LastName = lName;
            this.DateOfBirth = dBirth;
            this.ID = id;
        }

        /// <summary>
        /// Parametrized constructor.
        /// </summary>
        /// <param name="fName">Given First Name.</param>
        /// <param name="lName">Given Last Name.</param>
        /// <param name="dBirth">Given Day of Birth.</param>
        public StandardUser(string fName, string lName, string dBirth)
        {
            this.FirstName = fName;
            this.LastName = lName;
            this.DateOfBirth = dBirth;
        }

        #endregion

        /// <summary>
        /// Overrided representation of User instance in String format.
        /// </summary>
        /// <returns>Representation of instance.</returns>
        public override string ToString()
        {
            return this.ID + " - " + this.FirstName + " - " + this.LastName + " - " + this.DateOfBirth;
        }
    }
}
