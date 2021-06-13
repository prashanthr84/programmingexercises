using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests {

    [TestClass]
    public class InPlaceMergeOfSortedSinglyLinkedListTests {

        [TestMethod]
        public void ShouldHandle2ListsWhenBothAreEmpty() {
            LinkedList<int> list1 = new LinkedList<int>();
            LinkedList<int> list2 = new LinkedList<int>();

            var merger = new SortedLinkedListMerger();

            LinkedList<int> mergedList = merger.Merge(list1, list2);
            Assert.IsTrue(mergedList.Count == 0);
        }

        [TestMethod]
        public void ShouldHandleWhenOneListIsEmpty() {
            LinkedList<int> list1 = new LinkedList<int>();
            LinkedList<int> list2 = new LinkedList<int>();
            list2.AddFirst(1);

            var merger = new SortedLinkedListMerger();
            var mergedList = merger.Merge(list1, list2);
            Assert.IsTrue(mergedList.Count == 1);
            Assert.AreEqual(1, mergedList.First.Value);
        }

        [TestMethod]
        public void ShouldMergeWhenThereIsOneElement() {
            LinkedList<int> list1 = new LinkedList<int>();
            LinkedList<int> list2 = new LinkedList<int>();
            list2.AddFirst(1);
            list1.AddFirst(2);

            var merger = new SortedLinkedListMerger();
            var mergedList = merger.Merge(list1, list2);
            Assert.IsTrue(mergedList.Count == 2);
            Assert.AreEqual(1, mergedList.First.Value);
            Assert.IsNotNull(mergedList.First.Next);
            Assert.AreEqual(2, mergedList.First.Next.Value);
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

            var merger = new SortedLinkedListMerger();
            var mergedList = merger.Merge(list1, list2);

            Assert.IsTrue(mergedList.Count == 9);
            Assert.IsNotNull(mergedList.First);
            LinkedListNode<int> node = mergedList.First;
            
            int i = 0;
            while (node != null) {
                Assert.AreEqual(values[i++], node.Value);
                node = node.Next;
            }
        }

    }
}
