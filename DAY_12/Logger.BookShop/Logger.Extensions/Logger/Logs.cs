using System;
using System.IO;
using System.Linq;

namespace BookExtensions.Logger
{
    /// <summary>
    /// class contains logic for message log.
    /// </summary>
    public class Logs
    {
        /// <summary>
        /// Path to the message file.
        /// </summary>
        static private string path;

        /// <summary>
        /// Directory for message logger file. 
        /// </summary>
        static private string directory;

        /// <summary>
        /// Directory pointer.
        /// </summary>
        static public DirectoryInfo di;

        /// <summary>
        /// FileInfo pointer.
        /// </summary>
        static public FileInfo fileInfo;

        /// <summary>
        /// Constructor.
        /// </summary>
        public Logs()
        {
            directory = AppDomain.CurrentDomain.BaseDirectory + @"\Log";
            path = directory + @"\Logs.log";
            di = new DirectoryInfo(directory);

            if (!di.Exists)
            {
                di.Create();
            }

            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine("---------Start----------");
                }
            }
        }

        /// <summary>
        /// Fille the logger file with information.
        /// </summary>
        static public void FileEx()
        {
            DateTime now = DateTime.Now;
            string newfile = directory + @"\" + now.ToString("yyMMddhhmmss") + ".old";
            fileInfo = new FileInfo(path);

            if (fileInfo.Length > 100000)
            {
                if (!File.Exists(directory + @"\" + now.ToString("yyMMddhhmmss") + ".old"))
                {
                    File.Move(path, newfile);
                    FileInfo fileOld = new FileInfo(newfile);
                    fileOld.CreationTime = now;
                }
                else
                {
                    fileInfo = new FileInfo(directory + @"\" + now.ToString("yyMMddhhmmss") + ".old");
                    fileInfo.Delete();
                }
            }

            var files = Directory.GetFiles(directory, "*.old", SearchOption.AllDirectories);
            if (files.Length > 20)
            {
                var iter = files.OrderByDescending(f => File.GetCreationTime(f));
                foreach (string item in iter.Skip(20))
                {
                    fileInfo = new FileInfo(item);
                    fileInfo.Delete();
                    Console.WriteLine(item);
                }
            }
        }

        /// <summary>
        /// Informational message of app events.
        /// </summary>
        /// <param name="msg">Message to show.</param>
        public void Info(string msg)
        {
            FileEx();
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("{0} [INFO]  {1}", DateTime.Now, msg);
            }
        }

        /// <summary>
        /// Exception message of app events.
        /// </summary>
        /// <param name="msg">Message to show.</param>
        public void Error(string msg)
        {
            FileEx();
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("{0} [ERR]  {1}", DateTime.Now, msg);
            }
        }
    }
}