using OnlineBookstore.Library;
using OnlineBookstore.Library.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineBookstore.Application_
{
    class Program
    {
        static bool alive = true;
        static string command;
        static AbstractBookStorage storage;
        static BookListService bookShop;

        static void Main(string[] args)
        {
            storage = new BookListStorage();
            bookShop = new BookListService(storage);

            Console.WriteLine("Next commands are availiable:" + "\n");
            Console.WriteLine("1. Show all books");
            Console.WriteLine("2. Add a book");
            Console.WriteLine("3. Delete a book");
            Console.WriteLine("4. Find appropriate book");
            Console.WriteLine("5. Sort books" + "\n");

            while (alive)
            {
                try
                {
                    command = Console.ReadLine();
                    switch (command)
                    {
                        case "1": ShowAvailableBooks(bookShop); break;
                        case "2": AddBookToShop(bookShop); break;
                        case "3": DeleteBook(bookShop); break;
                        default: Console.WriteLine("Sorry, this command still in process..");break;
                    }
                }
                catch (InvalidBookDataException e)
                {
                    Console.WriteLine(e.message);
                }
                catch (BookAlreadyExistsException e)
                {
                    Console.WriteLine(e.message);
                }
                catch (BookNotExistsException e)
                {
                    Console.WriteLine(e.message);
                }               
            }
        }

        private static void AddBookToShop(BookListService bookShop)
        {
            Console.Write("To add book to the storage you need enter the following data:" + "\n");
            Console.Write("ISBN * Author * Title * Publisher * Year of publication * Number of pages * Price." + "\n\n");
            Console.WriteLine("Enter this data separated by commas.");

            string input = Console.ReadLine();
            string[] enretedData = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            var isbn = enretedData[0];
            var author = enretedData[1];
            var title = enretedData[2];
            var publisher = enretedData[3];
            var year = int.Parse(enretedData[4]);
            var pages = int.Parse(enretedData[5]);
            var price = double.Parse(enretedData[6]);

            bookShop.AddBookToShop(new Book(isbn, author, title, publisher, year, pages, price));
        }

        private static void DeleteBook(BookListService bookShop)
        {    
            Console.WriteLine("Enter ISBN of book you want to delete."+"\n");
            string isbnBook = Console.ReadLine();

            Book bookToRemove = bookShop.FindBook(isbnBook);
            bookShop.RemoveBookFromShop(bookToRemove);
        }

        private static void ShowAvailableBooks(BookListService bookShop)
        {
            IList<Book> books;
            Console.WriteLine("\n" + "Enter preferable format: 1, 2 or 3.");
            string format = Console.ReadLine();

            if (storage.Count() == 0)
                books =  storage.LoadBooks();
            else
                books = bookShop.Refresh(storage);

            int tableWidth = GetTableWidth(books, format);
            PrintBooksData(tableWidth, format, books);
        }

        private static int GetTableWidth(IEnumerable<Book> storage, string format)
        {
            var res = from books in storage
                      let maxLength = books.ToString(format).Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Max(s => s.Length)
                      orderby maxLength
                      select maxLength;
            return res.FirstOrDefault();
        }

        private static void PrintBooksData(int tableWidth, string format, IList<Book> storage)
        {
            var formatString = string.Format(" {{0,{0}}} |", tableWidth);

            string[] headline = ToStringHeadline(format).Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var p in headline)
            {
                Console.Write(formatString, p);
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', (tableWidth + 3) * headline.Count()));

            for (int i = 0; i < storage.Count(); i++)
            {
                string[] bookElements = storage[i].ToString(format).Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var p in bookElements)
                {
                    Console.Write(formatString, p);
                }
                Console.WriteLine();
                Console.WriteLine(new string('-', (tableWidth + 3) * bookElements.Count()));
            }
        }

        private static string ToStringHeadline(string format)
        {
            switch (format)
            {
                case "1": return "Title:" + ", " + "Author:";
                case "2": return "Title:" + ", " + "Year:" + ", " + "Author:" + ", " + "ISBN:";
                case "3": return "Title:" + ", " + "Year:" + ", " + "Pages:" + ", " + "Author:" + ", " + "ISBN:" + ", " + "Publisher:" + ", " + "Price:";
                default: throw new FormatException(String.Format("The {0} format string is not supported.", format));
            }
        }

    }
}