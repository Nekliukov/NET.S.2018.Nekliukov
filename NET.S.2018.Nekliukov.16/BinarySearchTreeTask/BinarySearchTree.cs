using System;
using System.Collections.Generic;

namespace BinarySearchTreeTask
{
    public class BinarySearchTree<T>
    {
        #region Private fields
        /// <summary>
        /// Binary search tree root
        /// </summary>
        private Node<T> root;

        /// <summary>
        /// The comparer for choosen type
        /// </summary>
        private Comparison<T> comparer;
        #endregion

        #region .Ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        /// <param name="initArray">The initialize array.</param>
        public BinarySearchTree(T[] initArray) : this(initArray, Comparer<T>.Default.Compare) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        /// <param name="initArray">The initialize array.</param>
        /// <param name="Comparer">The comparer.</param>
        /// <exception cref="ArgumentNullException">Null initArray was sent</exception>
        /// <exception cref="ArgumentException">Empty initArray was sent</exception>
        /// <exception cref="InvalidOperationException">Your type doesn't implement IComparable interface</exception>
        public BinarySearchTree(T[] initArray, Comparison<T> Comparer)
        {
            if (initArray == null)
            {
                throw new ArgumentNullException($"Null {nameof(initArray)} was sent");
            }

            if (initArray.Length == 0)
            {
                throw new ArgumentException($"Empty {nameof(initArray)} was sent");
            }

            if (!typeof(IComparable<T>).IsAssignableFrom(typeof(T)) &&
                !typeof(IComparable).IsAssignableFrom(typeof(T)))
            {
                throw new InvalidOperationException("Your type doesn't implement IComparable interface");
            }

            comparer = Comparer;
            CreateTree(initArray);
        }
        #endregion

        #region Public API       
        /// <summary>
        /// Adds the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentNullException">"Null value was sent</exception>
        public void Add(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException($"Null {nameof(value)} was sent");
            }

            if (root == null)
            {
                root = new Node<T>(value);
                return;
            }

            AddNode(value);
        }

        /// <summary>
        /// Preorder tree traversal
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">root</exception>
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

        /// <summary>
        /// Inorder tree traversal
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">root</exception>
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

        /// <summary>
        /// Postorder tree traversal
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">root</exception>
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

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Clear() => root = null;

        /// <summary>
        /// Determines whether the specified value is exists.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is exists; otherwise, <c>false</c>.
        /// </returns>
        public bool IsExists(T value)
        {
            bool isFind = false;
            Node<T> currentNode = root;

            while (currentNode != null || isFind)
            {
                if (comparer(value, currentNode.value) == 0)
                {
                    isFind = true;
                    break;
                }
                else if (comparer(value,currentNode.value) > 0)
                {
                    currentNode = currentNode.rightNode;
                }
                else
                {
                    currentNode = currentNode.leftNode;
                }
            }

            return isFind;
        }
        #endregion

        #region Private fields
        /// <summary>
        /// Creates the tree.
        /// </summary>
        /// <param name="array">The array.</param>
        private void CreateTree(T[] array)
        {
            foreach (T value in array)
            {
                Add(value);
            }
        }

        /// <summary>
        /// Adds the node.
        /// </summary>
        /// <param name="value">The value.</param>
        private void AddNode(T value)
        {
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
        #endregion
    }
}
