using FileCabinet.Library.Helpers;
using FileCabinet.Library.Person;
using FileCabinet.Library.Storage;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileCabinet.Library.Cabinet
{
    public class Cabinet 
    {
        #region Cabinet fields

        /// <summary>
        /// Container of users.
        /// </summary>
        private StorageOfUsers storageOfUsers;

        /// <summary>
        /// User field.
        /// </summary>
        private User user;
        
        /// <summary>
        /// Id for user initialization in storage.
        /// </summary>
        private int _id;

        #endregion

        #region Cabinet properties

        /// <summary>
        /// Encapsulation of User id.
        /// </summary>
        public int UserID { get { return _id; } }

        /// <summary>
        /// Encapsulation of Cabinet name.
        /// </summary>
        public string Name { get; private set; }

        #endregion

        #region Cabinet constructor

        /// <summary>
        /// Empty constructor with fields inizialization in body.
        /// </summary>
        public Cabinet()
        {
            Name = "File Cabinet";
            storageOfUsers = new StorageOfUsers();
        }

        #endregion

        /// <summary>
        /// Reflect Cabinet description.
        /// </summary>
        public void GetDescription()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + "Presentation.txt";
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
                Console.WriteLine();
            }
        }

        #region API

        /// <summary>
        /// Create instance of User in storage.
        /// </summary>
        /// <param name="fName">Given first name.</param>
        /// <param name="lName">Given last name.</param>
        /// <param name="dBirth">Given day of birth.</param>
        public void CreateUser(string fName, string lName, string dBirth)
        {
            _id++;
            user = new StandardUser(fName, lName, dBirth, _id);
            if (storageOfUsers.AddUser(user))
                user.CreateUser();
        }

        /// <summary>
        /// Returns a collection of Users data in storage.
        /// </summary>
        /// <returns>A collection of Users data.</returns>
        public IEnumerable<User> ListUsers()
        {
            IEnumerable<User> users = storageOfUsers.ListUsers();
            return users;
        }

        /// <summary>
        /// Count users in the storage.
        /// </summary>
        /// <returns>The string format of users in the storage.</returns>
        public string Stat()
        {
            int? count = storageOfUsers.Count();
            bool plural = count > 1 || count != 0;
            string answer = plural ? $"{count} records." : $"{count} record.";
            return answer;
        }

        /// <summary>
        /// Returns a collection of Users data which meet the criteria.
        /// </summary>
        /// <param name="name">Criteria.</param>
        /// <returns>A collection of Users data.</returns>
        public IEnumerable<User> FindUsers(string name)
        {
            IEnumerable<User> users = storageOfUsers.FindUser(name);
            return users;
        }

        /// <summary>
        /// Returns a collection of Users data which meet the criteria.
        /// </summary>
        /// <param name="name">Criteria.</param>
        /// <param name="lName">Criteria.</param>
        /// <returns>A collection of Users data.</returns>
        public IEnumerable<User> FindUsers(string name, string lName)
        {
            IEnumerable<User> users = storageOfUsers.FindUser(name, lName);
            return users;
        }

        /// <summary>
        /// Returns instance of User.
        /// </summary>
        /// <param name="id">User id.</param>
        /// <returns>Instance of User.</returns>
        public User FindUser(int id)
        {
            User user = storageOfUsers.FindUser(id);
            return user;
        }

        /// <summary>
        /// Edit User in the storage.
        /// </summary>
        /// <param name="user">User which would like to be changed.</param>
        /// <param name="newName">New User first name.</param>
        /// <param name="newLName">New User last name.</param>
        /// <param name="newDB">New User day of birth.</param>
        public void EditUser(User user, string newName, string newLName, string newDB)
        {
            if (storageOfUsers.EditUser(user, newName, newLName, newDB))
                user.EditUser();
        }

        /// <summary>
        /// Clear users from the storage.
        /// </summary>
        public void ClearList()
        {
            storageOfUsers.ClearStorage();
        }

        /// <summary>
        /// Delete User from the storage.
        /// </summary>
        /// <param name="user"></param>
        public void DeleteUser(User user)
        {
            if (storageOfUsers.DeleteUser(user))
                user.DeleteUser();
        }

        /// <summary>
        /// Export data in xml format.
        /// </summary>
        /// <param name="fileName">Name of a document.</param>
        public void ExportXml(string fileName)
        {
            storageOfUsers.ExportXml(fileName, out string finalPath);
            var fileSize = new FileInfo(finalPath).Length;

            if (fileSize != 0)
                Console.WriteLine($"Document {fileName}.xml is created.");
        }

        /// <summary>
        /// Export data in csv format.
        /// </summary>
        /// <param name="fileName">Name of a document.</param>
        public void ExportCsv(string fileName)
        {
            storageOfUsers.ExportCsv(fileName, out string finalPath);
            var fileSize = new FileInfo(finalPath).Length;

            if (fileSize != 0)
                Console.WriteLine($"Document {fileName}.csv is created.");
        }

        /// <summary>
        /// Export data in text.
        /// </summary>
        /// <param name="fileName">Name of a document.</param>
        public void ExportTxt(string fileName)
        {
            storageOfUsers.SafeText(fileName);
        }

        /// <summary>
        /// Export data in xml format.
        /// </summary>
        /// <param name="fileName">Name of a document.</param>
        public void ImportXml(string fileName)
        {
            int usersSizeBefore = storageOfUsers.Count();
            storageOfUsers.ImportXml(fileName);
            int usersSizeAfter = storageOfUsers.Count();

            if (usersSizeBefore != usersSizeAfter)
                Console.WriteLine($"Document {fileName}.xml is loaded.");
        }

        /// <summary>
        /// Export data in csv format.
        /// </summary>
        /// <param name="fileName">Name of a document.</param>
        public void ImportCsv(string fileName)
        {
            int usersSizeBefore = storageOfUsers.Count();
            storageOfUsers.ImportCsv(fileName);
            int usersSizeAfter = storageOfUsers.Count();

            if (usersSizeBefore != usersSizeAfter)
                Console.WriteLine($"Document {fileName}.csv is loaded.");
      }

        #endregion
    }
}
