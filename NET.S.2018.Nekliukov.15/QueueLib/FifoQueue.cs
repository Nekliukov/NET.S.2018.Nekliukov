using System;

namespace QueueLib
{
    public class FifoQueue<T>
    {
        private T[] fifoQueue;

        public int Count { get { return fifoQueue.Length; } }

        public T this[int index]
        {
            get => fifoQueue[index];
            set => fifoQueue[index] = value;
        }

        public FifoQueue(T[] initialArray)
        {
            fifoQueue = new T[initialArray.Length];
            for (int i = 0; i < initialArray.Length; i++)
            {
                fifoQueue[i] = initialArray[i];
            }
        }

        #region Adding overloaded methods
        public void Enqueue(T newElement)
        {
            Array.Resize<T>(ref fifoQueue, this.Count + 1);
            fifoQueue[Count - 1] = newElement;
        }

        public void Enqueue(T newFirstElement, T newSecondElement)
        {
            Array.Resize<T>(ref fifoQueue, this.Count + 2);
            fifoQueue[Count - 1] = newFirstElement;
            fifoQueue[Count - 2] = newSecondElement;
        }
        public void Enqueue(params T[] newElements)
        {
            int oldLength = this.Count;
            Array.Resize<T>(ref fifoQueue, this.Count + newElements.Length);
            for (int i = 0; i < newElements.Length; i++, oldLength++)
            {
                fifoQueue[oldLength] = newElements[i];
            }
        }
        #endregion


        public QueueIterator Iterator()
        {
            return new QueueIterator(this);
        }

        public struct QueueIterator
        {
            // Collection over which we will implement iterations
            private readonly FifoQueue<T> parent;
            private int currentIndex;
            
            internal QueueIterator(FifoQueue<T> Parent)
            {
                parent = Parent;
                currentIndex = -1;
            }

            public T Current
            {
                get
                {
                    if (currentIndex == -1 || currentIndex == parent.Count)
                    {
                        throw new InvalidOperationException("Operation cannot be done");
                    }

                    return parent[currentIndex];
                }
            }

            public bool MoveNext()
            {
                if (currentIndex != parent.Count)
                {
                    currentIndex++;
                }

                return currentIndex < parent.Count;
            }

            public void Reset() => currentIndex = -1;
        }
    }
}
