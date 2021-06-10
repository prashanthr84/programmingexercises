using System;

namespace Exercises.LinkedList {

    /// <summary>
    /// Provides an custom implemented linked list data structure exposing
    /// methods to manipulate and read the contents of the list.
    /// </summary>
    public class CustomLinkedList {

        public CustomNode First { get; private set; }
        public CustomNode Last { get; private set; }

        public void AddFirst(CustomNode node) {
            if (node is null) {
                throw new ArgumentNullException(nameof(node));
            }

            if (string.IsNullOrWhiteSpace(node.Data)) {
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

        public void AddLast(CustomNode node) {
            if (node is null) {
                throw new ArgumentNullException(nameof(node));
            }

            if (node.Data is null) {
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