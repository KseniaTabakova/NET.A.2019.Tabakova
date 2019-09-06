using FileCabinet.Library.Person;

namespace FileCabinet.Library
{
    /// <summary>
    /// Interface of Users' storage.
    /// </summary>
    public interface IStorage
    {
        /// <summary>
        /// Add new User to the storage.
        /// </summary>
        /// <param name="user">User which should be add.</param>
        /// <returns>Operation success status.</returns>
        bool AddUser(User user);

        /// <summary>
        /// Delete User from the storage.
        /// </summary>
        /// <param name="user">User which should be deleted.</param>
        /// <returns>Operation success status.</returns>
        bool DeleteUser(User user);

        /// <summary>
        /// Edit User of the storage.
        /// </summary>
        /// <param name="user">User which can be edited.</param>
        /// <returns>Operation success status.</returns>
        bool EditUser(User user);

    }
}
