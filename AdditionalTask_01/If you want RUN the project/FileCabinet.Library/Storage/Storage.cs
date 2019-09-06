using FileCabinet.Library.Person;
using System.Collections.Generic;

namespace FileCabinet.Library.Storage
{
    /// <summary>
    /// Abstract class contains base members and behavior for the User storage.
    /// </summary>
    abstract class Storage : IStorage
    {
        /// <summary>
        /// Container contains users.
        /// </summary>
        protected internal List<User> users;

        /// <summary>
        /// Add User in the storage. 
        /// </summary>
        /// <param name="user">User which should be added to the storage.</param>
        /// <returns>Operation success status.</returns>
        public virtual bool AddUser(User user)
        {
            if (users is null)
                users = new List<User>();
            users.Add(user);
            return true;
        }

        /// <summary>
        /// Delete User from the storage. 
        /// </summary>
        /// <param name="user">User which should be deleted from the storage.</param>
        /// <returns>Operation success status.</returns>
        public virtual bool DeleteUser(User user)
        {
            users.Remove(user);
            return true;
        }

        /// <summary>
        /// Edit User in the storage. 
        /// </summary>
        /// <param name="user">User which can be edited in the storage.</param>
        /// <returns>Operation success status.</returns>
        public virtual bool EditUser(User user)
        {
            users.Find(t => t.ID == user.ID).FirstName = "NewName";
            users.Find(t => t.ID == user.ID).LastName = "NewLastName";
            users.Find(t => t.ID == user.ID).DateOfBirth = "NewDayOfBirth";
            return true;
        }

        /// <summary>
        /// Count users in the storage.
        /// </summary>
        /// <returns>The amount of users in the storage.</returns>
        public abstract int Count();

        /// <summary>
        /// Clear users from the storage.
        /// </summary>
        public abstract void ClearStorage();
    }
}
