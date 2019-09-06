using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineBookstore.Library;
using OnlineBookstore.Library.Books;
using OnlineBookstore.Library.Logger;
using System.IO;

namespace BookExtensions.Tests
{
    [TestClass]
    public class LogsTests
    {
        [TestMethod]
        public void BookstorageLoggerTest()
        {
            BookListService bookShop = new BookListService(new BookListStorage(), new Logs());
            string line;

            Book rigthBook = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99);
            bool added = bookShop.AddBookToShop(rigthBook);
            using (StreamReader reader = new StreamReader("logs.log"))
            {
                line = reader.ReadLine();
            }
                        
            int index = line.IndexOf(' ');
            line = line.Substring(index + 6);

            Assert.AreEqual($"Book \"CLR via C#\" was added.", line);
            
        }
    }
}
