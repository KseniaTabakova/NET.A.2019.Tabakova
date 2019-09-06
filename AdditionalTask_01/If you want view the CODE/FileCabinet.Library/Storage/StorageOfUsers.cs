using FileCabinet.Library.Person;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace FileCabinet.Library.Storage
{
    /// <summary>
    /// Class represents Users storage. 
    /// </summary>
    class StorageOfUsers : Storage, IFileSystem, IEnumerable<User>
    {
        /// <summary>
        /// Create instance of storage which will work with Users operations.
        /// </summary>
        public StorageOfUsers()
        {
            if (users is null)
                users = new List<User>();
        }

        #region API
        /// <summary>
        /// Add User in the storage.
        /// </summary>
        /// <param name="user">User which should be added to the storage.</param>
        /// <returns>Operation success status.</returns>
        public override bool AddUser(User user)
        {
            if (users.Contains(user))
            {
                throw new Exceptions.UserAlreadyExistsException("User already exists in storage. Change your input please.");
            }
            users.Add(user);
            return true;
        }

        /// <summary>
        /// Delete User from the storage.
        /// </summary>
        /// <param name="user">User which should be deleted to the storage.</param>
        /// <returns>Operation success status.</returns>
        public override bool DeleteUser(User user)
        {
            if (!users.Contains(user))
            {
                throw new Exceptions.UserNotExistsException("Storage has't got such user.");
            }
            users.Remove(user);
            return true;
        }

        /// <summary>
        /// Edit User in the storage.
        /// </summary>
        /// <param name="user">User which would like to be changed.</param>
        /// <param name="newName">New User first name.</param>
        /// <param name="newLName">New User last name.</param>
        /// <param name="newDB">New User day of birth.</param>
        /// <returns>Operation success status.</returns>
        public bool EditUser(User user, string newName, string newLName, string newDB)
        {
            User newUser = new StandardUser(newName, newLName, newDB);

            users.Find(t => t.ID == user.ID).FirstName = newName;
            users.Find(t => t.ID == user.ID).LastName = newLName;
            users.Find(t => t.ID == user.ID).DateOfBirth = newDB;
            if (user.Equals(newUser))
                return true;
            return false;
        }

        /// <summary>
        /// Returns a collection of Users data that storage contains.
        /// </summary>
        /// <returns>A collection of Users data.</returns>
        public IEnumerable<User> ListUsers()
        {
            if (users.Count == 0)
                throw new Exceptions.UserNotExistsException("Storage has not users.");
            return users;
        }

        /// <summary>
        /// Count users in the storage.
        /// </summary>
        /// <returns>The amount of users in the storage.</returns>
        public override int Count()
        {
            if (users is null)
                return 0;
            int count = users.Count();
            return count;
        }

        /// <summary>
        /// Returns a collection of Users data which meet the criteria.
        /// </summary>
        /// <param name="findName">Criteria.</param>
        /// <returns>A collection of Users data.</returns>
        public IEnumerable<User> FindUser(string findName)
        {
            if (users.Find(t => t.FirstName == findName) is null)
                throw new Exceptions.UserNotExistsException("Storage has't got such users.");
            var usersToFind = (from user in users
                               where user.FirstName == findName
                               select user).ToArray();
            return usersToFind;
        }

        /// <summary>
        /// Returns a collection of Users data which meet the criteria.
        /// </summary>
        /// <param name="findName">Criteria.</param>
        /// <param name="lastName">Criteria.</param>
        /// <returns>A collection of Users data.</returns>
        public IEnumerable<User> FindUser(string findName, string lastName)
        {
            if (users.Find(t => t.FirstName == findName && t.LastName == lastName) is null)
                throw new Exceptions.UserNotExistsException("Storage has't got such users.");
            var usersToFind = (from user in users
                               where user.FirstName == findName && user.LastName == lastName
                               select user).ToArray();
            return usersToFind;
        }

        /// <summary>
        /// Returns instance of User.
        /// </summary>
        /// <param name="id">User id.</param>
        /// <returns>Instance of User.</returns>
        public User FindUser(int id)
        {
            if (users.Find(t => t.ID == id) is null)
                throw new Exceptions.UserNotExistsException("Storage has't got such user.");
            User usersToFind = (from user in users
                                where user.ID == id
                                select user).First();
            return usersToFind;
        }

        /// <summary>
        /// Clear users from the storage.
        /// </summary>
        public override void ClearStorage()
        {
            users.Clear();
        }

        #endregion

        #region Working with file system

        /// <summary>
        /// Export available Users data from storage in XML format.
        /// </summary>
        /// <param name="fileName">The name of exported file.</param>
        public void ExportXml(string fileName, out string filePath)
        {
            using (XmlTextWriter writer = new XmlTextWriter(fileName + ".xml", Encoding.GetEncoding(1251)))
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 1;
                writer.IndentChar = '\t';
                writer.WriteStartDocument();
                writer.WriteStartElement("FileCabinet");
                foreach (var user in users)
                {
                    writer.WriteStartElement("User");
                    writer.WriteAttributeString("UserID", user.ID.ToString());
                    {
                        writer.WriteElementString("FirstName", user.FirstName.ToString());
                        writer.WriteElementString("LastName", user.LastName.ToString());
                        writer.WriteElementString("DayOfBirth", user.DateOfBirth.ToString());
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            filePath = Path.Combine(basePath, fileName + ".xml");
        }

        /// <summary>
        /// Export available Users data from storage in CSV format.
        /// </summary>
        /// <param name="fileName">The name of exported file.</param>
        public void ExportCsv(string fileName, out string finalPath)
        {
            var sb = new StringBuilder();
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            finalPath = Path.Combine(basePath, fileName + ".csv");
            var header = "";
            var info = typeof(User).GetProperties();
            if (!File.Exists(finalPath))
            {
                var file = File.Create(finalPath);
                file.Close();
                foreach (var prop in typeof(User).GetProperties())
                {
                    header += prop.Name + "; ";
                }

                header = header.Substring(0, header.Length - 2);
                sb.AppendLine(header);
                TextWriter sw = new StreamWriter(finalPath, true);
                sw.Write(sb.ToString());
                sw.Close();
            }

            foreach (var obj in users)
            {
                sb = new StringBuilder();
                var line = "";
                foreach (var prop in info)
                {
                    line += prop.GetValue(obj, null) + "; ";
                }

                line = line.Substring(0, line.Length - 2);
                sb.AppendLine(line);
                TextWriter sw = new StreamWriter(finalPath, true);
                sw.Write(sb.ToString());
                sw.Close();
            }

        }

        /// <summary>
        /// Import Users data from document of XML format.
        /// </summary>
        /// <param name="fileName">The name of imported file.</param>
        public void ImportXml(string fileName)
        {
            XmlDocument xDoc = new XmlDocument();
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var finalPath = Path.Combine(basePath, fileName + ".xml");
            if (File.Exists(fileName + ".xml"))
                xDoc.Load(finalPath);
            else
                throw new FileNotFoundException("File was not found");

            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlElement xnode in xRoot)
            {
                User user = new StandardUser();
                XmlNode attr = xnode.Attributes.GetNamedItem("UserID");
                if (attr != null)
                    user.ID = int.Parse(attr.Value);

                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "FirstName")
                        user.FirstName = childnode.InnerText;
                    if (childnode.Name == "LastName")
                        user.LastName = childnode.InnerText;
                    if (childnode.Name == "DayOfBirth")
                        user.DateOfBirth = childnode.InnerText;
                }
                users.Add(user);
            }
        }

        /// <summary>
        /// Import Users data from document of CSV format.
        /// </summary>
        /// <param name="fileName">The name of imported file.</param>
        public void ImportCsv(string fileName)
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var finalPath = Path.Combine(basePath, fileName + ".csv");
            if (File.Exists(fileName + ".csv"))
            {
                using (StreamReader sr = new StreamReader(finalPath))
                {
                    string line;
                    string test = "";
                    string[] headers = sr.ReadLine().Split(';');
                    foreach (string header in headers)
                    {
                        test += header;
                    }

                    string[] row = new string[4];
                    while ((line = sr.ReadLine()) != null)
                    {
                        row = line.Split(';');
                        User user = new StandardUser();
                        user.FirstName = row[0].Trim();
                        user.LastName = row[1].Trim();
                        user.DateOfBirth = row[2].Trim();
                        user.ID = int.Parse(row[3]);
                        users.Add(user);
                    }
                }
            }
            else
                throw new FileNotFoundException("File was not found");
        }

        /// <summary>
        /// Export available Users data from storage in text.
        /// </summary>
        /// <param name="fileName">The name of imported file.</param>
        public void SafeText(string fileName)
        {
            using (StreamWriter sw = new StreamWriter(File.OpenWrite(fileName + ".txt")))
            {
                users.ForEach(x => sw.WriteLine($"User ID: {x.ID}, First Name: {x.FirstName}, Last Name: {x.LastName}, nDay of Birth: {x.DateOfBirth}\n"));
            }
        }

        #endregion            

        public IEnumerator<User> GetEnumerator()
        {
            return users.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
