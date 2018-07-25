using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeTask
{
    public class BinarySearchTree<T>
    {
        public Node<T> root;
        Comparison<T> comparer;

        public BinarySearchTree(T[] initArray, Comparison<T> Comparer = null)
        {
            if (typeof(IComparable).IsAssignableFrom(typeof(T)) && Comparer == null)
            {
                comparer = Comparer<T>.Default.Compare;
            }
            else
            {
                comparer = Comparer;
            }

            CreateTree(initArray);
        }

        public void Add(T value)
        {
            if (root == null)
            {
                root = new Node<T>(value);
                return;
            }

            Node<T> currNode = root;

            while (true)
            {
                if (comparer(value, currNode.value) >= 0)
                {
                    if (currNode.rightNode == null)
                    {
                        currNode.rightNode = new Node<T>(value);
                        return;
                    }
                    currNode = currNode.rightNode;
                }
                else
                {
                    if (currNode.leftNode == null)
                    {
                        currNode.leftNode = new Node<T>(value);
                        return;
                    }
                    currNode = currNode.leftNode;
                }
            }
        }

        public IEnumerable<T> Preorder()
        {
            if (root == null)
            {
                throw new ArgumentNullException($"{nameof(root)} has null reference");
            }

            IEnumerable<T> GetOrder(Node<T> node)
            {
                yield return node.value;

                if (node.leftNode != null)
                {
                    foreach (var el in GetOrder(node.leftNode))
                    {
                        yield return el;
                    }
                }

                if (node.rightNode != null)
                {
                    foreach (var el in GetOrder(node.rightNode))
                    {
                        yield return el;
                    }
                }
            }

            return GetOrder(root);
        }

        public IEnumerable<T> Inorder()
        {
            if (root == null)
            {
                throw new ArgumentNullException($"{nameof(root)} has null reference");
            }

            IEnumerable<T> GetOrder(Node<T> node)
            {
                
                if (node.leftNode != null)
                {
                    foreach (var el in GetOrder(node.leftNode))
                    {
                        yield return el;
                    }
                }

                yield return node.value;

                if (node.rightNode != null)
                {
                    foreach (var el in GetOrder(node.rightNode))
                    {
                        yield return el;
                    }
                }
            }

            return GetOrder(root);
        }

        public IEnumerable<T> Postorder()
        {
            if (root == null)
            {
                throw new ArgumentNullException($"{nameof(root)} has null reference");
            }

            IEnumerable<T> GetOrder(Node<T> node)
            {

                if (node.leftNode != null)
                {
                    foreach (var el in GetOrder(node.leftNode))
                    {
                        yield return el;
                    }
                }

                if (node.rightNode != null)
                {
                    foreach (var el in GetOrder(node.rightNode))
                    {
                        yield return el;
                    }
                }

                yield return node.value;
            }

            return GetOrder(root);
        }


        private void CreateTree(T[] array)
        {
            foreach (T value in array)
            {
                Add(value);
            }
        }
    }
    
    public class Node<T>
    {
        internal T value;
        internal Node<T> leftNode;
        internal Node<T> rightNode;

        internal Node(T Value)
        {
            value = Value;
            rightNode = null;
            leftNode = null;
        }
    }
}
