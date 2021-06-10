using System;
using System.Collections.Generic;
using Exercises.LinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests.LinkedList {

    [TestClass]
    public class LinkedListTests {

        [TestMethod]
        public void ShouldAddAnElementToTheFirstPosition() {
            CustomLinkedList linkedList = new CustomLinkedList();
            CustomNode node = new CustomNode(Guid.NewGuid().ToString());
            linkedList.AddFirst(node);
            CustomNode firstNode = linkedList.First;
            Assert.IsNotNull(firstNode);
            Assert.AreEqual(node.Data, firstNode.Data, "Incorrect data in the retrieved first node");
        }

        [TestMethod]
        public void ShouldAddAnElementToFirstPositionToExistingList() {
            CustomLinkedList linkedList = new CustomLinkedList();
            CustomNode firstNode = new CustomNode(Guid.NewGuid().ToString());
            linkedList.AddFirst(firstNode);

            CustomNode secondNode = new CustomNode(Guid.NewGuid().ToString());
            linkedList.AddFirst(secondNode);

            CustomNode thirdNode = new CustomNode(Guid.NewGuid().ToString());
            linkedList.AddFirst(thirdNode);

            CustomNode retrievedFirstNode = linkedList.First;
            Assert.IsNotNull(retrievedFirstNode);
            Assert.AreEqual(thirdNode.Data, retrievedFirstNode.Data, "Incorrect data in the retrieved first node");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldHandleNullWhenAddingLastNode() {
            var linkedList = new CustomLinkedList();
            linkedList.AddLast(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidNodeDataException))]
        public void ShouldHandleNullDataWhenAddingLastNode() {
            var linkedList = new CustomLinkedList();
            linkedList.AddLast(new CustomNode(null));
        }

        [TestMethod]
        public void ShouldReadDataFromAllNodesFromFirstNode() {
            CustomLinkedList linkedList = new CustomLinkedList();
            var firstNode = new CustomNode(Guid.NewGuid().ToString());
            var secondNode = new CustomNode(Guid.NewGuid().ToString());
            var thirdNode = new CustomNode(Guid.NewGuid().ToString());

            linkedList.AddFirst(firstNode);
            linkedList.AddFirst(secondNode);
            linkedList.AddFirst(thirdNode);

            List<string> dataList = new List<string>();

            var node = linkedList.First;
            while (node != null) {
                dataList.Add(node.Data);
                node = node.Next;
            }

            Assert.AreEqual(firstNode.Data, dataList[2]);
            Assert.AreEqual(secondNode.Data, dataList[1]);
            Assert.AreEqual(thirdNode.Data, dataList[0]);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ShouldHandleNullInput() {
            CustomLinkedList linkedList = new CustomLinkedList();
            linkedList.AddFirst(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidNodeDataException))]
        public void ShouldHandleNullValueForNodeData() {
            var customLinkedList = new CustomLinkedList();
            CustomNode node = new CustomNode(null);
            customLinkedList.AddFirst(node);
        }

        [TestMethod]
        public void ShouldGetFirstNode() {
            var customLinkedList = new CustomLinkedList();
            customLinkedList.AddFirst(new CustomNode(Guid.NewGuid().ToString()));
            customLinkedList.AddFirst(new CustomNode(Guid.NewGuid().ToString()));
            var node = new CustomNode(Guid.NewGuid().ToString());
            customLinkedList.AddFirst(node);
            Assert.AreEqual(node, customLinkedList.First);
        }

        [TestMethod]
        public void ShouldGetLastNodeWhenListIsEmpty() {
            var customLinkedList = new CustomLinkedList();
            CustomNode node = new CustomNode(Guid.NewGuid().ToString());
            customLinkedList.AddFirst(node);
            Assert.AreEqual(node, customLinkedList.Last);
        }

        [TestMethod]
        public void ShouldGetLastNodeWhenListIsNotEmpty() {
            var customLinkedList = new CustomLinkedList();
            CustomNode node = new CustomNode(Guid.NewGuid().ToString());
            customLinkedList.AddFirst(node);
            customLinkedList.AddFirst(new CustomNode(Guid.NewGuid().ToString()));
            customLinkedList.AddFirst(new CustomNode(Guid.NewGuid().ToString()));
            Assert.AreEqual(node, customLinkedList.Last);
        }

        [TestMethod]
        public void ShouldAddNodeAtLastWhenListIsEmpty() {
            var linkedList = new CustomLinkedList();
            var node = new CustomNode(Guid.NewGuid().ToString());
            linkedList.AddLast(node);
            Assert.AreEqual(node, linkedList.Last);
        }

        [TestMethod]
        public void ShouldAddLastNodeWhenListIsNotEmpty() {
            var linkedList = new CustomLinkedList();
            var node1 = new CustomNode(Guid.NewGuid().ToString());
            linkedList.AddLast(node1);
            var node2 = new CustomNode(Guid.NewGuid().ToString());
            linkedList.AddLast(node2);
            var node3 = new CustomNode(Guid.NewGuid().ToString());
            linkedList.AddLast(node3);

            Assert.AreEqual(node3, linkedList.Last);
        }

    }
}
