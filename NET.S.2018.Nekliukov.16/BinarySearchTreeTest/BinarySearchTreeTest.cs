using System;
using System.Linq;
using NUnit.Framework;
using BinarySearchTreeTask;

namespace BinarySearchTreeTest
{
    [TestFixture]
    public class BinarySearchTreeTest
    {
        [Test]
        public void GeneralTesting()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>(new int[] { 2, 6, 20, 11, 7, 16, 3, 1 });
            int[] arr = bst.Preorder().ToArray();
            Console.WriteLine("Pre oreder:");
            foreach (var item in arr)
                Console.Write(item + "   ");
            Console.WriteLine();

            arr = bst.Inorder().ToArray();
            Console.WriteLine("In oreder:");
            foreach (var item in arr)
                Console.Write(item + "   ");
            Console.WriteLine();

            arr = bst.Postorder().ToArray();
            Console.WriteLine("Post oreder:");
            foreach (var item in arr)
                Console.Write(item + "   ");
            Console.WriteLine();

            Console.WriteLine(bst.IsExists(1111));
            Console.WriteLine(bst.IsExists(20));
        }

        [TestCase(new double[] { 43.45, 1, 0.00053, 0.4, 123, 55.3234351, double.MinValue, double.MaxValue },
            ExpectedResult = new double[] {double.MinValue, 0.00053, 0.4, 1, 43.45, 55.3234351 , 123, double.MaxValue })]
        [TestCase(new double[] { double.MaxValue },
            ExpectedResult = new double[] { double.MaxValue })]
        public double[] TestInOrder_Double(double[] initArray)
        {
            BinarySearchTree<double> bst = new BinarySearchTree<double>(initArray);
            return bst.Inorder().ToArray();
        }

        [TestCase(new int[] { 34,2,6,20,1,-3,6 }, ExpectedResult = new int[] { -3,1,2,6,6,20,34 })]
        [TestCase(new int[] { -0, 0 }, ExpectedResult = new int[] { -0, 0 })]
        public int[] TestInOrderInt_DefaultComparer(int[] initArray)
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>(initArray);
            return bst.Inorder().ToArray();
        }

        [TestCase(new int[] { 34, 2, 6, 20, 1, -3, 6 }, ExpectedResult = new int[] { 34, 20, 6, 6, 2, 1, -3 })]
        [TestCase(new int[] { 1,2,3,4,5,6 }, ExpectedResult = new int[] { 6,5,4,3,2,1 })]
        public int[] TestInOrderInt_SettedComparer(int[] initArray)
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>(initArray, (a,b) => - a + b);
            return bst.Inorder().ToArray();
        }

        [Test]
        public void TestInOrderString_DefaultComparer()
        {
            string[] names = new string[] { "roman", "nekliukov roman", "roma", "romchik" };
            string[] expecterResult = new string[] { "nekliukov roman", "roma", "roman", "romchik" };
            BinarySearchTree<string> bst = new BinarySearchTree<string>(names);
            CollectionAssert.AreEqual(expecterResult, bst.Inorder().ToArray());
        }

        [Test]
        public void TestInOrderString_Settedomparer()
        {
            string[] names = new string[] { "roman", "nekliukov roman", "roma", "romchik" };
            string[] expecterResult = new string[] { "roma", "roman", "romchik", "nekliukov roman" };
            BinarySearchTree<string> bst = new BinarySearchTree<string>(names, (string s1, string s2) => s1.Length - s2.Length);
            CollectionAssert.AreEqual(expecterResult, bst.Inorder().ToArray());
        }

        [Test]
        public void TestInOrderPoints_SettedComparer()
        {
            Point[] points = new Point[] { new Point(3, 3), new Point(0, 1), new Point(1, 10) };
            Point[] expectedPoints = new Point[] { new Point(0, 1), new Point(1, 10), new Point(3, 3)};
            StructComparer.ComapreByX cmpByX= new StructComparer.ComapreByX();
            BinarySearchTree<Point> bst = new BinarySearchTree<Point>(points, cmpByX.Compare);
            CollectionAssert.AreEqual(expectedPoints, bst.Inorder().ToArray());
        }

        [Test]
        public void TestInOrderPoints_DefaultComparer()
        {
            Point[] points = new Point[] { new Point(3, 3), new Point(0, 1), new Point(1, 10) };
            Point[] expectedPoints = new Point[] { new Point(0, 1), new Point(3, 3), new Point(1, 10)};
            BinarySearchTree<Point> bst = new BinarySearchTree<Point>(points);
            CollectionAssert.AreEqual(expectedPoints, bst.Inorder().ToArray());
        }

        [Test]
        public void TestInOrderBooks_DefaultComparer()
        {
            Book[] books = new Book[] { new Book("Richter", 1200), new Book("Skit", 600),
                new Book("Albahari", 13000) };
            Book[] expectedBooks = { books[1], books[0], books[2] };
            BinarySearchTree<Book> bst = new BinarySearchTree<Book>(books);
            CollectionAssert.AreEqual(expectedBooks, bst.Inorder().ToArray());
        }

        [Test]
        public void TestInOrderBooks_SettedComparer()
        {
            Book[] books = new Book[] { new Book("Jeffrey Richter", 1200), new Book("Skit", 600),
                new Book("Albahari", 13000) };
            Book[] expectedBooks = { books[1], books[2], books[0] };
            BookComparer.CompareByAuthor cmpByAutorLen = new BookComparer.CompareByAuthor();
            BinarySearchTree<Book> bst = new BinarySearchTree<Book>(books, cmpByAutorLen.Compare);
            CollectionAssert.AreEqual(expectedBooks, bst.Inorder().ToArray());
        }

        /// <summary>
        ///  Structure for points testing
        /// </summary>
        public struct Point: IComparable<Point>
        {
            public double x;
            public double y;

            public Point(double X, double Y)
            {
                x = X; y = Y;
            }

            public int CompareTo(Point other)
            {
                double distance = Math.Sqrt(x * x + y * y),
                    otherDistance = Math.Sqrt(other.x * other.x + other.y * other.y);

                if (distance == otherDistance)
                {
                    return 0;
                }
                else if (distance > otherDistance)
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
