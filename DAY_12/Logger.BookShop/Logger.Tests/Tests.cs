using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace BookExtensions.Tests
{
    [TestClass]
    public class LogsTests
    {
        BookListService bookShop = new BookListService(new BookListStorage(), new Logs());
        string line;

        [TestMethod]
        public void BookLoggerTest_InfoMessage()
        {
            Book rigthBook = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99);
            bool added = bookShop.AddBookToShop(rigthBook);
            using (StreamReader reader = new StreamReader("Logs.log"))
            {
                line = reader.ReadLine();
            }

            string[] mess = line.Split("[INFO]", StringSplitOptions.RemoveEmptyEntries);
            line = mess[1].Trim();
           
            Assert.AreEqual(@"Book ""CLR via C#"" was added.", line);
        }

        [TestMethod]
        public void BookLoggerTest_ErrorMessage()
        {
            Book wrongBook = new Book("978", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99);
            bool added = bookShop.AddBookToShop(wrongBook);
            using (StreamReader reader = new StreamReader("Logs.log"))
            {
                line = reader.ReadLine();
            }

            string[] mess = line.Split("[ERR]", StringSplitOptions.RemoveEmptyEntries);
            line = mess[1].Trim();

            Assert.AreNotEqual(@"Book ""CLR via C#"" was added.", line);

        }
    }
}