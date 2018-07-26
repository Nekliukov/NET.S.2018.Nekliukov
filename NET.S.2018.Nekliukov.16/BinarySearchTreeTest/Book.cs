using System;

namespace BinarySearchTreeTest
{
    public class Book: IComparable<Book>
    {
        internal string author;
        internal int pagesNum;

        internal Book(string Author, int Pages)
        {
            pagesNum = Pages;
            author = Author;
        }

        public int CompareTo(Book other)
        {
            if (pagesNum > other.pagesNum)
            {
                return 1;
            }
            else if (pagesNum == other.pagesNum)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
}
