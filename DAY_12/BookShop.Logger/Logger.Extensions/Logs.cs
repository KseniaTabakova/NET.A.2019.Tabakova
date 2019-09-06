using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookstore.Library.Logger
{
    public class Logs
    {
        static private string path;
        static private string directory;
        static public DirectoryInfo di;
        static public FileInfo fileInfo;

        public Logs()
        {
            directory = AppDomain.CurrentDomain.BaseDirectory + @"\Log";

            path = directory + @"\logs.log";
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

        static public void FileEx()
        {
            DateTime now = DateTime.Now;
            String newfile = directory + @"\" + now.ToString("yyMMddhhmmss") + ".old";
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

        public void Info(string msg)
        {
            FileEx();
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("{0} [INFO]  {1}", DateTime.Now, msg);
            }
        }
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
