using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests {

    [TestClass]
    public class InPlaceMergeOfSortedSinglyLinkedListTests {

        /*
             * Input:
               
               First List: 2 —> 6 —> 9 —> 10 —> 15 —> NULL
               Second List: 1 —> 4 —> 5 —> 20 —> NULL
               
               Output:
               
               First List: 1 —> 2 —> 4 —> 5 —> 6 —> NULL
               Second List: 9 —> 10 —> 15 —> 20 —> NULL
        *
        */

        [TestMethod]
        public void ShouldHandle2ListsWhenBothAreEmpty() {
            LinkedList<int> list1 = new LinkedList<int>();
            LinkedList<int> list2 = new LinkedList<int>();

            var merger = new SortedInPlaceLinkedListMerger();

            merger.Merge(list1, list2);
            Assert.IsNotNull(list1);
            Assert.IsNotNull(list2);
            Assert.IsTrue(list1.Count == 0);
            Assert.IsTrue(list2.Count == 0);
        }

        [TestMethod]
        public void ShouldHandleWhenOneListIsEmpty() {
            LinkedList<int> list1 = new LinkedList<int>();
            LinkedList<int> list2 = new LinkedList<int>();
            list2.AddFirst(1);

            var merger = new SortedInPlaceLinkedListMerger();
            merger.Merge(list1, list2);
            Assert.AreEqual(1, list2.First.Value);
        }

        [TestMethod]
        public void ShouldMergeWhenThereIsOneElement() {
            LinkedList<int> list1 = new LinkedList<int>();
            LinkedList<int> list2 = new LinkedList<int>();
            list2.AddFirst(1);
            list1.AddFirst(2);

            var merger = new SortedInPlaceLinkedListMerger();
            merger.Merge(list1, list2);
            Assert.AreEqual(1, list1.First.Value);
            Assert.AreEqual(2, list2.First.Value);
        }

        [TestMethod]
        public void ShouldMergeWhenListContainsManyDistinctElements() {

            LinkedList<int> list1 = new LinkedList<int>();
            LinkedList<int> list2 = new LinkedList<int>();
            int[] values = {0,1,2,3,4,5,6,10,11};

            list2.AddFirst(values[8]);
            list2.AddFirst(values[6]);
            list2.AddFirst(values[4]);
            list2.AddFirst(values[2]);

            list1.AddFirst(values[7]);
            list1.AddFirst(values[5]);
            list1.AddFirst(values[3]);
            list1.AddFirst(values[1]);
            list1.AddFirst(values[0]);

            var merger = new SortedInPlaceLinkedListMerger();
            merger.Merge(list1, list2);

            LinkedListNode<int> node = list1.First;

            Assert.AreEqual(5, list1.Count);
            Assert.AreEqual(4, list2.Count);

            int i = 0;
            while (node != null) {
                Assert.AreEqual(values[i++], node.Value);
                node = node.Next;
            }

            node = list2.First;
            while (node != null) {
                Assert.AreEqual(values[i++], node.Value);
                node = node.Next;
            }
        }

        [TestMethod]
        public void ShouldMergeWhenSecondListHasMoreElements() {

            LinkedList<int> list1 = new LinkedList<int>();
            LinkedList<int> list2 = new LinkedList<int>();
            int[] values = { 0, 1, 2, 3, 4, 5, 6, 10, 11 };

            list1.AddFirst(values[8]);
            list1.AddFirst(values[6]);
            list1.AddFirst(values[4]);
            list1.AddFirst(values[2]);

            list2.AddFirst(values[7]);
            list2.AddFirst(values[5]);
            list2.AddFirst(values[3]);
            list2.AddFirst(values[1]);
            list2.AddFirst(values[0]);

            var merger = new SortedInPlaceLinkedListMerger();
            merger.Merge(list1, list2);

            LinkedListNode<int> node = list1.First;

            Assert.AreEqual(4, list1.Count);
            Assert.AreEqual(5, list2.Count);

            int i = 0;
            while (node != null) {
                Assert.AreEqual(values[i++], node.Value);
                node = node.Next;
            }

            node = list2.First;
            while (node != null) {
                Assert.AreEqual(values[i++], node.Value);
                node = node.Next;
            }
        }

    }
}
