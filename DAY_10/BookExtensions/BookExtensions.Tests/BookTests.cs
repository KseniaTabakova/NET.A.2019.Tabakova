using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookExtensions;

namespace Tests
{
    [TestClass]
    public class BookExtensionsTests
    {
        #region Format Representation
        [TestMethod]
        public void FormatRepresentation_Format_A()
        {
            Book bookRichter = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99);
            string result = bookRichter.ToString("A", null);

            string expected = "Jeffrey Richter, CLR via C#";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FormatRepresentation_Format_B()
        {
            Book bookRichter = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99);
            string result = bookRichter.ToString("B", null);

            string expected = @"Jeffrey Richter, CLR via C#, Microsoft Press, 2012";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FormatRepresentation_Format_C()
        {
            Book bookRichter = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99);
            string result = bookRichter.ToString("C", null);

            string expected = @"ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, Microsoft Press, 2012, P. 826";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FormatRepresentation_Format_E()
        {
            Book bookRichter = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99);
            string result = bookRichter.ToString("E", null);

            string expected = @"ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, Microsoft Press, 2012, P. 826, $59.99";
            Assert.AreEqual(expected, result);
        }
        #endregion

        #region Book Decorator
        [TestMethod]
        public void BookDecorator_AuthorInformation()
        {
            AbstractBook previousBook = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99);

            previousBook = new BookWithAuthorInformation(previousBook, "978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99);
            string result = previousBook.AdditionalInformation;
            
            string expected = "More information about Jeffrey Richter you can find here: https://www.google.com/";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BookDecorator_TitleInformation()
        {
            AbstractBook previousBook = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99);

            previousBook = new BookWithTitleInformation(previousBook, "978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99);
            string result = previousBook.AdditionalInformation;

            string expected = "If you have any recommendation about CLR via C# just write me: Jeffrey Richter@gmail.com";
            Assert.AreEqual(expected, result);
        }
        #endregion
    }
}
