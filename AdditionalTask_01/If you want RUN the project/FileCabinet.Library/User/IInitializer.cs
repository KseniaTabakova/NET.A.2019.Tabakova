namespace FileCabinet.Library.Person
{
    /// <summary>
    /// Interface contains method for base User behavior initialisation. 
    /// </summary>
    public interface IInitializer
    {
        /// <summary>
        /// Create instance of User.
        /// </summary>
        void CreateUser();

        /// <summary>
        /// Delete instance of User.
        /// </summary>
        void DeleteUser();

        /// <summary>
        /// Create instance of User.
        /// </summary>
        void EditUser();     
    }
}
