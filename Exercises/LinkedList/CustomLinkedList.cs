using System;

namespace Exercises.LinkedList {

    /// <summary>
    /// Provides an custom implemented linked list data structure exposing
    /// methods to manipulate and read the contents of the list.
    /// </summary>
    public class CustomLinkedList<T> {

        public CustomNode<T> First { get; private set; }
        public CustomNode<T> Last { get; private set; }

        public void AddFirst(CustomNode<T> node) {
            if (node is null) {
                throw new ArgumentNullException(nameof(node));
            }

            if (node.Equals(default(T))) {
                throw new InvalidNodeDataException();
            }

            if (First is null) {
                First = node;
                Last = node;
            } else {
                node.Previous = null;
                node.Next = First;
                First = node;
            }
        }

        public void AddLast(CustomNode<T> node) {
            if (node is null) {
                throw new ArgumentNullException(nameof(node));
            }

            if (node.Data.Equals(default(T))) {
                throw new InvalidNodeDataException();
            }

            if (Last == null) {
                First = node;
                Last = node;
            } else {
                node.Previous = Last;
                node.Next = null;
                Last = node;
            }
        }
    }
}