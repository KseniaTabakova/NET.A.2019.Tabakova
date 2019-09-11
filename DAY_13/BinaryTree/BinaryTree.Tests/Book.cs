using System;

namespace BinarySearchTreeTests
{
    public class Book : IComparable<Book>
    {
        public string Name;
        private string Author;
        private int Pages;

        public Book(string author, string name, int pages)
        {
            this.Name = name;
            this.Author = author;
            this.Pages = pages;
        }

        public override bool Equals(object other)
        {
            if (other == null)
            {
                return false;
            }

            return Name == (other as Book).Name && Author == (other as Book).Author && Pages == (other as Book).Pages;
        }

        public int CompareTo(Book other)
        {
            if (other is null)
            {
                return 1;
            }

            if (Pages == other.Pages)
            {
                return 0;
            }

            if (Pages > other.Pages)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}