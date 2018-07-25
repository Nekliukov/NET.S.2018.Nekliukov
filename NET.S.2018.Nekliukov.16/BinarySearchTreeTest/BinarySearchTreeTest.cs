using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BinarySearchTreeTask;
using System.Diagnostics;

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
        }
    }
}
