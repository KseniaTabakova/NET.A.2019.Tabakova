using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCabinet.Application
{
    public class FileCabinetCommands
    {
        List<string> column1 = new List<string>();
        List<string> column2 = new List<string>();

        internal static void FillLists(List<string> column1, List<string> column2)
        {
            column1.Add("Create a user record");
            column1.Add("Display the amount of users");
            column1.Add("List all information about users");
            column1.Add("List appropriate about all users");
            column1.Add("Find the appropriate user by name");
            column1.Add("Find the appropriate user by name and surname");
            column1.Add("Find user by id and edit it");
            column1.Add("Export users in XML format");
            column1.Add("Export users in CSV format");
            column1.Add("Save users in a text");
            column1.Add("Import users in XML format");
            column1.Add("Import users in CSV format");
            column1.Add("Delete user");
            column1.Add("Clear list of users");

            column2.Add("create");
            column2.Add("stat");
            column2.Add("list");
            column2.Add("list id, firstname, lastname");
            column2.Add(@"find firstname ""John""");
            column2.Add(@"find firstname ""John"", lastname ""Doe""");
            column2.Add("edit #1");
            column2.Add("export xml");
            column2.Add("export csv");
            column2.Add("export txt");
            column2.Add("import xml");
            column2.Add("import csv");
            column2.Add("remove #1");
            column2.Add("purge");
        }
    }
}
