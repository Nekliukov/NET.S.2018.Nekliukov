using System.Collections.Generic;

namespace BinarySearchTreeTest
{
    public class BookComparer
    {
        public class CompareByAuthor : IComparer<Book>
        {
            public int Compare(Book lhs, Book rhs)
            {
                if (lhs.author.Length == rhs.author.Length)
                {
                    return 0;
                }

                return lhs.author.Length > rhs.author.Length ? 1 : -1;
            }
        }
    }
}
