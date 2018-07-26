using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeTest
{
    public class StructComparer
    {
        public class ComapreByX : IComparer<BinarySearchTreeTest.Point>
        {
            public int Compare(BinarySearchTreeTest.Point lhs, BinarySearchTreeTest.Point rhs)
            {
                if (lhs.x == rhs.x)
                {
                    return 0;
                }
                else if (lhs.x > rhs.x)
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
}
