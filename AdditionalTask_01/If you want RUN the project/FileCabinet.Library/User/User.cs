using System;

namespace FileCabinet.Library.Person
{
    /// <summary>
    /// Abstract class contains base data and behavior for User.
    /// </summary>
    public abstract class User : IInitializer
    {
        #region User properties

        /// <summary>
        /// Encapsulation of User first name.
        /// </summary>
        public abstract string FirstName { get; set; }

        /// <summary>
        /// Encapsulation of User last name.
        /// </summary>
        public abstract string LastName { get; set; }

        /// <summary>
        /// Encapsulation of User day of birth.
        /// </summary>
        public abstract string DateOfBirth { get; set; }

        /// <summary>
        /// Encapsulation of User id.
        /// </summary>
        public abstract int ID { get; internal set; }

        #endregion

        #region User's overloaded methods

        /// <summary>
        /// Reaction to the User instance creation.
        /// </summary>
        public virtual void CreateUser()
        {
            Console.WriteLine($"Record #{this.ID} is created.");
        }

        /// <summary>
        /// Reaction to the deletion of User instance.
        /// </summary>
        public virtual void DeleteUser()
        {
            Console.WriteLine($"Record #{this.ID} is deleted.");
        }

        /// <summary>
        /// Reaction to the User instance change.
        /// </summary>
        public virtual void EditUser()
        {
            Console.WriteLine($"Record #{this.ID} is edited.");
        }

        #endregion

        #region Overloaded System.Object methods

        /// <summary>
        /// Overrided representation of User instance in String format.
        /// </summary>
        /// <returns>Representation of instance.</returns>
        public override string ToString()
        {
            return $"{FirstName} {LastName}, born on {DateOfBirth}.";
        }

        /// <summary>
        /// Overrided deep Users' equals.
        /// </summary>
        /// <param name="other">Object instance.</param>
        /// <returns>The result of equals.</returns>
        public override bool Equals(object other)
        {
            return this.Equals(other as User);
        }

        /// <summary>
        /// Returns a hash code for the User instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            int hashCode = 0;
            for (int i = 0; i < FirstName.Length; i++)
            {
                hashCode += this[i].GetHashCode() + i * 32;
            }
            return hashCode;
        }

        #endregion

        /// <summary>
        /// Give User a nickname.
        /// </summary>
        protected internal virtual void GiveUserNickname()
        {
            Console.WriteLine("We are giving a nickname to find user easier!");
        }

        /// <summary>
        /// Deep Users' equals.
        /// </summary>
        /// <param name="other">User input.</param>
        /// <returns>The result of equals.</returns>
        private bool Equals(User other)
        {
            if (other is null)
            {
                return false;
            }
            if (GetType() != other.GetType())
            {
                return false;
            }
            return FirstName == other.FirstName && this.LastName == other.LastName && this.DateOfBirth == other.DateOfBirth;
        }

        /// <summary>
        /// Run in User name.
        /// </summary>
        /// <param name="index">Index.</param>
        /// <returns>Char.</returns>
        private char this[int index]
        {
            get
            {
                return FirstName[index];
            }
        }
    }
}
