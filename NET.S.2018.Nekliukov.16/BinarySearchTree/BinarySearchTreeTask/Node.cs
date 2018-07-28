namespace BinarySearchTreeTask
{
    /// <summary>
    /// Generic node in binary search tree
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class Node<T>
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
