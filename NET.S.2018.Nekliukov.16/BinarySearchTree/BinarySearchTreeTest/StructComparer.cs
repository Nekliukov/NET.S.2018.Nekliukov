using System;
using System.Collections.Generic;
using static BinarySearchTreeTest.BinarySearchTreeTest;

namespace BinarySearchTreeTest
{
    public class StructComparer
    {
        public class ComapreByX : IComparer<Point>
        {
            private const double TOLERANCE = 0.00000001;

            public int Compare(Point lhs, Point rhs)
            {
                if (Math.Abs(lhs.x - rhs.x) < TOLERANCE)
                {
                    return 0;
                }

                return (lhs.x > rhs.x) ? 1 : -1;
            }
        }
    }
}
