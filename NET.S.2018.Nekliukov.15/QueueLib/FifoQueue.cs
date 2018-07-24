using System;
using System.Collections;
using System.Collections.Generic;

namespace QueueLib
{
    [Serializable]
    public class FifoQueue<T>: IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>
    {
        #region Constants

        private const int DEFAULT_CAPACITY = 4;
        private const long DEFAULT_RESIZE_MULTIPLIER = 200;

        #endregion

        #region Private fields

        private T[] queueArray;
        private int head;
        private int tail;
        private int size;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the number of elements in the collection.
        /// </summary>
        public int Count { get { return size; } }

        #endregion

        #region .Ctors        
        /// <summary>
        /// Initializes a new instance of the <see cref="FifoQueue{T}"/> class.
        /// </summary>
        public FifoQueue() => queueArray = new T[DEFAULT_CAPACITY];

        /// <summary>
        /// Initializes a new instance of the <see cref="FifoQueue{T}"/> class.
        /// </summary>
        /// <param name="capacity">The capacity.</param>
        /// <exception cref="ArgumentOutOfRangeException">Not valid cpacity</exception>
        public FifoQueue(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException($"{capacity} is not valid. Need non negative number!");
            }

            queueArray = new T[capacity];
            head = tail = size = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FifoQueue{T}"/> class.
        /// </summary>
        /// <param name="initialArray">The initial array.</param>
        /// <exception cref="ArgumentNullException">Null initialArray was sent</exception>
        public FifoQueue(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException($"Null {nameof(collection)} was sent");
            }

            queueArray = new T[4];
            foreach(T item in collection)
            {
                Enqueue(item);
            }    
        }
        #endregion

        #region Public API

        /// <summary>
        /// Dequeues the first element of this instance.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public T Dequeue()
        {
            if (size == 0)
            {
                throw new InvalidOperationException
                    ($"Queue is empty. There is nothing to dequeue here");
            }

            T result = queueArray[head];
            queueArray[head] = default(T);
            head += 1 % queueArray.Length;
            size--;
            return result;
        }

        /// <summary>
        /// Enqueues the new value
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentNullException">value</exception>
        public void Enqueue(T value)
        {
            if (size == queueArray.Length)
            {
                long growCoefficient = queueArray.Length * DEFAULT_RESIZE_MULTIPLIER / 100;
                int newLen = (int)(growCoefficient);
                if (newLen < queueArray.Length + DEFAULT_CAPACITY)
                {
                    newLen = queueArray.Length + 1;
                }

                SetCapacity(newLen);
            }

            queueArray[tail] = value;
            // not +1 in case of enqueuing the last element
            tail += 1 % queueArray.Length; 
            size++;
        }

        internal T GetElement(int position)
            => queueArray[(head + position) % queueArray.Length];

        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns>Interface <see cref="T:System.Collections.Generic.Queue<T>.Enumerator" />
        /// for <see cref="T:System.Collections.Generic.Queue<T>" />.</returns>
        public Enumerator GetEnumerator() => new Enumerator(this);

        #region Enumerator structure
        /// <summary>
        /// Returns an element that places on the current iterator position
        /// </summary>
        /// <seealso cref="System.Collections.Generic.IEnumerable{T}" />
        /// <seealso cref="System.Collections.IEnumerable" />
        /// <seealso cref="System.Collections.Generic.IReadOnlyCollection{T}" />
        public struct Enumerator : IEnumerator<T>, IDisposable, IEnumerator
        {
            #region Private fields
            // Collection over which we will implement iterations
            private readonly FifoQueue<T> parent;
            private int currentIndex;
            private T currentElement;
            #endregion

            #region Public API
            /// <summary>
            /// Gets the current.
            /// </summary>
            /// <value>
            /// The current.
            /// </value>
            /// <exception cref="InvalidOperationException">
            /// Enumerator is not started
            /// or
            /// Enumerator ended
            /// </exception>
            public T Current
            {
                get
                {
                    if (currentIndex < 0)
                    {
                        if (currentIndex == -1)
                        {
                            throw new InvalidOperationException("Enumerator is not started");
                        }
                        else
                        {
                            throw new InvalidOperationException("Enumerator ended");
                        }
                    }

                    return currentElement;
                }
            }

            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            public void Dispose()
            {
                currentIndex = -2;
                currentElement = default(T);
            }

            /// <summary>
            /// Advances the enumerator to the next element of the collection.
            /// </summary>
            /// <returns>
            /// true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.
            /// </returns>
            public bool MoveNext()
            {
                if (currentIndex++ == -2)
                {
                    return false;
                }

                if (currentIndex == parent.size)
                {
                    currentIndex = -2;
                    currentElement = default(T);
                    return false;
                }

                currentElement = parent.GetElement(currentIndex);
                return true;
            }

            public void Reset() => currentIndex = -1;
            #endregion

            /// <summary>
            /// Gets the current.
            /// </summary>
            /// <value>
            /// The current.
            /// </value>
            /// <exception cref="InvalidOperationException">
            /// Enumerator is not started
            /// or
            /// Enumerator ended
            /// </exception>
            object IEnumerator.Current
            {
                get
                {
                    if (currentIndex < 0)
                    {
                        if (currentIndex == -1)
                        {
                            throw new InvalidOperationException("Enumerator is not started");
                        }
                        else
                        {
                            throw new InvalidOperationException("Enumerator ended");
                        }
                    }

                    return currentElement;
                }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="Enumerator"/> struct.
            /// </summary>
            /// <param name="Parent">The parent.</param>
            internal Enumerator(FifoQueue<T> Parent)
            {
                // all fileds must be initialized before using
                parent = Parent;
                currentIndex = -1;
                currentElement = default(T);
            }
        }

        #endregion

        #region Private methods  
        /// <summary>
        /// Sets the capacity.
        /// </summary>
        /// <param name="capacity">The capacity.</param>
        private void SetCapacity(int capacity)
        {
            T[] newQueue = new T[capacity];
            if (size > 0)
            {
                if (head < tail)
                {
                    Array.Copy(queueArray, head, newQueue, 0, size);
                }
                else
                {
                    Array.Copy(queueArray, head, newQueue, 0, queueArray.Length - head);
                    Array.Copy(queueArray, tail, newQueue, queueArray.Length - head, tail);
                }

                queueArray = newQueue;
                head = 0;
                tail = (size != capacity) ? size : 0;
            }
        }
        #endregion

        #endregion

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// An enumerator that can be used to iterate through the collection.
        /// </returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
            => (IEnumerator<T>)(object)new Enumerator(this);

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object that can
        /// be used to iterate through the generic collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
            => (IEnumerator)(object)new Enumerator(this);
    }
}
