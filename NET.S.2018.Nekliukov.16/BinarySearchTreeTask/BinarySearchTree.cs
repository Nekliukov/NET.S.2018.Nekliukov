using System;
using System.Collections;
using System.Collections.Generic;

namespace BinarySearchTreeTask
{
    public class BinarySearchTree<T>: IEnumerable<T>
    {
        #region Private fields
        /// <summary>
        /// Binary search tree root
        /// </summary>
        private Node<T> _root;

        /// <summary>
        /// The comparer for choosen type
        /// </summary>
        private readonly Comparison<T> _comparer;
        #endregion

        #region .Ctors
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BinarySearchTreeTask.BinarySearchTree`1" /> class.
        /// </summary>
        /// <param name="initArray">The initialize array.</param>
        public BinarySearchTree(IEnumerable<T> initArray) : this(initArray, Comparer<T>.Default.Compare) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        /// <param name="initCollection">The initialize array.</param>
        /// <param name="comparer">The comparer.</param>
        /// <exception cref="ArgumentNullException">Null initArray was sent</exception>
        /// <exception cref="ArgumentException">Empty initArray was sent</exception>
        /// <exception cref="InvalidOperationException">Your type doesn't implement IComparable interface</exception>
        public BinarySearchTree(IEnumerable<T> initCollection, Comparison<T> comparer)
        {
            if (initCollection == null)
            {
                throw new ArgumentNullException($"Null {nameof(initCollection)} was sent");
            }

            if (!initCollection.GetEnumerator().MoveNext())
            {
                throw new ArgumentException($"Empty {nameof(initCollection)} was sent");
            }

            if (!typeof(IComparable<T>).IsAssignableFrom(typeof(T)) &&
                !typeof(IComparable).IsAssignableFrom(typeof(T)))
            {
                throw new InvalidOperationException("Your type doesn't implement IComparable interface");
            }

            _comparer = comparer;
            CreateTree(initCollection);
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

            if (_root == null)
            {
                _root = new Node<T>(value);
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
            if (_root == null)
            {
                throw new ArgumentNullException($"{nameof(_root)} has null reference");
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

            return GetOrder(_root);
        }

        /// <summary>
        /// Inorder tree traversal
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">root</exception>
        public IEnumerable<T> Inorder()
        {
            if (_root == null)
            {
                throw new ArgumentNullException($"{nameof(_root)} has null reference");
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

            return GetOrder(_root);
        }

        /// <summary>
        /// Postorder tree traversal
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">root</exception>
        public IEnumerable<T> Postorder()
        {
            if (_root == null)
            {
                throw new ArgumentNullException($"{nameof(_root)} has null reference");
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

            return GetOrder(_root);
        }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Clear() => _root = null;

        /// <summary>
        /// Determines whether the specified value is exists.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is exists; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(T value)
        {
            bool isFind = false;
            Node<T> currentNode = _root;

            while (currentNode != null)
            {
                if (_comparer(value, currentNode.value) == 0)
                {
                    isFind = true;
                    break;
                }
                else if (_comparer(value,currentNode.value) > 0)
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
        private void CreateTree(IEnumerable<T> array)
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
            Node<T> currNode = _root;

            while (true)
            {
                if (_comparer(value, currNode.value) >= 0)
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

        #region IEnumerable implemenation        
        /// <inheritdoc />
        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator() => Inorder().GetEnumerator();

        /// <inheritdoc />
        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        #endregion

        #endregion
    }
}
