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
        public void TestMethod()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>(new int[] { 2, 6, 20 , 11 , 7 , 16, 3, 1 });
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
    }
}
