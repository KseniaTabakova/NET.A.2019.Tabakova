using FileCabinet.Library.Cabinet;
using FileCabinet.Library.Exceptions;
using FileCabinet.Library.Person;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FileCabinet.Application
{
    class Program
    {
        static ConsoleColor color = Console.ForegroundColor;
        static string command;
        static int attempsToUseDelegate = 0;
        static bool alive = true;

        static void Main(string[] args)
        {
            #region Application appearance

            Cabinet myCabinet = new Cabinet();
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine(myCabinet.Name + "\n");
            myCabinet.GetDescription();
            Console.ForegroundColor = color;

            Console.WriteLine("The following commands are available:\n ");

            var column1 = new List<string>();
            var column2 = new List<string>();
            FileCabinetCommands.FillLists(column1, column2);

            var maxWidth = column1.Max(s => s.Length);
            var formatString = string.Format("{{0, -{0}}} |{{1,{1}}}", maxWidth, 4);

            Console.WriteLine(formatString, "Request description: ", "Command:\n ");
            for (int i = 0; i < column1.Count; i++)
            {
                Console.Write(formatString, column1[i], column2[i]);
                Console.WriteLine();
            }

            Console.WriteLine("\n" + @"If you want to exit just type ""exit"".");

            #endregion

            MyCommands.FillDictionary();

            while (alive)
            {
                Console.WriteLine();
                try
                {
                    command = Console.ReadLine();

                    MyCommands.ParseInput(command);
                    if (MyCommands.del != null && attempsToUseDelegate == 1)
                    {
                        attempsToUseDelegate--;
                        MyCommands.del(myCabinet);
                    }
                }
                catch (InvalidNameException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.message);
                    Console.ForegroundColor = color;

                }
                catch (InvalidDayOfBirthException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.message);
                    Console.ForegroundColor = color;
                }
                catch (FileNotFoundException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.message);
                    Console.ForegroundColor = color;
                }
                catch (UserAlreadyExistsException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.message);
                    Console.ForegroundColor = color;
                }
                catch (UserNotExistsException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.message);
                    Console.ForegroundColor = color;
                }
            }
        }

        #region Target methods
        private static void CreateNewUser(Cabinet cabinet)
        {
            Console.Write("First name: ");
            string userName = Console.ReadLine();
            Console.Write("Last name: ");
            string userLastName = Console.ReadLine();
            Console.Write("Date of birth: ");
            string userBirth = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            cabinet.CreateUser(userName, userLastName, userBirth);
            Console.ForegroundColor = color;
        }

        private static void ListAllUsers(Cabinet cabinet)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            var allUsers = cabinet.ListUsers();

            foreach (var user in allUsers)
            {
                if (command.Contains("id"))
                    Console.WriteLine($"#{user.ID}, {user.FirstName}, {user.LastName}, {user.DateOfBirth}");
                else
                    Console.WriteLine($"{user.FirstName}, {user.LastName}, {user.DateOfBirth}");
            }
            Console.ForegroundColor = color;
        }

        private static void StatUsers(Cabinet cabinet)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            string res = cabinet.Stat();
            Console.WriteLine(res);
            Console.ForegroundColor = color;
        }

        private static void FindUsers(Cabinet cabinet)
        {
            string[] strs = command.Split(new[] { '"', '"' }, StringSplitOptions.RemoveEmptyEntries);
            Console.ForegroundColor = ConsoleColor.Yellow;
            IEnumerable<User> allUsers;
            if (strs.Length > 1)
                allUsers = cabinet.FindUsers(strs[1], strs[3]);
            else
            {
                allUsers = cabinet.FindUsers(strs[1]);
            }

            foreach (User u in allUsers)
                Console.WriteLine(u.ToString());
            Console.ForegroundColor = color;
        }

        private static void EditUser(Cabinet cabinet)
        {
            int indexOfChar = command.IndexOf('#');
            int userId = int.Parse(command.Substring(indexOfChar + 1));
            User user = cabinet.FindUser(userId);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Dear {user.FirstName}, enter your new data, please: ");
            Console.ForegroundColor = color;

            CreateNewUser(cabinet);
        }

        private static void Export(Cabinet cabinet)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            string format = GetFormat(command);
            switch (format)
            {
                case "xml": cabinet.ExportXml("ExportXML"); break;
                case "csv": cabinet.ExportCsv("ExportCSV"); break;
                case "txt": cabinet.ExportTxt("Users"); break;
                default: Console.WriteLine("Sorry, we have't got such format!"); break;
            }
            Console.ForegroundColor = color;
        }

        private static void Purge(Cabinet cabinet)
        {
            cabinet.ClearList();
        }

        private static void DeleteUser(Cabinet cabinet)
        {
            int indexOfChar = command.IndexOf('#');
            int userId = int.Parse(command.Substring(indexOfChar + 1));
            User user = cabinet.FindUser(userId);

            Console.ForegroundColor = ConsoleColor.Yellow;
            cabinet.DeleteUser(user);
            Console.ForegroundColor = color;
        }

        private static void Import(Cabinet cabinet)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            string format = GetFormat(command);
            switch (format)
            {
                case "xml": cabinet.ImportXml("ExportXML"); break;
                case "csv": cabinet.ImportCsv("ExportCSV"); break;
                default: Console.WriteLine("Sorry, we have't got such format!"); break;
            }
            Console.ForegroundColor = color;
        }

        private static void Exit(Cabinet cabinet)
        {
            Console.WriteLine("Bye-bye!");
            Environment.Exit(0);
        }

        #endregion

        private static string GetFormat(string command)
        {
            string[] str = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string format = String.Empty;
            foreach (string s in str)
                if (s.ToUpper() == "XML" || s.ToUpper() == "CSV" || s.ToUpper() == "TXT")
                {
                    format = s;
                    return format;
                }
            return format;
        }

        #region Container for target methods delegate 

        class MyCommands
        {
            private static Dictionary<string, Action<Cabinet>> commandsDictionary = new Dictionary<string, Action<Cabinet>>();
            internal static Action<Cabinet> del = null;

            public static void FillDictionary()
            {
                commandsDictionary.Add("CREATE", CreateNewUser);
                commandsDictionary.Add("STAT", StatUsers);
                commandsDictionary.Add("LIST", ListAllUsers);
                commandsDictionary.Add("FIND", FindUsers);
                commandsDictionary.Add("EDIT", EditUser);
                commandsDictionary.Add("EXPORT", Export);
                commandsDictionary.Add("IMPORT", Import);
                commandsDictionary.Add("REMOVE", DeleteUser);
                commandsDictionary.Add("PURGE", Purge);
                commandsDictionary.Add("EXIT", Exit);
            }

            public static void ParseInput(string inputCommand)
            {
                foreach (string key in commandsDictionary.Keys)
                {
                    if (inputCommand.ToUpper().Contains(key))
                    {
                        del = commandsDictionary[key];
                        attempsToUseDelegate++;
                        break;
                    }
                }
                if (del == null || attempsToUseDelegate == 0)
                {
                    Console.WriteLine("There is't such command! Try again.");
                }
            }
        }

        #endregion
    }
}
