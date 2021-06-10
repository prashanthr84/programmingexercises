using System;

namespace Exercises.LinkedList {

    /// <summary>
    /// Provides an custom implemented linked list data structure exposing
    /// methods to manipulate and read the contents of the list.
    /// </summary>
    public class CustomLinkedList {

        public CustomNode First { get; set; }

        public CustomNode Last { get; set; }

        public void AddFirst(CustomNode node) {
            

            if (string.IsNullOrWhiteSpace(node.Data)) {
                throw new InvalidNodeDataException();
            }

        }

        public void AddLast(CustomNode node) {

            if (node.Data is null) {
                throw new InvalidNodeDataException();
            }

        }
    }
}