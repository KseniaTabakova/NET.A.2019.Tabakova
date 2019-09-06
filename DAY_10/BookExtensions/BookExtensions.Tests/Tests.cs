using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineBookstore.Library.Book;

namespace BookExtensions.Tests
{
    [TestClass]
    public class BookExtensionsTests
    {
        #region Format Representation
        [TestMethod]
        public void FormatRepresentation_Format_A()
        {
            Book bookRichter = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99);
            string result = bookRichter.GetBookFormat("A", null);

            string expected = "Jeffrey Richter, CLR via C#";
            Assert.AreEqual(expected, result);
        }

        public void FormatRepresentation_Format_B()
        {
            Book bookRichter = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99);
            string result = bookRichter.GetBookFormat("B", null);

            string expected = "Jeffrey Richter, CLR via C#, \"Microsoft Press\", 2012";
            Assert.AreEqual(expected, result);
        }

        public void FormatRepresentation_Format_C()
        {
            Book bookRichter = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99);
            string result = bookRichter.GetBookFormat("C", null);

            string expected = "ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, \"Microsoft Press\", 2012, P. 826";
            Assert.AreEqual(expected, result);
        }

        public void FormatRepresentation_Format_E()
        {
            Book bookRichter = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99);
            string result = bookRichter.GetBookFormat("E", null);

            string expected = "ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, \"Microsoft Press\", 2012, P. 826, $59.99";
            Assert.AreEqual(expected, result);
        }
        #endregion

        public void BookDecorator_BookAboutAuthor()
        {
            AbstractBook previousBook = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99);
            previousBook = new BookAuthor(previousBook, "978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99);
            string result =  previousBook.GetNewBookFormat();

            string expected = "More information about Jeffrey Richter you can find here: https://www.google.com/";
            Assert.AreEqual(expected, result);
        }

        public void BookDecorator_BookAboutTitle()
        {
            AbstractBook previousBook = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99);
            previousBook = new BookTitle(previousBook, "978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99);
            string result = previousBook.GetNewBookFormat();

            string expected = "If you have any recommendation about CLR via C# just write me: ksenia @tut.by";
            Assert.AreEqual(expected, result);
        }

        public void BookDecorator_BookAboutPrice()
        {
            AbstractBook previousBook = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99);
            previousBook = new BookPrice(previousBook, "978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99);
            string result = previousBook.GetNewBookFormat();

            string expected = "Total price for You is 59.99";
            Assert.AreEqual(expected, result);
        }
    }
}
