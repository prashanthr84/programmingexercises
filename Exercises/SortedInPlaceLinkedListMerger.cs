using System;
using System.Collections.Generic;

namespace Exercises {
    /// <summary>
    /// Responsibility => Merge the 2 sorted input linked list in place.
    /// </summary>
    public class SortedInPlaceLinkedListMerger {

        public void Merge(LinkedList<int> list1, LinkedList<int> list2) {

            LinkedListNode<int> list1Node = list1.First;

            while (list1Node != null) {
                if (list1Node.Value > list2.First.Value) {
                    var tempValue = list1Node.Value;
                    list1Node.Value = list2.First.Value;
                    InsertAtRightPosition(list2, tempValue);
                } else {
                    list1Node = list1Node.Next;
                }
            }
        }

        private void InsertAtRightPosition(LinkedList<int> list2, int value) {

            list2.First.Value = value;
            LinkedListNode<int> node = list2.First;

            while (node != null) {
                if (node.Next != null && node.Next.Value < node.Value) {
                    SwapValues(node, node.Next);
                    node = node.Next;
                } else {
                    break;
                }
            }
        }

        private static void SwapValues(LinkedListNode<int> node1, LinkedListNode<int> node2) {
            int tempValue = node2.Value;
            node2.Value = node1.Value;
            node1.Value = tempValue;
        }
    }
}